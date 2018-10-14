﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Task2.Library;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LineDrawingManager drawingManager;
        public MainWindow()
        {
            InitializeComponent();
            drawingManager = new LineDrawingManager();
            LinesDrawer.ItemsSource = drawingManager.polylines;
            List.ItemsSource = drawingManager.polylines;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            List<PolyLine> newLines = new List<PolyLine>();
            if (openFileDialog.ShowDialog() == true)
            {
                newLines = PolyLineIOManager.Load(openFileDialog.FileName).ToList();
            }

            foreach (PolyLine pl in newLines)
            {
                drawingManager.AddPl(pl);
            }
            
        }

        private void Save_as_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            List<PolyLine> newLines = new List<PolyLine>();
            if (saveFileDialog.ShowDialog() == true)
            {
                PolyLineIOManager.Save(drawingManager.polylines, saveFileDialog.FileName);
            }
        }
    }
}
