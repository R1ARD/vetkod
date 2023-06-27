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

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Window
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            /* VETERINARIANS
               ('Alex', '+5550000', 'biden@gmail.ru', 'zxc', 'New York', 10000, 'PHD');

               ('John', '+6660000', 'obama@gmail.ru', 'abc', 'Las Vegas', 20000, 'PTY');

               ('Alex', '+8880000', 'trump@gmail.ru', 'qwerty', 'Iowa', 30000, 'FPD');
            */

            if ((passwordTextbox.Password != "") && (emailTextbox.Text != ""))
            {
                if (DatabaseControl.VeterinarianIsValid(emailTextbox.Text, passwordTextbox.Password))
                {
                    //MessageBox.Show("Пользователь найден");
                    MainWindow win = new MainWindow();
                    win.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Пустой ввод");
            }
        }
        private void AddVeterinarianButton_Click(object sender, RoutedEventArgs e)
        {
            addveterinarian win = new addveterinarian(false);
            win.Show();
        }
    }
}
