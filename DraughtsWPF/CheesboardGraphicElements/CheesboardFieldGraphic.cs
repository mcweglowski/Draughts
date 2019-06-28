using DraughtsGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DraughtsWPF.CheesboardGraphicElements
{
    public class CheesboardFieldGraphic : Shape
    {
        public ICheesboardFieldCoordinates CheesboardFieldCoordinates { get; set; }
        public double EdgeWidth { get; set; }
        protected override Geometry DefiningGeometry { get { return DrawRectangle(); } }
        private Geometry DrawRectangle()
        {
            StreamGeometry streamGeometry = new StreamGeometry();

            using (StreamGeometryContext streamGeometryContext = streamGeometry.Open())
            {
                streamGeometryContext.BeginFigure(new Point(0, 0), isFilled: true, isClosed: true);
                streamGeometryContext.LineTo(new Point(EdgeWidth, 0), isStroked: false, isSmoothJoin: false);
                streamGeometryContext.LineTo(new Point(EdgeWidth, EdgeWidth), isStroked: false, isSmoothJoin: false);
                streamGeometryContext.LineTo(new Point(0, EdgeWidth), isStroked: false, isSmoothJoin: false);
            }

            streamGeometry.Freeze();

            return streamGeometry;
        }
    }
}
