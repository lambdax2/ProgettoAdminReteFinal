using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class that encloses principal functions of te project
    /// </summary>
    class functions
    {
        /**variable used to keep track of the turn width (when Classifyer is not activated, when classifyer is activated maxTurn is unused)*/
        public static double maxTurn = 0;
        /*variable used to activate(true) or deactivate(false) the algorithm to find the exact range of turns expressed in degrees*/
        public static bool activateClassifyer = false;
        /**variable used to track status of movement of the person. codes: 1 -> steady , 2 -> not steady*/
        public static int stationingStatus = 0;
        /**variable used to track current activity of the person. codes: 0 -> start , 1 -> lay , 2 -> lay/sit , 3 -> sit , 4 -> stand*/
        public static int activityStatus = 0;
        public static double mg = 1.5;

        /** @name turn find variables
        *  variables for turn finding 
        */
        ///@{
        /**variable useed to define when a turn start has been detected*/
        private static bool turningStarted = false;
        /**variable used to track the number of turns*/
        private static int turnCounter = 0;
        ///@}

        /** @name variables for showing turn detection points (start and stop points)
        *  start point is the first sample of the first window where a turn has been detected.
        *  stop point is the last sample of the window where a turn stop has been detected. 
        */
        ///@{
        private static int start = -1;
        private static int stop = -1;
        ///@}

        /// <summary>
        /// Smoothing
        /// </summary>
        /// <param name="lppl">list of pointpairlist each contatining values to smooth</param>
        /// <param name="smoothWin">dimension of the smoothing window</param>
        /// <param name="index">index of the pointpairlist to smooth</param>
        /// <returns>smoothed list of pointpairlist lppl</returns>
        /// <remarks>The type of smoothing used is box smoothing (also called moving average)</remarks>
        public static List<PointPairList> smoothing(List<PointPairList> lppl, int smoothWin,int index)
        {
            if (lppl[index].Count >= smoothWin)
            {
                double _higherSum = 0;
                double _lowerSum = 0;

                //count - smoothwin to count - smoothwin/2 -1 --> lower half
                for (int i = lppl[index].Count - smoothWin; i < lppl[index].Count - (smoothWin / 2) - 1; i++)
                    _lowerSum += lppl[index][i].Y;
                _lowerSum /= (smoothWin / 2);

                //count - smoothwin/2 to count --> higher half
                for (int i = lppl[index].Count - (smoothWin / 2); i < lppl[index].Count; i++)
                    _higherSum += lppl[index][i].Y;
                _higherSum /= (smoothWin / 2);

                // (smoothwin/2) samples before -------- smoothed sample   ---------  (smoothwin/2) samples after 
                lppl[index][lppl[index].Count - (smoothWin / 2) - 1].Y = ((_lowerSum + _higherSum) / 2);
            }

            return lppl;
        }

        /// <summary>
        /// smoothing , one-line graph version
        /// </summary>
        /// <param name="ppl">pointpairlist containing values to smooth</param>
        /// <param name="smoothWin">dimension of the smoothing window</param>
        /// <returns>smoothed pointpairlist ppl</returns>
        /// <remarks>The type of smoothing used is box smoothing (also called moving average)</remarks>
        public static PointPairList smoothing(PointPairList ppl, int smoothWin)
        {
            if (ppl.Count >= smoothWin)
            {
                double _higherSum = 0;
                double _lowerSum = 0;

                //count - smoothwin to count - smoothwin/2 -1 --> lower half
                for (int i = ppl.Count - smoothWin; i < ppl.Count - (smoothWin / 2) - 1; i++)
                    _lowerSum += ppl[i].Y;
                _lowerSum /= (smoothWin / 2);

                //count - smoothwin/2 to count --> higher half
                for (int i = ppl.Count - (smoothWin / 2); i < ppl.Count; i++)
                    _higherSum += ppl[i].Y;
                _higherSum /= (smoothWin / 2);

                // (smoothwin/2) samples before -------- smoothed sample   ---------  (smoothwin/2) samples after 
                ppl[ppl.Count - (smoothWin / 2) - 1].Y = ((_higherSum + _lowerSum) / 2);
            }

            return ppl;
        }

        /// <summary>
        /// Stationing function, used for defining the state of movement (steady or not) 
        /// </summary>
        /// <param name="devStd">standard deviation</param>
        /// <param name="stationingLimit">limit to pass to get into "not steady" status</param>
        /// <param name="count">sample number, used to estimate activity time by doing count * 0.02(0.02 derives from 50 Hz transmission frequency)</param>
        public static void stationing(double devStd, double stationingLimit, int count)
        {
            if (devStd < stationingLimit) {
                if (stationingStatus != 1)
                {
                    stationingStatus = 1;
                    Prog.mf.addText("Steady \t\t\t ", 1);
                }
            }
            else
            {
                if (stationingStatus != 2)
                {
                    stationingStatus = 2;
                    Prog.mf.addText("Not steady \t\t ", 1);
                }
            }
        }

        /// <summary>
        /// ActivityDiscover function focus on discovering the activity (lay,sit,stand) of the person
        /// </summary>
        /// <param name="pplAccX">pointpairlist containing values of x axis of pelvis accelerometer</param>
        /// <param name="activityWindow">dimension of work window</param>
        /// <param name="count">sample number, used to estimate activity time by doing count * 0.02(0.02 derives from 50 Hz transmission frequency)</param>
        public static void activityDiscover(PointPairList pplAccX, int activityWindow, int count)
        {
            if (pplAccX.Count >= activityWindow)
            {
                double _avg = utilityes.average(pplAccX, activityWindow);

                if (_avg <= 2.7 && activityStatus != 1)
                {
                    activityStatus = 1;  //under 2.7 -> (0,2.7]
                    Prog.mf.addText("Lay \t\t\t ", 1);
                }
                else
                {
                    if (_avg <= 3.7 && activityStatus != 2)
                    {
                        activityStatus = 2;  //between 2.7 and 3.7 -> (2.7,3.7]
                        Prog.mf.addText("Lay/sit \t\t\t ", 1);
                    }
                    else
                    {
                        if (_avg <= 7 && activityStatus != 3)
                        {
                            activityStatus = 3;  //between 3.7 and 7 -> (3.7,7]
                            Prog.mf.addText("Sit \t\t\t ", 1);
                        }
                        else
                        {
                            if (activityStatus != 4)
                            {
                                activityStatus = 4; //over 7 -> (7,+inf)
                                Prog.mf.addText("Stand \t\t\t ", 1);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// turnDiscover Function focus on recognizing turns made
        /// </summary>
        /// <param name="gyrPPL">pointpairlist containing values of pelvis gyroscope</param>
        /// <param name="magPPL">pointpairlist containing values of pelvis magnetometer</param>
        /// <param name="turnWindow">dimension of the turning window observed</param>
        /// <param name="minTurn">limit value that defines if the turn has a min value</param>
        /// <param name="turnLimit90_180">limit value that distinguish from turns less than 90 degrees and more than 90 degrees</param>
        /// <param name="count">number of sample, used to do an estimation of the end time of the turn by doing count * 0.02(0.02 derives from 50 Hz transmission frequency)</param>
        /// <param name="heading">heading is a pointpairlist containing estimated north direction. It's used by classify sub-method to calculate the width of the turn</param>
        public static void turnDiscover(PointPairList gyrPPL, PointPairList magPPL, int turnWindow, double minTurn, double turnLimit90_180, int count,PointPairList heading)
        {
            double _gyrVal = gyrPPL[gyrPPL.Count - 1].Y;
            double _oldGyrVal = gyrPPL[gyrPPL.Count - turnWindow].Y;
            double _magVal = magPPL[gyrPPL.Count - 1].Y;
            double _oldMagVal = magPPL[gyrPPL.Count - turnWindow].Y;
            double _diff = _gyrVal - _oldGyrVal;

            //to detect a turn start we must test if the difference between gyrvalue(last gyro value of the window) and oldgyrval (first gyro value of the window) is
            //higher than a min value fixed
            if (_gyrVal > _oldGyrVal)
            {
                if (_diff >= minTurn)
                {
                    //check on start==-1 to store an remenber the start of the turn
                    if (start == -1)
                        start = gyrPPL.Count - turnWindow;
                    if (!activateClassifyer)
                    {
                        if (_diff > maxTurn)
                            maxTurn = _diff;
                    }
                    //turning start detected
                    turningStarted = true;
                }
            }

            //searching for turn stop
            if (_oldGyrVal > _gyrVal)
            {
                //can detect a turn stop only if 2 conditions are satisfied:
                //1)a turn start has been detected 
                //2)the difference is big enougth
                if (_diff <= -mg)
                {
                    if (turningStarted)
                    {
                        turnCounter += 1;
                        stop = gyrPPL.Count;
                        bool _left = true;
                        
                        if (activateClassifyer)
                        {
                            double _rot = 0;
                            //classify the turn, left/right and width
                            classify(heading, start, stop, out _left, out _rot);

                            //eliminating decimal part of the rotation
                            _rot = Math.Floor(_rot);

                            //setting up log string
                            String logString = "";

                            if (_left)
                                logString += "Left ";
                            else
                                logString += "Right ";

                            logString += "turn ";
                            logString += "of " + _rot + "° , ";
                            logString += "n° " + turnCounter + " \t";
                            logString += "at " + count * 0.02 + " seconds \r\n";

                            //adding string to log
                            Prog.mf.addText(logString,1);
                        }
                        else
                        {
                            bool _rot180 = false;
                            if (_oldMagVal > _magVal)
                                _left = false;
                            if (maxTurn >= turnLimit90_180)
                                _rot180 = true;
                            if ((_left == false) & (_rot180 == true))
                                Prog.mf.addText("Turn n°" + turnCounter + " right 180° \t\t ", 1);
                                //Prog.mf.addText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Turn n°" + turnCounter + " right 180°" +"[" + comHandler.count.ToString() + "] \r\n");   //girata a destra di 180
                            if ((_left == false) & (_rot180 == false))
                                Prog.mf.addText("Turn n°" + turnCounter + " right 90° \t\t ", 1);
                                //Prog.mf.addText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Turn n°" + turnCounter + " right 90°" + "[" + comHandler.count.ToString() + "] \r\n");   //girata a destra di 90
                            if ((_left == true) & (_rot180 == true))
                                Prog.mf.addText("Turn n°" + turnCounter + " left 180° \t\t ", 1);
                                //Prog.mf.addText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Turn n°" + turnCounter + " left 180°" + "[" + comHandler.count.ToString() + "] \r\n");   //girata a sinistra di 180
                            if ((_left == true) & (_rot180 == false))
                                Prog.mf.addText("Turn n°" + turnCounter + " left 90° \t\t ", 1);
                                //Prog.mf.addText("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + "Turn n°" + turnCounter + " left 90°"  + "[" + comHandler.count.ToString() + "] \r\n");   //girata a sinistra di 90
                        }

                        //resetting vars
                        turningStarted = false;

                        #region draw lines indicating start and stop of turn recognition

                        //lines are invisible until user decides to show them using the combobox into the main form.
                        //the combo box enables when all samples has been received.
                        stop = gyrPPL.Count - 1;

                        Prog.mf.zgGir.GraphPane.AddCurve("Turn start " + turnCounter, new double[] { start, start }, new double[] { 5, 6 }, Color.BlueViolet, SymbolType.Triangle);
                        Prog.mf.zgGir.GraphPane.AddCurve("Turn stop " + turnCounter, new double[] { stop, stop }, new double[] { 5, 6 }, Color.Aqua, SymbolType.TriangleDown);

                        start = stop = -1;

                        //hiding curves
                        Prog.mf.zgGir.GraphPane.CurveList[Prog.mf.zgGir.GraphPane.CurveList.Count - 1].IsVisible = false;
                        Prog.mf.zgGir.GraphPane.CurveList[Prog.mf.zgGir.GraphPane.CurveList.Count - 2].IsVisible = false;
                        //hiding legend items
                        Prog.mf.zgGir.GraphPane.CurveList[Prog.mf.zgGir.GraphPane.CurveList.Count - 2].Label.IsVisible = false;
                        Prog.mf.zgGir.GraphPane.CurveList[Prog.mf.zgGir.GraphPane.CurveList.Count - 1].Label.IsVisible = false;
                        #endregion
                    }
                }
            }
        }


        /// <summary>
        /// classify function focus on the calssification of turns made by receiving in input the heading pointpairlistand the
        /// indexes of start and stop of the turn.
        /// This function has a void return tipe but still gives output using out params. The out params are : a bool to define if the turn made was left or right
        /// and a double that defines the width of the turn.
        /// </summary>
        /// <param name="heading">pointpairlist contatining the heading</param>
        /// <param name="start">turn start index</param>
        /// <param name="stop">turn stop index</param>
        /// <param name="left">out parameter, defines if a turn was left (true) or right (false)</param>
        /// <param name="rot">out parameter, defines the width of the turn</param>
        private static void classify(PointPairList heading, int start, int stop, out bool left, out double rot) {
            //make a copy of heading
            PointPairList _ppl = new PointPairList(heading);

            //removing part that is useless (part before turn start)
            _ppl.RemoveRange(0, start);

            //searching for jumps of type 0-360 or 360-0 and saving indexes of the jumps (will fix later)
            bool _jump = false;
            //list of indexes of jumps
            List<int> _jumpI = new List<int>();

            for (int i = 0; i < _ppl.Count-1; i++) {
                if (Math.Abs(_ppl[i].Y - _ppl[i + 1].Y) > 350)
                {
                    _jump = true;
                    _jumpI.Add(i);
                    _jumpI.Add(i + 1);
                }
            }

            //make a copy
            PointPairList _pplC = new PointPairList(_ppl);

            //fix jumps, testing on old list & fixing on new list
            //to fix jumps two steps are done:
            //1)identify the jump -> code above
            //2)fix the  jump by adding 360 before or after the jump depending on case
            if (_jump) {
                for (int i = 0; i < _jumpI.Count; i+=2) {
                    //360-0 case
                    if (_ppl[_jumpI[i]].Y > _ppl[_jumpI[i + 1]].Y) {
                        for (int j = _jumpI[i+1]; j < _ppl.Count; j++)
                            _pplC[j].Y += 360;
                    } else {
                        //0-360 case
                        for (int j = _jumpI[i]; j >= 0; j--)
                            _pplC[j].Y += 360;
                    }
                } 
            }

            //removing old copy
            _ppl = null;
            _ppl = new PointPairList();

            //fixing errors -> no increments or decrements between consecutive samples of more than 5°
            //creating a new pointpairlist with values that satisfy above condition
            for (int i = 0; i < _pplC.Count - 1; i++)
            {
                //last pair check & break
                if (i == _pplC.Count - 2 && Math.Abs(_pplC[i].Y - _pplC[i + 1].Y) < 5)
                {
                    _ppl.Add(_ppl.Count, _pplC[i].Y);
                    _ppl.Add(_ppl.Count, _pplC[i + 1].Y);
                    break;
                }
                if (Math.Abs(_pplC[i].Y - _pplC[i + 1].Y) < 5)
                    _ppl.Add(_ppl.Count, _pplC[i].Y);
            }

            //defining if turn is left or right
            if(_ppl[0].Y < _ppl[_ppl.Count-1].Y)
                left = true;
            else
                left = false;

            //defining width of turn
            rot = Math.Abs(_ppl[0].Y - _ppl[_ppl.Count-1].Y);

            _ppl = null;
            _pplC = null;
        }
    }
}