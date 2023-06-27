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
    /// Логика взаимодействия для addpet.xaml
    /// </summary>
    public partial class addpet : Window
    {
        public addpet()
        {
            InitializeComponent();
            PetOwnerComboboxView.ItemsSource = DatabaseControl.GetPetOwnerForView();
            VeterenarianComboboxView.ItemsSource = DatabaseControl.GetVeterinarianForView();
            DiseaseComboboxView.ItemsSource = DatabaseControl.GetDiseaseForView();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(Validation.PetValidation(petNameView.Text, kindNameView.Text, Convert.ToDateTime(BirthdateView.SelectedDate.Value), statusNameView.Text))
            {
                DatabaseControl.AddPet(new pet
                {
                    pname = petNameView.Text,
                    kind = kindNameView.Text,
                    status = statusNameView.Text,
                    birthdate = DateTime.SpecifyKind(Convert.ToDateTime(BirthdateView.SelectedDate.Value), DateTimeKind.Utc),
                    id_owner = (int)PetOwnerComboboxView.SelectedValue,
                    id_veterinarian = (int)VeterenarianComboboxView.SelectedValue,
                    id_disease = (int)DiseaseComboboxView.SelectedValue
                });
                (this.Owner as MainWindow).RefreshTable();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный ввод", "!!!ОШИБКА!!!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            }
        }
    }
}
