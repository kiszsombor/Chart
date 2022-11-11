using System.Windows.Controls;

namespace WpfApp2.Views.MultiAxesCharts
{
    /// <summary>
    /// Interaction logic for MultiAxesChart.xaml
    /// </summary>
    public partial class MultiAxesChart : UserControl
    {
        public MultiAxesChart()
        {
            InitializeComponent();

            DataContext = new ViewModels.MultiAxesCharts.MultiAxesChartViewModel();
        }
    }
}
