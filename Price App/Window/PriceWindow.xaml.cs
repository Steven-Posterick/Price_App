using System.Windows;
using Price_App.ViewModel;

namespace Price_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PriceWindow : Window
    {
        public PriceWindow(PriceViewModel priceViewModel)
        {
            InitializeComponent();
            DataContext = priceViewModel;
        }
    }
}