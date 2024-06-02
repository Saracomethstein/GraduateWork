using System.Windows;
using System.Windows.Controls;

namespace LearnCSharp.View.Pages
{
    public partial class Prac1 : Page
    {
        public Prac1()
        {
            InitializeComponent();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Проверка Успешно выполнена. Ваше решение абсолютно верное!");
            //MessageBox.Show("Проверка Успешно выполнена. В вашем решении обнаружены ошшибки!");
        }
    }
}
