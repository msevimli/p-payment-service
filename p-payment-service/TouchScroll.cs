using System;
using System.Drawing;
using System.Windows.Forms;

namespace p_payment_service
{
    public class TouchScroll
    {
        private Point mouseDownPoint;
        private FlowLayoutPanel parentPanel;
        private Timer inertiaTimer;
        private Point inertiaScrollDelta;
        private const double inertiaDeceleration = 0.95;
        public TouchScroll(FlowLayoutPanel panel)
        {
            parentPanel = panel;
            AssignEvent(panel);
        }
        private void AssignEvent(Control control)
        {
            control.MouseDown += MouseDown;
            control.MouseMove += MouseMove;
            control.MouseUp += MouseUp;
            foreach (Control child in control.Controls)
            {
                AssignEvent(child);
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Point pointDifference = new Point(Cursor.Position.X + mouseDownPoint.X, Cursor.Position.Y - mouseDownPoint.Y);

            if ((mouseDownPoint.X == Cursor.Position.X) && (mouseDownPoint.Y == Cursor.Position.Y))
                return;

            Point currAutoS = parentPanel.AutoScrollPosition;

            int scrollFactor = 2; // Adjust this value to control the scrolling speed
            Point scrollDelta = new Point(pointDifference.X * scrollFactor, pointDifference.Y * scrollFactor);

            // Apply inertia scrolling if the mouse movement has stopped
            if (inertiaTimer != null)
            {
                inertiaScrollDelta = scrollDelta;
                return;
            }

            parentPanel.AutoScrollPosition = new Point(Math.Abs(currAutoS.X) - scrollDelta.X, Math.Abs(currAutoS.Y) - scrollDelta.Y);
            mouseDownPoint = Cursor.Position;
        }


        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Start the inertia scrolling timer
                inertiaTimer = new Timer();
                inertiaTimer.Interval = 20; // Adjust this value for the desired scrolling smoothness
                inertiaTimer.Tick += InertiaTimer_Tick;
                inertiaTimer.Start();
            }
        }
        private void InertiaTimer_Tick(object sender, EventArgs e)
        {
            Point currAutoS = parentPanel.AutoScrollPosition;

            if (inertiaScrollDelta == null)
                return;

            inertiaScrollDelta = new Point((int)(inertiaScrollDelta.X * inertiaDeceleration), (int)(inertiaScrollDelta.Y * inertiaDeceleration));

            parentPanel.AutoScrollPosition = new Point(Math.Abs(currAutoS.X) - inertiaScrollDelta.X, Math.Abs(currAutoS.Y) - inertiaScrollDelta.Y);

            if (Math.Abs(inertiaScrollDelta.X) < 1 && Math.Abs(inertiaScrollDelta.Y) < 1)
            {
                inertiaTimer?.Stop();
                inertiaTimer?.Dispose();
                inertiaTimer = null;
            }
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.mouseDownPoint = Cursor.Position; 
        }
    }
}
