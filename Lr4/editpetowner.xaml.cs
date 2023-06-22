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
    /// Логика взаимодействия для editpetowner.xaml
    /// </summary>
    public partial class editpetowner : Window
    {
        public petowner _temppetowner { get; set; }
        public editpetowner(petowner Petowner)
        {
            InitializeComponent();

            _temppetowner = Petowner;

            VeterenarianComboboxView.ItemsSource = DatabaseControl.GetVeterinarianForView();

            PetOwnerNameView.Text = Petowner.oname;
            PetOwnerPhoneNumberView.Text = Petowner.phonenumber;
            PetOwnerEmailView.Text = Petowner.emailaddress;
            PetOwnerPasswordView.Text = Petowner.opassword;
            PetOwnerAddressView.Text = Petowner.oaddress;

            VeterenarianComboboxView.SelectedValue = Petowner.VeterinarianEntity.id;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.PersonValidation(PetOwnerNameView.Text, PetOwnerPhoneNumberView.Text, PetOwnerEmailView.Text, PetOwnerAddressView.Text))
            {
                if (!DatabaseControl.PetOwnerIsValid(PetOwnerEmailView.Text, PetOwnerPasswordView.Text))
                {

                    _temppetowner.oname = PetOwnerNameView.Text;
                    _temppetowner.phonenumber = PetOwnerPhoneNumberView.Text;
                    _temppetowner.emailaddress = PetOwnerEmailView.Text;
                    _temppetowner.opassword = PetOwnerPasswordView.Text;
                    _temppetowner.oaddress = PetOwnerAddressView.Text;
                    DatabaseControl.UpdatePetOwner(_temppetowner);
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
