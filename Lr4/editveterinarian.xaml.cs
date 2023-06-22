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
    /// Логика взаимодействия для editveterinarian.xaml
    /// </summary>
    public partial class editveterinarian : Window
    {
        public veterinarian _tempVeterinarian { get; set; }
        public editveterinarian(veterinarian Veterinarian)
        {
            InitializeComponent();

            _tempVeterinarian = Veterinarian;  

            VeterinarianNameView.Text = Veterinarian.vname;
            VeterinarianPhoneNumberView.Text = Veterinarian.phonenumber;
            VeterinarianEmailView.Text = Veterinarian.emailaddress;
            VeterinarianPasswordView.Text = Veterinarian.vpassword;
            VeterinarianAddressView.Text = Veterinarian.vaddress;
            VeterinarianSalaryView.Text = Convert.ToString(Veterinarian.salary);
            VeterinarianEducationView.Text = Veterinarian.education;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.PersonValidation(VeterinarianNameView.Text, VeterinarianPhoneNumberView.Text, VeterinarianEmailView.Text, VeterinarianAddressView.Text, Convert.ToInt32(VeterinarianSalaryView.Text), VeterinarianEducationView.Text))
            {
                if (!DatabaseControl.VeterinarianIsValid(VeterinarianEmailView.Text, VeterinarianPasswordView.Text))
                {
                    _tempVeterinarian.vname = VeterinarianNameView.Text;
                    _tempVeterinarian.phonenumber = VeterinarianPhoneNumberView.Text;
                    _tempVeterinarian.emailaddress = VeterinarianEmailView.Text;
                    _tempVeterinarian.vpassword = VeterinarianPasswordView.Text;
                    _tempVeterinarian.vaddress = VeterinarianAddressView.Text;
                    _tempVeterinarian.salary = Convert.ToInt32(VeterinarianSalaryView.Text);
                    _tempVeterinarian.education = VeterinarianEducationView.Text;

                    DatabaseControl.UpdateVeterinarian(_tempVeterinarian);
                    (this.Owner as MainWindow).RefreshTable();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Неправильный ввод", "!!!ОШИБКА!!!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            }
        }
    }
}
