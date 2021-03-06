﻿using DraughtsGame;
using DraughtsGame.Interfaces;
using DraughtsWPF.CheesboardDrawTools;
using DraughtsWPF.CheesboardGraphicElements;
using DraughtsWPF.DiagnosticTools;
using DraughtsWPF.Move;
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

            lblActivePlayer.Content = draughtsGame.ActivePlayer.ToString();
        }

        private void BtnResetGame_Click(object sender, RoutedEventArgs e)
        {
            IList<IWPFDrawer> drawers = new List<IWPFDrawer>()
            {
                new CheesboardDrawer(draughtsGame.Cheesboard),
                new PawnsDrawer(draughtsGame.Cheesboard),
            };

            foreach (IWPFDrawer drawer in drawers)
            {
                drawer.Draw(canvas);
            }

            CoordinatesReader coordinatesReader = new CoordinatesReader();
            coordinatesReader.Display = lblCurrentCoordinates;

            foreach (UIElement element in canvas.Children)
            {
                element.MouseEnter += coordinatesReader.MouseEnter;
            }


            PawnMover2 pm2 = new PawnMover2(canvas);
            pm2.draughtsEngine = draughtsGame;

            foreach (UIElement element in canvas.Children)
            {
                if (element is CheesboardFieldGraphic)
                {
                    element.MouseLeftButtonUp += pm2.MouseLeftButtonUp;
                }
            }
        }
    }
}
