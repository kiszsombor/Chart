using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System.Collections.Generic;
using System.Windows.Media;
using WpfApp2.Models;

namespace WpfApp2.ViewModels.MultiAxesCharts
{
    public class MultiAxesChartViewModel
    {
        private List<string> labels;

        public MultiAxesChartViewModel()
        {
            labels = new List<string>();

            JsonReader jsonReader = new JsonReader();
            jsonReader.ReadJson();
            List<Data> datas = jsonReader.Data;

            var powers = new ChartValues<ObservableValue>();
            var rpms = new ChartValues<ObservableValue>();
            var vibrations = new ChartValues<ObservableValue>();
            var voltages = new ChartValues<ObservableValue>();

            datas.ForEach(data => {
                powers.Add(new ObservableValue(data.Power));
                rpms.Add(new ObservableValue(data.Rpm));
                vibrations.Add(new ObservableValue(data.Vibration));
                voltages.Add(new ObservableValue(data.Voltage));
                labels.Add(data.TimeMs + " ms");
            });

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Power",
                    Values = powers,
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Title = "Rpm",
                    Values = rpms,
                    ScalesYAt = 1
                },
                new LineSeries
                {
                    Title = "Vibration",
                    Values = vibrations,
                    ScalesYAt = 2
                },
                new LineSeries
                {
                    Title = "Voltage",
                    Values = voltages,
                    // Fill = Brushes.Transparent,
                    ScalesYAt = 3
                }
            };

            AxisYCollection = new AxesCollection
            {
                new Axis { Title = "Power", Foreground = Brushes.Gray },
                new Axis { Title = "Rpm", Foreground = Brushes.Red, Position = AxisPosition.RightTop },
                new Axis { Title = "Vibration", Foreground = Brushes.Brown, Position = AxisPosition.RightTop },
                new Axis { Title = "Voltage", Foreground = Brushes.Blue }
            };
        }

        public AxesCollection AxisYCollection { get; set; }
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get => labels; set => labels = value; }
    }
}
