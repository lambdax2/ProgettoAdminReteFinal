using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using ZedGraph;
using System.Drawing;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class that encloses all the functions that supports the main ones stored into functions class. 
    /// </summary>
    class utilityes
    {
        /// <summary>
        /// Module function.
        /// </summary>
        /// <param name="v1"> First value</param>
        /// <param name="v2"> Second value</param>
        /// <param name="v3"> Third value</param>
        /// <returns>Module of the values</returns>
        public static double module(double v1, double v2, double v3)
        {
            return Math.Sqrt(v1*v1 + v2*v2 + v3*v3);
        }

        /// <summary>
        /// Standard deviation function, calculates the standard deviation from moduled values of pelvis accelerometer, devStd = sqrt(sum{1,N}((x-medValue)^2) / N))
        /// </summary>
        /// <param name="ppl">List of points</param>
        /// <param name="winDimension">Dimension of the window of values on wich we are going to calculate standard deviation</param>
        /// <returns>Standard deviation of values into the window</returns>
        public static double devStd(PointPairList ppl, int winDimension)
        {
            double _average = 0;
            double _devStd = 0;

            _average = average(ppl, winDimension);

            for (int i = 0; i < winDimension; i++)
                _devStd += Math.Pow(ppl[ppl.Count - winDimension + i].Y - _average, 2);

            _devStd = Math.Sqrt(_devStd / (winDimension - 1));

            return _devStd * 10;
        }

        /// <summary>
        /// Average function, calculates the average on last n elements of the pointpairlist passed as parameter.
        /// </summary>
        /// <param name="ppl">List of points</param>
        /// <param name="n">Number of values that will be used to calculate average</param>
        /// <returns>Average of the last n values of the list</returns>
        public static double average(PointPairList ppl, int n)
        {
            double _sum = 0;

            for (int i = ppl.Count - n; i < ppl.Count; i++)
                _sum += ppl[i].Y;

            return _sum / n;
        }

        /// <summary>
        /// magPIFix is a function used to remove discontinuity of magnetometer signal
        /// </summary>/
        /// <param name="mag">Magnetometer values</param>
        /// <param name="index">Index of the magnetometer that has to be fixed in the list</param>
        /// <returns>Fixed list of values</returns>
        public static List<PointPairList> magnetometerDiscontinuityFix(List<PointPairList> mag, int index)
        {
            if (mag[index].Count > 1)
            {
                int i = 0;
                //previous value
                double _y1 = mag[index][mag[index].Count - 2].Y;
                //actual value
                double _y2 = mag[index][mag[index].Count - 1].Y;

                //max 5 iterations.
                while (i < 5)
                {
                    if ((_y1 > 0) && (_y1 - _y2 > 1.0))
                        _y2 += Math.PI;

                    if ((_y1 < 0) && (_y1 - _y2 < -1.0))
                        _y2 -= Math.PI;

                    //if no more condition to do another iteration, break the loop and go on.
                    if (!(Math.Abs(_y1 - _y2) > 1))
                        break;

                    i++;
                }

                //updating value
                mag[index][mag[index].Count - 1].Y = _y2;
            }

            return mag;
        }

        /// <summary>
        /// calculate_heading is a function that is used to determinate the north direction to discover the turn amplitude.
        /// http://www51.honeywell.com/aero/common/documents/myaerospacecatalog-documents/Defense_Brochures-documents/Magnetic__Literature_Application_notes-documents/AN203_Compass_Heading_Using_Magnetometers.pdf
        /// </summary>
        /// <param name="y">y axis</param>
        /// <param name="z">z axis</param>
        /// <returns></returns>
        public static double calculate_heading(double y,double z) {
            double head;

            if (y > 0)
            {
                head = 90 - Math.Atan2(y, z) * 180 / Math.PI;
            }
            else
            {
                if (y < 0)
                    head = 270 - Math.Atan2(y, z) * 180 / Math.PI;
                else
                    if (z < 0)
                        head = 180;
                    else
                        head = 0;
            }

            return head;
        }
    }
}