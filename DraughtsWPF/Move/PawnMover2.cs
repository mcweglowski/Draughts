using DraughtsGame;
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

namespace DraughtsWPF.Move
{
    class PawnMover2
    {
        private Canvas Canvas { get; set; }
        private ICheesboardFieldCoordinates sourceFieldCoordinates = CheesboardFieldCoordinates.Null;
        public IDraughtsEngine draughtsEngine { get; set; }

        public PawnMover2(Canvas canvas)
        {
            Canvas = canvas;
        }

        public void MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CheesboardFieldGraphic field = sender as CheesboardFieldGraphic;
            Point point = e.GetPosition((UIElement)sender);
            // ExecuteHitTest(point);

            if (CheesboardFieldCoordinates.Null == sourceFieldCoordinates)
            {
                sourceFieldCoordinates = field.CheesboardFieldCoordinates;
            }
            else
            {
                if (true == draughtsEngine.Move(sourceFieldCoordinates, field.CheesboardFieldCoordinates))
                {
                    // move item
                }

                sourceFieldCoordinates = CheesboardFieldCoordinates.Null;
            }

        }



        //private List<DependencyObject> hitResultsList = new List<DependencyObject>();

        //public void ExecuteHitTest(Point point)
        //{
        //    hitResultsList.Clear();

        //    System.Windows.Media.VisualTreeHelper.HitTest(Canvas,
        //        null,
        //        new System.Windows.Media.HitTestResultCallback(HitTestResult),
        //        new System.Windows.Media.PointHitTestParameters(point));

        //    CheesboardFieldGraphic field = hitResultsList.Where(i => i.GetType() == typeof(CheesboardFieldGraphic)).Cast<CheesboardFieldGraphic>().FirstOrDefault();

        //    if (null == field)
        //    {
        //        return;
        //    }

        //    if (CheesboardFieldCoordinates.Null == sourceFieldCoordinates)
        //    {
        //        sourceFieldCoordinates = field.CheesboardFieldCoordinates;
        //        return;
        //    }

        //    if (true == draughtsEngine.Move(sourceFieldCoordinates, field.CheesboardFieldCoordinates))
        //    {
        //        bool bMove = true;
        //        bMove = false;
        //    }

        //    sourceFieldCoordinates = CheesboardFieldCoordinates.Null;
        //}

        //public System.Windows.Media.HitTestResultBehavior HitTestResult(System.Windows.Media.HitTestResult result)
        //{
        //    hitResultsList.Add(result.VisualHit);

        //    return System.Windows.Media.HitTestResultBehavior.Continue;
        //}

    }
}
