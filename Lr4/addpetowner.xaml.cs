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
    /// Логика взаимодействия для addpetowner.xaml
    /// </summary>
    public partial class addpetowner : Window
    {
        public addpetowner()
        {
            InitializeComponent();

            VeterenarianComboboxView.ItemsSource = DatabaseControl.GetVeterinarianForView();
        }
        private void AddPetOwnerButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.PersonValidation(PetOwnerNameView.Text, PetOwnerPhoneNumberView.Text, PetOwnerEmailView.Text, PetOwnerAddressView.Text))
            {
                if (!DatabaseControl.PetOwnerIsValid(PetOwnerEmailView.Text, PetOwnerPasswordView.Password))
                {

                    DatabaseControl.AddPetOwner(new petowner
                    {
                        id_veterinarian = (int)VeterenarianComboboxView.SelectedValue,
                        oname = PetOwnerNameView.Text,
                        phonenumber = PetOwnerPhoneNumberView.Text,
                        emailaddress = PetOwnerEmailView.Text,
                        opassword = PetOwnerPasswordView.Password,
                        oaddress = PetOwnerAddressView.Text,

                    });
                    (this.Owner as MainWindow).RefreshTable();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такой пользователь уже существует.");
                }
            }
            else
            {
                MessageBox.Show("Неправильный ввод", "!!!ОШИБКА!!!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            }
        }
    }
}
