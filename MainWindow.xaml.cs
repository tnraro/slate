using System.Windows;

namespace slate;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    void button_Click(object sender, RoutedEventArgs e)
    {
        App.PlaySound();
    }
}