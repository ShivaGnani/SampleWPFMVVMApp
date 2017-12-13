using System;
using System.Windows;

namespace SampleWPFMVVMApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void newTask_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action( () => { string x = NewTaskTextBox.Text; }));
        }
    }
}
