using System;
using System.Collections.Generic;
using System.IO;
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

namespace Asynkbazi
{
    
    
    public partial class MainWindow : Window
    {
        private FileGet fileGet = new FileGet();
        public MainWindow()
        {
            InitializeComponent();
            Listv.ItemsSource = fileGet.DirectoryGet();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = Listv.SelectedItem as string;
                if (path.Contains("."))
                {
                    fileGet.OpenFile(path);
                }
                else
                {
                    fileGet.ChangePath(path);
                    Listv.ItemsSource = null;
                    Listv.ItemsSource = fileGet.DirectoryGet();
                }
               
            }
            finally
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string fileName = FileNameTextBox.Text;
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
            if (directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
    }
    public class FileGet
    {

        private string _directory = @"C:\\";
        private List<string> _filesList = new List<string>();
        public void ChangePath(string path)
        {
            _directory = path;
        }
        public List<string> DirectoryGet()
        {
            if (Directory.Exists(_directory))
            {
               string[] mass = Directory.GetDirectories(_directory);   
                foreach (string file in mass)
                {
                    _filesList.Add(file);
                }
                string[] mass1 = Directory.GetFiles(_directory);
                foreach (string file in mass1)
                {
                    _filesList.Add(file);
                }
            }
            return _filesList;
        }
        public void OpenFile(string path)
        {
            System.Diagnostics.Process.Start(path);

        }


    }





}
