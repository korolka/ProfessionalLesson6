using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Reflector
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Assembly assembly;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenItem_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.ShowDialog(this);
                string path = openFile.FileName;
                assembly = Assembly.LoadFrom(path);
                stringBuilder.Append("СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine);
                text.Text = stringBuilder.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            stringBuilder.Append("СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine);
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                stringBuilder.Append("Тип:  " + type + Environment.NewLine);
                var methods = type.GetMethods();
                if (methods != null)
                {
                    foreach (var method in methods)
                    {
                        string methStr = "Метод:" + method.Name + "\n";
                        var methodBody = method.GetMethodBody();
                        if (methodBody != null)
                        {
                            var byteArray = methodBody.GetILAsByteArray();

                            foreach (var b in byteArray)
                            {
                                methStr += b + ":";
                            }
                        }
                        stringBuilder.Append(methStr + Environment.NewLine);
                    }
                }
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
