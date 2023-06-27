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
            PetOwnerSecondNameView.Text = Petowner.osecondname;
            PetOwnerFatherNameView.Text = Petowner.ofathername;
            PetOwnerGenderView.Text = Petowner.gender;

            PetOwnerPhoneNumberView.Text = Petowner.phonenumber;
            PetOwnerEmailView.Text = Petowner.emailaddress;
            PetOwnerAddressView.Text = Petowner.oaddress;

            VeterenarianComboboxView.SelectedValue = Petowner.VeterinarianEntity.id;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.PersonValidation(PetOwnerNameView.Text, PetOwnerSecondNameView.Text, PetOwnerFatherNameView.Text, PetOwnerGenderView.Text, PetOwnerPhoneNumberView.Text, PetOwnerEmailView.Text, PetOwnerAddressView.Text))
            {
                if (!DatabaseControl.PetOwnerEmailIsValid(PetOwnerEmailView.Text))
                {

                    _temppetowner.oname = PetOwnerNameView.Text;
                    _temppetowner.osecondname = PetOwnerSecondNameView.Text;
                    _temppetowner.ofathername = PetOwnerSecondNameView.Text;
                    _temppetowner.gender = PetOwnerGenderView.Text;

                    _temppetowner.phonenumber = PetOwnerPhoneNumberView.Text;
                    _temppetowner.emailaddress = PetOwnerEmailView.Text;
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
