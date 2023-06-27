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
            if (Validation.PersonValidation(PetOwnerNameView.Text, PetOwnerSecondNameView.Text, PetOwnerFatherNameView.Text, PetOwnerGenderView.Text, PetOwnerPhoneNumberView.Text, PetOwnerEmailView.Text, PetOwnerAddressView.Text))
            {
                if (!DatabaseControl.PetOwnerEmailIsValid(PetOwnerEmailView.Text))
                {

                    DatabaseControl.AddPetOwner(new petowner
                    {
                        id_veterinarian = (int)VeterenarianComboboxView.SelectedValue,
                        oname = PetOwnerNameView.Text,
                        osecondname = PetOwnerSecondNameView.Text,
                        ofathername = PetOwnerFatherNameView.Text,
                        gender = PetOwnerGenderView.Text,
                        birthdate = DateTime.SpecifyKind(Convert.ToDateTime(BirthdateView.SelectedDate.Value), DateTimeKind.Utc),
                        phonenumber = PetOwnerPhoneNumberView.Text,
                        emailaddress = PetOwnerEmailView.Text,
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
