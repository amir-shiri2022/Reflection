using System;
using System.Collections.Generic;
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

namespace Reflection01
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           ShowInformationOfType showInformationOfType = 
               new ShowInformationOfType(typeof(Person));
           ShowInfoTextBox.Text = "-------------------All info of this class" + Environment.NewLine;
           ShowInfoTextBox.Text += showInformationOfType.LoadInformationOfType();
           ShowInfoTextBox.Text += "------------------property of this class" + Environment.NewLine;
           ShowInfoTextBox.Text += showInformationOfType.LoadProperties();
           ShowInfoTextBox.Text += "------------------methods of this class" + Environment.NewLine;
           ShowInfoTextBox.Text += showInformationOfType.LoadMethods();
        }
    }
}
