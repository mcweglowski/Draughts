using DraughtsGame.Interfaces;
using DraughtsWPF.CheesboardGraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DraughtsWPF.Move
{
    public class PawnMover
    {
        public bool IsDragInProgress { get; private set; } = false;
        private Canvas canvas;
        public Label ActivePlayer { get; set; }
        public IDraughtsEngine draughtsEngine { get; set; }
        private ICheesboardFieldCoordinates sourceField { get; set; }

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
            Point hitTest = e.GetPosition(canvas);
            HitTestResult result = VisualTreeHelper.HitTest(canvas, hitTest);
            if (result != null)
            {
                MessageBox.Show(result.VisualHit.GetType().ToString());
            }



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

        public void MouseEnter(object sender, MouseEventArgs e)
        {
            if (true == IsDragInProgress)
            {
                return;
            }

            if (sender is CheesboardFieldGraphic)
            {
                CheesboardFieldGraphic field = sender as CheesboardFieldGraphic;
                sourceField = field.CheesboardFieldCoordinates;
            }
        }

        internal void Drop(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DragEnter(object sender, DragEventArgs e)
        {
            if (sender is CheesboardFieldGraphic)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        internal void DragOver(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
