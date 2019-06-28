using DraughtsWPF.CheesboardGraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DraughtsWPF.DiagnosticTools
{
    public class CoordinatesReader
    {
        public Label Display { get; set; }
        public void MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is CheesboardFieldGraphic)
            {
                CheesboardFieldGraphic field = sender as CheesboardFieldGraphic;
                Display.Content = string.Format("Row: {0} Col: {1}", field.CheesboardFieldCoordinates.Row, field.CheesboardFieldCoordinates.Column);
            }
        }
    }
}
