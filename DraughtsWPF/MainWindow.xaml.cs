using DraughtsGame;
using DraughtsGame.Interfaces;
using DraughtsWPF.CheesboardDrawTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DraughtsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDraughtsEngine draughtsGame;
        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            draughtsGame = new DraughtsEngine();
            draughtsGame.Cheesboard = new Cheesboard();
            draughtsGame.AddInitializer(new CheesboardInitializer());
            draughtsGame.AddInitializer(new DraughtsGameTwoRowsInitializer());
            draughtsGame.InitializeGame();
        }

        private void BtnResetGame_Click(object sender, RoutedEventArgs e)
        {
            CheesboardDrawer cheesboardDrawer = new CheesboardDrawer(draughtsGame.Cheesboard);
            cheesboardDrawer.Draw(canvas);

            PawnsDrawer pawnsDrawer = new PawnsDrawer(draughtsGame.Cheesboard);
            pawnsDrawer.Draw(canvas);
        }
    }
}
