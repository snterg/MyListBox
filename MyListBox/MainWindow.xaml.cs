﻿using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<String> results;
        public class Values
        {
            public double xStart { get; set; }
            public double xStop { get; set; }
            public int step { get; set; }
            private int n;


            public int N
            {
                get { return n; }
                set
                {
                    //if (value < 5)  throw new ArgumentException("Value must be greater than 5"); 
                    n = value;
                }
            }

        }
        Values values;


        public MainWindow()
        {
            InitializeComponent();
            values = new Values();
            grid.DataContext = values;
            results = new ObservableCollection<string>();
            lResults.DataContext = results;
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            double summa = 0;
            values.xStart = double.Parse(xStart.Text);
            values.xStop = double.Parse(xStop.Text);
            values.step = int.Parse(step.Text);
            values.N = int.Parse(n.Text);
            double yXStart = -1 / 2 * Math.Log(1 - 2 * values.xStart * Math.Cos(Math.PI / 3) + Math.Pow(values.xStart, 2));

            for (var k = 1; k < values.N; k++)
            {
                summa += (Math.Pow(values.xStart, k) * Math.Cos(k * Math.PI / 3)) / 3;
                results.Add("Summa: " + summa);
            }

            summa = 0;
        }
    }
}