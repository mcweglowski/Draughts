using DraughtsGame;
using DraughtsGame.Interfaces;
using DraughtsWPF.CheesboardGraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DraughtsWPF.CheesboardDrawTools
{
    public class CheesboardDrawer : IWPFDrawer
    {
        public ICheesboard Cheesboard { get; }
        private SolidColorBrush solidBlackBrush = new SolidColorBrush(Colors.LightGray);
        private SolidColorBrush solidWhiteBrush = new SolidColorBrush(Colors.White);
        public CheesboardDrawer(ICheesboard cheesboard)
        {
            Cheesboard = cheesboard;
        }

        public void Draw(Canvas canvas)
        {
            int fieldsInEdge = Cheesboard.GetCheesboardWidth();

            double edgeWidth = canvas.Width / Cheesboard.GetCheesboardWidth();
            SolidColorBrush currentBrush = solidWhiteBrush;

            for (int row = 0; row < Cheesboard.GetCheesboardWidth(); row++)
            {
                for (int column = 0; column < Cheesboard.GetCheesboardHeight(); column++)
                {
                    ICheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates((CheesboardRow)row, (CheesboardColumn)column);
                    FieldColor fieldColor = Cheesboard.GetFieldColor(cheesboardFieldCoordinates);
                    currentBrush = GetCurrentBrush(fieldColor);

                    CheesboardFieldGraphic cheesboardFieldGraphic = new CheesboardFieldGraphic();
                    cheesboardFieldGraphic.EdgeWidth = edgeWidth;
                    cheesboardFieldGraphic.Fill = currentBrush;
                    cheesboardFieldGraphic.CheesboardFieldCoordinates = cheesboardFieldCoordinates;

                    canvas.Children.Add(cheesboardFieldGraphic);
                    Canvas.SetLeft(cheesboardFieldGraphic, column * edgeWidth);
                    Canvas.SetTop(cheesboardFieldGraphic, row * edgeWidth);

                }
            }

            DrawBorder(canvas);
        }

        private void DrawBorder(Canvas canvas)
        {
            Rectangle border = new Rectangle();
            border.Width = canvas.Width;
            border.Height = canvas.Width;
            border.Stroke = solidBlackBrush;
            canvas.Children.Add(border);
            Canvas.SetTop(border, 0);
            Canvas.SetLeft(border, 0);
        }

        private SolidColorBrush GetCurrentBrush(FieldColor fieldColor)
        {
            switch (fieldColor)
            {
                case FieldColor.Black:
                {
                    return solidBlackBrush;
                }
                case FieldColor.White:
                {
                    return solidWhiteBrush;
                }
                default:
                {
                    throw new Exception("Not defined cheesboard field color.");
                }
            }
        }
    }
}
