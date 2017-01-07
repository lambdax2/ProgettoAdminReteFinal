using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using ZedGraph;
using System.IO;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class dedicated to handling communication with client
    /// </summary>
    class comHandler
    {
        /**communication socket*/
        private static Socket clientComSocket;
        /**reading thread*/
        private static Thread readThread;
        /**listening thread, used to listen for client connections*/
        private static Thread lthread;
        /**tcplistener, waits for tcp connections*/
        private static TcpListener tcpl;
        /**counter var*/
        public static int c;
        /**tracks number of packets read*/
        public static int count = 1;
        /**contains moduled accelerometer values, storing a counter in .x and the moduled values in .y */
        public static List<PointPairList> acc;
        /**contains moduled gyroscope values, storing a counter in .x and the moduled values in .y */
        public static List<PointPairList> gir;
        /**contains moduled magnetometer values, storing a counter in .x and the moduled values in .y */
        public static List<PointPairList> mag;
        /**contains single components of accelerometer, storing single components into .x .y and .z */
        public static List<PointPairList> rawAcc;
        /**contains single components of gyroscope, storing single components into .x .y and .z */
        public static List<PointPairList> rawGyr;
        /**contains single components of magnetometer, storing single components into .x .y and .z */
        public static List<PointPairList> rawMag;
        /**standard deviation pointpairlist*/
        public static PointPairList devstd;
        /**pelvis accelerometer x axis values*/
        public static PointPairList accx;
        /**help variable*/
        public double lastDevStd = 0;
        /**number of sensors*/
        public static int nSensors = 0;
        /**flag that defines if bstartstop has to work like a start button(flag = true) or a stop button(flag=false)*/
        private static bool bStartStopFlag = true;
        /**heading pointpairlist, used for tracking heading direction and calculate width of turns*/
        private static PointPairList heading;

        /// <summary>
        /// Button start/stop click event handler
        /// </summary>
        public static void bStart_Click(object sender, EventArgs e)
        {
            if (bStartStopFlag)
            {
                //Server not yet started -> the button will work as start button
                ((Button)sender).Text = "Stop";
                ((Button)sender).Enabled = false;
                bStartStopFlag = false;
                //disable settings button
                Prog.mf.bSettings.Enabled = false;

                //configuring & starting tcplistner
                string _s = Properties.Settings.Default.IP1.ToString() + '.' + Properties.Settings.Default.IP2.ToString() + '.' + Properties.Settings.Default.IP3.ToString() + '.' + Properties.Settings.Default.IP4.ToString();
                IPAddress _ip = IPAddress.Parse(_s);
                int _port = Properties.Settings.Default.Port;
                tcpl = new TcpListener(_ip, _port);
                
                //creating listening thread that will wait for client connection without blocking UI thread 
                lthread = new Thread( () => clientListenStart() );  // () => clientListenStart()  <===>  new Thread(new ThreadStart(clientListenStart))  <===>  new Thread(clientListenStart).Start()) 
                lthread.Name = "Listen Thread";
                lthread.Start();
                Prog.mf.addText("Server started, listening on " + _ip.ToString() + ":" + _port.ToString() + "\t\t",0);
            }
            else
            {
                //already started so button will work as stop button
                bStartStopFlag = true;
                Prog.mf.bSettings.Enabled = true;
                //stop button will truncate the data transmission
                clientComSocket.Close();
                clientComSocket = null;
            }
        }

        /// <summary>
        /// listen thread, waits until he find a socket to connect to and when found calls the class constructor comhandler that 
        /// starts the reading of data
        /// </summary>
        public static void clientListenStart()
        {
            tcpl.Start();                               //start tcplistner
            Socket client = tcpl.AcceptSocket();        //blocked until connection ------> N.B. this code is on a separate thread from the UI one. In result we have the UI thread not blocked
            new comHandler(client);                     //when a client connects, start a new communication handler to handle the data transfer
            tcpl.Stop();                                //tcplistener is no longer needed, stop it.  
        }

        /// <summary>
        /// class constructor, starts the thread that is going to read data
        /// </summary>
        /// <param name="clientCSocket">Client communication socket</param>
        public comHandler(Socket clientCSocket)
        {
            clientComSocket = clientCSocket;
            readThread = new Thread( () => readData()); //setting up thread that will read data sent by the client
            readThread.Name = "Read Thread";
            readThread.Start();
        }

        /// <summary>
        /// Reading Thread, read data sent by the client, stores it into lists, and calls the program functions.
        /// </summary>
        public void readData()
        {
            //var init
            c = 0;
            count = 1;
            acc = new List<PointPairList>();
            gir = new List<PointPairList>();
            mag = new List<PointPairList>();
            rawAcc = new List<PointPairList>();
            rawGyr = new List<PointPairList>();
            rawMag = new List<PointPairList>();

            accx = new PointPairList();
            devstd = new PointPairList();
            heading = new PointPairList();

            for (int i = 0; i < 5; i++)
            {
                acc.Add(new PointPairList());
                gir.Add(new PointPairList());
                mag.Add(new PointPairList());
                rawAcc.Add(new PointPairList());
                rawGyr.Add(new PointPairList());
                rawMag.Add(new PointPairList());
            }

            byte[] len = new byte[2];
            byte[] tem = new byte[3];
            byte[] pacchetto;
            int byteToRead, maxSensori = 5;

            Prog.mf.addText("Client connected \t\t \r\n",0);

            try
            {
                using (Stream stream = new NetworkStream(clientComSocket))
                using (BinaryReader bin = new BinaryReader(stream))
                {
                    while (!(tem[0] == 0xFF && tem[1] == 0x32)) // cerca la sequenza FF-32
                    {
                        tem[0] = tem[1];
                        tem[1] = tem[2];
                        byte[] read = bin.ReadBytes(1);
                        tem[2] = read[0];
                    }
                    if (tem[2] != 0xFF) // modalità normale
                    {
                        byteToRead = tem[2]; // byte da leggere
                    }
                    else  // modalità extended-length
                    {
                        len = new byte[2];
                        len = bin.ReadBytes(2);
                        byteToRead = (len[0] * 256) + len[1]; // byte da leggere
                    }

                    byte[] data = new byte[byteToRead + 1];
                    data = bin.ReadBytes(byteToRead + 1); // lettura dei dati

                    if (tem[2] != 0xFF)
                    {
                        pacchetto = new byte[byteToRead + 4]; // creazione pacchetto
                    }
                    else
                    {
                        pacchetto = new byte[byteToRead + 6];
                    }

                    nSensors = (byteToRead - 2) / 52; // calcolo del numero di sensori
                    pacchetto[0] = 0xFF; // copia dei primi elementi
                    pacchetto[1] = 0x32;
                    pacchetto[2] = tem[2];

                    if (tem[2] != 0xFF)
                    {
                        data.CopyTo(pacchetto, 3); // copia dei dati
                    }
                    else
                    {
                        pacchetto[3] = len[0];
                        pacchetto[4] = len[1];
                        data.CopyTo(pacchetto, 5); // copia dei dati
                    }

                    List<List<double>> array = new List<List<double>>(); // salvataggio dati

                    int[] t = new int[maxSensori];

                    for (int x = 0; x < nSensors; x++)
                    {
                        array.Add(new List<double>()); // una lista per ogni sensore
                        t[x] = 5 + (52 * x);
                    }

                    Prog.mf.addText("Data Receive Start...  \t\t \r\n",0);

                    Prog.mf.bStartStop.Invoke((MethodInvoker)delegate()
                    {
                        Prog.mf.bStartStop.Enabled = true;
                    });

                    //reading loop
                    while (true)
                    {
                        for (int i = 0; i < nSensors; i++)
                        {
                            byte[] temp = new byte[4];
                            for (int tr = 0; tr < 13; tr++)//EACH PACKET = 13 fields, 3 * 3 + 4 -> 3acc - 3gyr - 3mag - 4quat
                            {
                                if (nSensors < 5)
                                {
                                    temp[0] = pacchetto[t[i] + 3]; // lettura inversa
                                    temp[1] = pacchetto[t[i] + 2];
                                    temp[2] = pacchetto[t[i] + 1];
                                    temp[3] = pacchetto[t[i]];
                                }
                                else
                                {
                                    temp[0] = pacchetto[t[i] + 5];
                                    temp[1] = pacchetto[t[i] + 4];
                                    temp[2] = pacchetto[t[i] + 3];
                                    temp[3] = pacchetto[t[i] + 2];
                                }
                                Single valore = BitConverter.ToSingle(temp, 0); // conversione
                                array[i].Add(valore); // memorizzazione
                                t[i] += 4;
                            }
                        }

                        for (int x = 0; x < nSensors; x++)
                        {
                            t[x] = 5 + (52 * x);
                        }

                        c = 0;

                        for (int j = 0; j < nSensors; j++)
                        {
                            //Accelerometer: adding module to acc list and single components to rawAcc list
                            acc[j].Add(count, utilityes.module(array[j][0], array[j][1], array[j][2]));
                            rawAcc[j].Add(new PointPair(array[j][0], array[j][1], array[j][2]));
                            acc = functions.smoothing(acc, Properties.Settings.Default.SmoothingWindow,c);

                            if (j == 0) //pelvis -> j=0, accelerometer x axis -> [][0] => array[0][0] datas
                            {
                                accx.Add(count, array[j][0]); //save value in a point pair list
                                accx = functions.smoothing(accx, Properties.Settings.Default.SmoothingWindow); //smooth accelerometer x values
                            }

                            //gyroscope: same as accelerometer , save module in gyr list and single components in rawGyr
                            gir[j].Add(count, utilityes.module(array[j][3], array[j][4], array[j][5]));
                            rawGyr[j].Add(new PointPair(array[j][3], array[j][4], array[j][5]));
                            gir = functions.smoothing(gir, Properties.Settings.Default.SmoothingWindow,c); 

                            //magnetometer as above but with one more operation: magPIFix function
                            mag[j].Add(count, Math.Atan2(array[j][7], array[j][8]));
                            rawMag[j].Add(new PointPair(array[j][6], array[j][7], array[j][8]));
                            mag = utilityes.magPIFix(mag, j);
                            mag = functions.smoothing(mag, Properties.Settings.Default.SmoothingWindow,c);

                            if (j == 0)
                            {
                                heading.Add(count, utilityes.calculate_heading(array[j][7], array[j][8]));
                                //searching for turns (when we have enough datas)
                                if (count >= Properties.Settings.Default.TurnWindow)
                                    functions.turnDiscover(gir[0], mag[0], Properties.Settings.Default.TurnWindow, Properties.Settings.Default.MinTurnValue, Properties.Settings.Default.TurnLimit90_180, count, heading);

                            }
                            //removing processed data
                            array[j].RemoveRange(0, 13);

                            c++;
                        }


                        //if we have a window of values, run the functions
                        if(count % Properties.Settings.Default.ActivityWindow == 0)
                        {
                            lastDevStd = utilityes.devStd(acc[0], Properties.Settings.Default.ActivityWindow);
                            functions.stationing(lastDevStd, Properties.Settings.Default.stationingRound,count);
                            functions.activityDiscover(accx, Properties.Settings.Default.ActivityWindow,count);
                        }

                        //dev standard is calculated at fixed intervals (activity window, default 10 samples)
                        devstd.Add(count, lastDevStd);

                        //check if already processed at least SmoothingWindow number of data, if so start drawing
                        if (count > Properties.Settings.Default.SmoothingWindow)
                        {
                            //drawing graphs (axis change and refresh of the graphs are done into the draw method)
                            graphHandler.draw(Prog.mf.zgAcc, acc, Properties.Settings.Default.SmoothingWindow);
                            graphHandler.draw(Prog.mf.zgGir, gir, Properties.Settings.Default.SmoothingWindow);
                            graphHandler.draw(Prog.mf.zgMag, mag, Properties.Settings.Default.SmoothingWindow);

                            graphHandler.draw(Prog.mf.agf.zgStdDev, devstd, Properties.Settings.Default.SmoothingWindow);
                            graphHandler.draw(Prog.mf.agf.zgXAxis, accx, Properties.Settings.Default.SmoothingWindow);
                        }

                        count++;

                        //read pack over

                        if (nSensors < 5) // lettura pacchetto seguente
                        {
                            pacchetto = bin.ReadBytes(byteToRead + 4);
                        }
                        else
                        {
                            pacchetto = bin.ReadBytes(byteToRead + 6);
                        }
                    }      
                }
            }
            catch (Exception e)
            {
                //exception raised
                //we get here in 2 cases:
                //1)stop button has been pressed -> this event generates an exception because into the stop button event handler we close the socket
                //2)all datas has been received -> exception when trying to get more data
                if (clientComSocket != null) //if is null it means stop button has been pressed and clientcomsocket has already been closed
                { 
                    clientComSocket.Close();
                    clientComSocket = null;
                }
                
                //draw last points (graph refresh is included into the method)
                graphHandler.drawLast(Prog.mf.zgAcc, acc, count);
                graphHandler.drawLast(Prog.mf.zgGir, gir, count);
                graphHandler.drawLast(Prog.mf.zgMag, mag, count);
                graphHandler.drawLast(Prog.mf.agf.zgStdDev, devstd, count);
                graphHandler.drawLast(Prog.mf.agf.zgXAxis, accx, count);

                Prog.mf.addText("Client disconnected ",2);

                //Setting up buttons states
                if (Prog.mf.bExport.InvokeRequired)
                    Prog.mf.bExport.Invoke((MethodInvoker)delegate()
                    {
                        Prog.mf.bStartStop.Enabled = false;
                        Prog.mf.bSettings.Enabled = true;
                        Prog.mf.bReset.Enabled = true;
                        Prog.mf.cbTurnStartStopShow.Enabled = true;
                        Prog.mf.bExport.Enabled = true;
                    });

                Prog.mf.addText("Server stopped",0);
            }
        }
    }
}