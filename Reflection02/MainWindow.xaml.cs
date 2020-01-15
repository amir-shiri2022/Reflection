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
using ReflectionLibrary;

namespace Reflection02
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
            //without add assembly into project
            //Assembly getAssembly = Assembly.LoadFile(@"C:\Users\Amir\source\repos\Reflection\ReflectionLibrary\bin\Debug\netcoreapp3.1\ReflectionLibrary.dll");

            Assembly getAssembly = typeof(IRepository<>).Assembly;

            ShowInfoTextBox.Text = "-------------------List of type" + Environment.NewLine;
            foreach (var type in getAssembly.GetExportedTypes())
            {
                ShowInformationOfType showInformationOfType =
                    new ShowInformationOfType(type);

                ShowInfoTextBox.Text += "-------------------All info of this class" + Environment.NewLine;
                ShowInfoTextBox.Text += showInformationOfType.LoadInformationOfType();
            }
            //set value to property
            var typeOfStudent = getAssembly.ExportedTypes.FirstOrDefault(p => p.Name == "Student");
            var instanceOfStudent = Activator.CreateInstance(typeOfStudent);
            typeOfStudent.GetProperty("University")?.SetValue(instanceOfStudent,"Colgn");

            //make generic repository of student and fire add method
            var typeOfRepo = getAssembly.ExportedTypes.FirstOrDefault(p => p.Name == "Repository`1");
            var repoGeneric = typeOfRepo.MakeGenericType(typeOfStudent);
            var instanceOfRepository = Activator.CreateInstance(repoGeneric);
            var addMethod = repoGeneric.GetMethod("Add");

           ShowInfoTextBox.Text +=
           addMethod.Invoke(instanceOfRepository,new []{ instanceOfStudent });
        }
    }
}
