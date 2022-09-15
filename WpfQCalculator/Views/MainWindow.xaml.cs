using System.Windows;
using WpfQCalculator.ViewModels;

namespace WpfQCalculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}