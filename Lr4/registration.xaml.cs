using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public bool _isFromMainWindow { get; set; }

        public registration(bool isFromMainWindow)
        {
            InitializeComponent();
            _isFromMainWindow = isFromMainWindow;
        }

        private void AddVeterinarianButton_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                if (!DatabaseControl.VeterinarianIsValid(VeterinarianEmailView.Text, VeterinarianPasswordView.Password))
                {

                    DatabaseControl.AddVeterinarian(new veterinarian
                    {
                        vname = VeterinarianNameView.Text,
                        phonenumber = VeterinarianPhoneNumberView.Text,
                        emailaddress = VeterinarianEmailView.Text,
                        vpassword = VeterinarianPasswordView.Password,
                        vaddress = VeterinarianAddressView.Text,
                        salary = Convert.ToInt32(VeterinarianSalaryView.Text),
                        education = VeterinarianEducationView.Text,
                    });

                    if (_isFromMainWindow)
                    {
                        (this.Owner as MainWindow).RefreshTable();
                        this.Close();
                    }
                    else
                    {
                        MainWindow win = new MainWindow();
                        win.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует.");
                }
            }
            {
                MessageBox.Show("Неправильный ввод", "!!!ОШИБКА!!!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            }
        }

    }
}
