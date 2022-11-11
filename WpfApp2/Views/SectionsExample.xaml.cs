using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp2.Models;
using System.Collections.Generic;

namespace WpfApp2.Views.Sections
{
    public partial class SectionsExample : UserControl
    {
        public SectionsExample()
        {
            InitializeComponent();

            JsonReader jsonReader = new JsonReader();
            jsonReader.ReadJson();
            List<Data> datas = jsonReader.Data;

            var powers = new ChartValues<ObservableValue>();
            var rpms = new ChartValues<ObservableValue>();
            var vibrations = new ChartValues<ObservableValue>();
            var voltages = new ChartValues<ObservableValue>();
            var timeMses = new ChartValues<ObservableValue>();

            datas.ForEach(data => { 
                powers.Add(new ObservableValue(data.Power));
                rpms.Add(new ObservableValue(data.Rpm));
                vibrations.Add(new ObservableValue(data.Vibration));
                voltages.Add(new ObservableValue(data.Voltage));
                timeMses.Add(new ObservableValue(data.TimeMs));
            });

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = powers,
                    PointGeometrySize = 0,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Values = rpms,
                    PointGeometrySize = 0,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Values = vibrations,
                    PointGeometrySize = 0,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                },
                new LineSeries
                {
                    Values = voltages,
                    PointGeometrySize = 0,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                }
            };

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }

        private void UpdateAllOnClick(object sender, RoutedEventArgs e)
        {
            var r = new Random();

            foreach (var series in SeriesCollection)
            {
                foreach (var observable in series.Values.Cast<ObservableValue>())
                {
                    observable.Value = r.Next(0, 10);
                }
            }
        }
    }
}
