using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace ProgettoAdminReteFinal
{
    /// <summary>
    /// Class dedicated to graph handling (creation, refresh, clear and modify)
    /// </summary>
    class graphHandler
    {
        /**enclose all elements associated to a graph*/
        public static GraphPane pane;

        /// <summary>
        /// graphHandler constructor, used to construct accelerometer gyroscope and magnetometer graphs
        /// </summary>
        /// <param name="zgc">Name of the control</param>
        /// <param name="title">Title of the graph</param>
        /// <param name="titleX">Graph title on x axis</param>
        /// <param name="titleY">Graph title on y axis</param>
        public graphHandler(ZedGraphControl zgc, string title, string titleX, string titleY)
        {
            pane = zgc.GraphPane;

            pane.Title.FontSpec.Size = 25;
            pane.YAxis.Title.FontSpec.Size = 20;
            pane.XAxis.Title.FontSpec.Size = 20;
            pane.Legend.FontSpec.Size = 20;
            pane.Title.Text = title;
            pane.YAxis.Title.Text = titleY;
            pane.XAxis.Title.Text = titleX;
            pane.AddCurve("pelvis", new PointPairList(), Color.Blue, SymbolType.Circle);            // -> [0]
            pane.AddCurve("right wrist", new PointPairList(), Color.DarkOrange, SymbolType.Circle);  // -> [1]
            pane.AddCurve("left wrist", new PointPairList(), Color.OrangeRed, SymbolType.Circle);  // -> [2]
            pane.AddCurve("right ankle", new PointPairList(), Color.DarkGreen, SymbolType.Circle);  // -> [3]
            pane.AddCurve("left ankle", new PointPairList(), Color.YellowGreen, SymbolType.Circle); // -> [4]
        }

        /// <summary>
        /// graphHandler constructor, used to construct one-line graphs such as standard deviation graph accelerometer x axis graphs
        /// </summary>
        /// <param name="zgc">Name of the control</param>
        /// <param name="title">Title of the graph</param>
        /// <param name="titleX">Graph title on x axis</param>
        /// <param name="titleY">Graph title on y axis</param>
        /// <param name="label">Name of the curve</param>
        public graphHandler(ZedGraphControl zgc, string title, string titleX, string titleY, string label)
        {
            pane = zgc.GraphPane;

            pane.Title.FontSpec.Size = 25;
            pane.YAxis.Title.FontSpec.Size = 20;
            pane.XAxis.Title.FontSpec.Size = 20;
            pane.Legend.FontSpec.Size = 20;
            pane.Title.Text = title;
            pane.YAxis.Title.Text = titleY;
            pane.XAxis.Title.Text = titleX;
            pane.AddCurve(label, new PointPairList(), Color.Blue);
        }

        /// <summary>
        /// Draw method for 5-lines graphs (accelerometer gyroscope and magnetometer graphs) 
        /// </summary>
        /// <param name="zgc">Name of the control/component where we are going to add data</param>
        /// <param name="data">Source of the data</param>
        /// <param name="smoothWin">Smoothing window dimension</param>
        public static void draw(ZedGraphControl zgc, List<PointPairList> data, int smoothWin)
        {
            //adding point to curves, point added is:
            //X -> data[i][data[i].Count -smoothWin - 1].X -> a counter
            //Y -> data[i][data[i].Count -smoothWin - 1].Y -> moduled & smoothed value
            zgc.GraphPane.CurveList[0].AddPoint(data[0][data[0].Count -smoothWin - 1].X, data[0][data[0].Count -smoothWin - 1].Y);
            zgc.GraphPane.CurveList[1].AddPoint(data[1][data[1].Count -smoothWin - 1].X, data[1][data[1].Count -smoothWin - 1].Y);
            zgc.GraphPane.CurveList[2].AddPoint(data[2][data[2].Count -smoothWin - 1].X, data[2][data[2].Count -smoothWin - 1].Y);
            zgc.GraphPane.CurveList[3].AddPoint(data[3][data[3].Count -smoothWin - 1].X, data[3][data[3].Count -smoothWin - 1].Y);
            zgc.GraphPane.CurveList[4].AddPoint(data[4][data[4].Count -smoothWin - 1].X, data[4][data[4].Count -smoothWin - 1].Y);

            //refreshing graph and updating axis
            if (zgc.InvokeRequired)
                zgc.Invoke((MethodInvoker)delegate() { 
                    zgc.Refresh();
                    zgc.AxisChange();
                });
            else
            {
                zgc.Refresh();
                zgc.AxisChange();
            }
        }

        /// <summary>
        /// Draw method for single-line graphs (accelerometer x axis , standard deviation)
        /// </summary>
        /// <param name="zgc">Name of the control/component where we are going to add data</param>
        /// <param name="data">Source of the data</param>
        /// <param name="smoothWin">Smoothing window dimension</param>
        public static void draw(ZedGraphControl zgc, PointPairList data, int smoothWin)
        {
            //adding point to curve, point added is:
            //X -> data[data.Count -smoothWin - 1].X -> a counter
            //Y -> data[data.Count -smoothWin - 1].Y -> smoothed values of pelvis accelerometer x axis or calculated standard deviation values
            zgc.GraphPane.CurveList[0].AddPoint(data[data.Count -smoothWin - 1].X, data[data.Count -smoothWin - 1].Y);

            //refreshing graph and updating axis
            if (zgc.InvokeRequired)
                zgc.Invoke((MethodInvoker)delegate()
                {
                    zgc.Refresh();
                    zgc.AxisChange();
                });
            else
            {
                zgc.Refresh();
                zgc.AxisChange();
            }
        }

        /// <summary>
        /// Method used to draw points that are not drawn yet when the reading loop ends
        /// </summary>
        /// <param name="zgc">Name of the control where we are going to add data</param>
        /// <param name="data">Source of the data</param>
        /// <param name="count">Number of points read</param>
        public static void drawLast(ZedGraphControl zgc, List<PointPairList> data, int count) 
        {
            //finding last point draw
            int _nPts = zgc.GraphPane.CurveList[0].NPts;
            //number of points to draw
            int _toDraw = count - _nPts -1;

            //adding points to curves
            for (int i = 0; i < _toDraw; i++)
            {
                zgc.GraphPane.CurveList[0].AddPoint(data[0][_nPts + i].X, data[0][_nPts + i].Y);
                zgc.GraphPane.CurveList[1].AddPoint(data[1][_nPts + i].X, data[1][_nPts + i].Y);
                zgc.GraphPane.CurveList[2].AddPoint(data[2][_nPts + i].X, data[2][_nPts + i].Y);
                zgc.GraphPane.CurveList[3].AddPoint(data[3][_nPts + i].X, data[3][_nPts + i].Y);
                zgc.GraphPane.CurveList[4].AddPoint(data[4][_nPts + i].X, data[4][_nPts + i].Y);
            }

            //invoke test to fix crossthread calls
            if(zgc.InvokeRequired){
                zgc.Invoke((MethodInvoker)delegate()
                {
                    zgc.Refresh();
                });
            }else
                zgc.Refresh();
        }

        /// <summary>
        /// Method used to draw points that are not drawn yet when the reading loop ends - version for one-line graphs
        /// </summary>
        /// <param name="zgc">Name of the zedGraphControl where we are going to add data</param>
        /// <param name="data">Source of the data</param>
        /// <param name="count">Number of points read</param>
        public static void drawLast(ZedGraphControl zgc, PointPairList data, int count)
        {
            //finding last point draw
            int _nPts = zgc.GraphPane.CurveList[0].NPts;
            //number of points to draw
            int _toDraw = count - _nPts - 1;

            for (int i = 0; i < _toDraw; i++)
                zgc.GraphPane.CurveList[0].AddPoint(data[_nPts + i].X, data[_nPts + i].Y);

            //invoke test to fix crossthread calls
            if (zgc.InvokeRequired)
            {
                zgc.Invoke((MethodInvoker)delegate()
                {
                    zgc.Refresh();
                    zgc.AxisChange();
                });
            }
            else
            {
                zgc.Refresh();
                zgc.AxisChange();
            }
        }

        /// <summary>
        /// Method to show/hide lines in graphs.
        /// </summary>
        /// <param name="sender">Identifies the checkbox that has been checked/unckecked</param>
        /// <param name="e"> Unused -- Arguments of the event:click position and button click</param>
        public static void stateChanged(object sender, EventArgs e)
        {
            //checking sender to identify the checkbox that changed state
            switch (((CheckBox)sender).Name)
            {
                case "cbPelvis":
                    Prog.mainForm.zedgraphAccelerometer.GraphPane.CurveList[0].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[0].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphMagnetometer.GraphPane.CurveList[0].IsVisible = ((CheckBox)sender).Checked;
                    break;
                case "cbRightWrist":
                    Prog.mainForm.zedgraphAccelerometer.GraphPane.CurveList[1].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[1].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphMagnetometer.GraphPane.CurveList[1].IsVisible = ((CheckBox)sender).Checked;
                    break;
                case "cbLeftWrist":
                    Prog.mainForm.zedgraphAccelerometer.GraphPane.CurveList[2].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[2].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphMagnetometer.GraphPane.CurveList[2].IsVisible = ((CheckBox)sender).Checked;
                    break;
                case "cbRightAnkle":
                    Prog.mainForm.zedgraphAccelerometer.GraphPane.CurveList[3].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[3].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphMagnetometer.GraphPane.CurveList[3].IsVisible = ((CheckBox)sender).Checked;
                    break;
                case "cbLeftAnkle":
                    Prog.mainForm.zedgraphAccelerometer.GraphPane.CurveList[4].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[4].IsVisible = ((CheckBox)sender).Checked;
                    Prog.mainForm.zedgraphMagnetometer.GraphPane.CurveList[4].IsVisible = ((CheckBox)sender).Checked;
                    break;
            }

            //redraw graphs. axischange call to adapt graph axis to new visible curveset
            Prog.mainForm.zedgraphAccelerometer.AxisChange();
            Prog.mainForm.zedgraphGyroscope.AxisChange();
            Prog.mainForm.zedgraphMagnetometer.AxisChange();
            Prog.mainForm.zedgraphAccelerometer.Refresh();
            Prog.mainForm.zedgraphGyroscope.Refresh();
            Prog.mainForm.zedgraphMagnetometer.Refresh();
        }

        /// <summary>
        /// Combo box turnStartStopShow state changed event handler, it gives the user the possibility to show/hide
        /// vertical lines indicating start and stop of turns
        /// </summary>
        /// <param name="sender">Identifies the checkbox that has been checked/unckecked, in this case cbTurnStartStopShow</param>
        /// <param name="e">Unused -- Arguments of the event:click position and button click</param>
        public static void cbTurnStartStopShow_stateChanged(object sender, EventArgs e)
        {
            //if curvelist in greater than 5, we found some turns and added lines to mark turn start and stop
            ////so we go to show/hide (depends on checkbox state) those lines and the corrispondent legend items
            //else if curvelist isn't greater than 5, it means that we didn't found any turn, so nothing to show.
            if (Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList.Count > 5)
            {
                for (int i = 5; i < Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList.Count; i++) {
                        Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[i].IsVisible = ((CheckBox)sender).Checked; // hiding/showing turns start stop detection points 
                        Prog.mainForm.zedgraphGyroscope.GraphPane.CurveList[i].Label.IsVisible = ((CheckBox)sender).Checked; // hiding/showing legend items of turns start stop detection points
                }

                //redraw graph.
                Prog.mainForm.zedgraphGyroscope.AxisChange();
                Prog.mainForm.zedgraphGyroscope.Refresh();
            }
        }
    }
}