using LearnCSharp.Model;
using LearnCSharp.ViewModel;
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
using System.Windows.Shapes;

namespace LearnCSharp.View
{
    /// <summary>
    /// Interaction logic for CoderTest.xaml
    /// </summary>
    public partial class CoderTest : Window
    {
        public CoderTest()
        {
            InitializeComponent();
            DataContext = new CodingTaskViewModel
            {
                CurrentTask = new CodingTask
                {
                    Description = "Write a function that returns 'Hello, World!'",
                    ExpectedOutput = "Hello, World!"
                }
            };
        }
    }
}
