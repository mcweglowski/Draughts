using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace DraughtsWPF.Move
{
    public class PawnMover
    {
        public bool IsDragInProgress { get; private set; } = false;
        private Canvas canvas;

        public PawnMover(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsDragInProgress = true;

            Shape s = (Shape)sender;
            s.CaptureMouse();
        }

        public void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsDragInProgress = false;

            Shape s = (Shape)sender;
            s.ReleaseMouseCapture();
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (false == IsDragInProgress)
            {
                return;
            }

            var mousePos = e.GetPosition(canvas);

            Shape s = (Shape)sender;
            double left = mousePos.X - (s.ActualWidth / 2);
            double top = mousePos.Y - (s.ActualHeight / 2);
            Canvas.SetLeft(s, left);
            Canvas.SetTop(s, top);
        }
    }
}
