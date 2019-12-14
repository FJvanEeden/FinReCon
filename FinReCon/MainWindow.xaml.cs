using System;
using System.Windows;

namespace FinReCon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
        }

        public void UpdateTextBoxListA(string text)
        {
            resultsTextBoxListA.AppendText(text);
        }

        public void UpdateTextBoxListB(string text)
        {
            resultsTextBoxListB.AppendText(text);
        }

        public void UpdateTextBoxListFinal(string text)
        {
            resultsTextBoxListFinal.AppendText(text);
        }

        public void browseButton_1_Click(object sender, RoutedEventArgs e)
        {
            String myPathCSV = FileBrowser.BrowseFile();
            FileNameTextBox1.Text = myPathCSV;
            DataControler.firstSelectedPath = myPathCSV;
        }

        public void browseButton_2_Click(object sender, RoutedEventArgs e)
        {
            String myPathCSV = FileBrowser.BrowseFile();
            FileNameTextBox2.Text = myPathCSV;
            DataControler.secondSelectedPath = myPathCSV;
        }

        private void compareButton_Click(object sender, RoutedEventArgs e)
        {
            DataControler.DataProcessor();
        }
    }
}
