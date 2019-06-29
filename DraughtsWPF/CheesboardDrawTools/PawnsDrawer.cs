using DraughtsGame;
using DraughtsGame.Interfaces;
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
    public class PawnsDrawer
    {
        private ICheesboard Cheesboard { get; set; }
        private SolidColorBrush solidRedBrush = new SolidColorBrush(Colors.IndianRed);
        private SolidColorBrush solidWhiteBrush = new SolidColorBrush(Colors.White);

        public PawnsDrawer(ICheesboard cheesboard)
        {
            Cheesboard = cheesboard;
        }

        public void Draw(Canvas canvas)
        {
            int fieldsInEdge = Cheesboard.GetCheesboardWidth();
            double edgeWidth = canvas.Width / Cheesboard.GetCheesboardWidth();
            double diameter = edgeWidth * 0.85;
            double pawnMargin = (edgeWidth - diameter) / 2;

            for (int row = 0; row < Cheesboard.GetCheesboardWidth(); row++)
            {
                for (int column = 0; column < Cheesboard.GetCheesboardHeight(); column++)
                {
                    ICheesboardFieldCoordinates cheesboardFieldCoordinates = new CheesboardFieldCoordinates((CheesboardRow)row, (CheesboardColumn)column);
                    IPawn pawn = Cheesboard.GetPawn(cheesboardFieldCoordinates);

                    if (Pawn.Null == pawn)
                    {
                        continue;
                    }

                    PlayerColor playerColor = pawn.GetPlayerColor();
                    SolidColorBrush currentBrush = GetCurrentBrush(playerColor);

                    Ellipse pawnGraphic = new Ellipse();
                    pawnGraphic.Width = diameter;
                    pawnGraphic.Height = diameter;
                    pawnGraphic.Fill = currentBrush;

                    canvas.Children.Add(pawnGraphic);
                    Canvas.SetLeft(pawnGraphic, column * edgeWidth + pawnMargin);
                    Canvas.SetTop(pawnGraphic, row * edgeWidth + pawnMargin);
                }
            }
        }

        private SolidColorBrush GetCurrentBrush(PlayerColor playerColor)
        {
            switch (playerColor)
            {
                case PlayerColor.Red:
                    {
                        return solidRedBrush;
                    }
                case PlayerColor.White:
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