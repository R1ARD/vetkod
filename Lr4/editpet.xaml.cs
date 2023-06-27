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
    /// Логика взаимодействия для editpet.xaml
    /// </summary>
    public partial class editpet : Window
    {
        public pet _tempPet { get; set; }

        public card _tempCard { get; set; }
        public editpet(pet Pet)
        {
            InitializeComponent();

            _tempPet = Pet;

            VeterenarianComboboxView.ItemsSource = DatabaseControl.GetVeterinarianForView();
            PetOwnerComboboxView.ItemsSource = DatabaseControl.GetPetOwnerForView();
            DiseaseComboboxView.ItemsSource = DatabaseControl.GetDiseaseForView();

            petNameView.Text = Pet.pname;
            kindNameView.Text = Pet.kind;
            statusNameView.Text = Pet.status;
            BirthdateView.SelectedDate = Pet.birthdate;

            VeterenarianComboboxView.SelectedValue = Pet.VeterinarianEntity.id;
            PetOwnerComboboxView.SelectedValue = Pet.PetOwnerEntity.id;
            DiseaseComboboxView.SelectedValue = Pet.DiseaseEntity.id;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.PetValidation(petNameView.Text, kindNameView.Text, Convert.ToDateTime(BirthdateView.SelectedDate.Value), statusNameView.Text))
            {
                _tempPet.pname = petNameView.Text;
                _tempPet.kind = kindNameView.Text;
                _tempPet.birthdate = DateTime.SpecifyKind(Convert.ToDateTime(BirthdateView.SelectedDate.Value), DateTimeKind.Utc);
                _tempPet.status = statusNameView.Text;
                _tempPet.id_owner = (int)PetOwnerComboboxView.SelectedValue;
                _tempPet.id_veterinarian = (int)VeterenarianComboboxView.SelectedValue;
                _tempPet.id_disease = (int)DiseaseComboboxView.SelectedValue;

                DatabaseControl.AddCard(new card
                {
                    id_pet = _tempPet.id,
                    recdate = DateTime.Now.Date,
                    oname = PetOwnerComboboxView.Text,
                    vname = VeterenarianComboboxView.Text,
                    dname = DiseaseComboboxView.Text,

                });
                DatabaseControl.UpdatePet(_tempPet);
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
