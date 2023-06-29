using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Lr4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string emailPattern = @"\w\@\w";

        public bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, emailPattern);
        }

        public MainWindow()
        {
            InitializeComponent();

            PetDataGridView.ItemsSource = DatabaseControl.GetPetForView();
            VeterinarianDataGridView.ItemsSource = DatabaseControl.GetVeterinarianForView();
            PetOwnerDataGridView.ItemsSource = DatabaseControl.GetPetOwnerForView();
            DiseaseDataGridView.ItemsSource = DatabaseControl.GetDiseaseForView();
            MedecineDataGridView.ItemsSource = DatabaseControl.GetMedecineForView();
        }

        public void RefreshTable()
        {
            PetDataGridView.ItemsSource = null;
            VeterinarianDataGridView.ItemsSource = null;
            PetOwnerDataGridView.ItemsSource = null;
            DiseaseDataGridView.ItemsSource = null;
            MedecineDataGridView.ItemsSource = null;

            PetDataGridView.ItemsSource = DatabaseControl.GetPetForView();
            VeterinarianDataGridView.ItemsSource = DatabaseControl.GetVeterinarianForView();
            PetOwnerDataGridView.ItemsSource = DatabaseControl.GetPetOwnerForView();
            DiseaseDataGridView.ItemsSource = DatabaseControl.GetDiseaseForView();
            MedecineDataGridView.ItemsSource = DatabaseControl.GetMedecineForView();
        }

        private void SearchPetOwnerChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            PetOwnerDataGridView.ItemsSource = DatabaseControl.SearchPetOwner(SearchPetOwner.Text);
        }

        private void SearchPetChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            PetDataGridView.ItemsSource = DatabaseControl.SearchPet(SearchPet.Text);
        }


        private void SearchVeterinarianChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            VeterinarianDataGridView.ItemsSource = DatabaseControl.SearchVeterinarian(SearchVeterinarian.Text);
        }


        private void SearchDiseaseChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            DiseaseDataGridView.ItemsSource = DatabaseControl.SearchDisease(SearchDisease.Text);
        }

        private void SearchMedecineChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            MedecineDataGridView.ItemsSource = DatabaseControl.SearchMedecine(SearchMedecine.Text);
        }


        private void PetEditButton_Click(object sender, RoutedEventArgs e)
        {
            pet p = PetDataGridView.SelectedItem as pet;

            if (p != null)
            {
                editpet win = new editpet(p);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void PetDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            pet p = PetDataGridView.SelectedItem as pet;

            if (p != null)
            {
                try
                {
                    DatabaseControl.DelPet(p);
                    RefreshTable();
                }
                catch
                {
                    DependensDelete();
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }

        private void PetCardButton_Click(object sender, RoutedEventArgs e)
        {
            pet p = PetDataGridView.SelectedItem as pet;

            if (p != null)
            {
                showcard win = new showcard(p);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void PetAddButton_Click(object sender, RoutedEventArgs e)
        {
                addpet win = new addpet();
                win.Owner = this;
                win.ShowDialog();
        }
        
        private void VeterinarianEditButton_Click(object sender, RoutedEventArgs e)
        {
            veterinarian v = VeterinarianDataGridView.SelectedItem as veterinarian;

            if (v != null)
            {
                editveterinarian win = new editveterinarian(v);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void VeterinarianDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            veterinarian v = VeterinarianDataGridView.SelectedItem as veterinarian;

            if (v != null)
            {
                try
                {
                    DatabaseControl.DelVeterinarian(v);
                    RefreshTable();
                }
                catch
                {
                    DependensDelete();
                }
               
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
        private void VeterinarianAddButton_Click(object sender, RoutedEventArgs e)
        {
            addveterinarian win = new addveterinarian(true);
            win.Owner = this;
            win.ShowDialog();
        }

        private void PetOwnerEditButton_Click(object sender, RoutedEventArgs e)
        {
            petowner o = PetOwnerDataGridView.SelectedItem as petowner;

            if (o != null)
            {
                editpetowner win = new editpetowner(o);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void PetOwnerDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            petowner o = PetOwnerDataGridView.SelectedItem as petowner;

            if (o != null)
            {
                try
                {
                    DatabaseControl.DelPetOwner(o);
                    RefreshTable();
                }
                catch
                {
                    DependensDelete();
                }
                
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
        private void PetOwnerAddButton_Click(object sender, RoutedEventArgs e)
        {
            addpetowner win = new addpetowner();
            win.Owner = this;
            win.ShowDialog();
        }

        private void DiseaseEditButton_Click(object sender, RoutedEventArgs e)
        {
            disease d = DiseaseDataGridView.SelectedItem as disease;

            if (d != null)
            {
                editdisease win = new editdisease(d);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void DiseaseDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            disease d = DiseaseDataGridView.SelectedItem as disease;

            if (d != null)
            {
                try
                {
                    DatabaseControl.DelDisease(d);
                    RefreshTable();
                }
                catch
                {
                    DependensDelete();
                }
                
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
        private void DiseaseAddButton_Click(object sender, RoutedEventArgs e)
        {
            adddisease win = new adddisease();
            win.Owner = this;
            win.ShowDialog();
        }

        private void MedecineEditButton_Click(object sender, RoutedEventArgs e)
        {
            medecine m = MedecineDataGridView.SelectedItem as medecine;

            if (m != null)
            {
                editmedecine win = new editmedecine(m);
                win.Owner = this;
                win.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите элемент для изменения");
            }
        }
        private void MedecineDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            medecine m = MedecineDataGridView.SelectedItem as medecine;

            if (m != null)
            {
                try
                {
                    DatabaseControl.DelMedecine(m);
                    RefreshTable();
                }
                catch
                {
                    DependensDelete();
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
        private void MedecineAddButton_Click(object sender, RoutedEventArgs e)
        {
            addmedecine win = new addmedecine();
            win.Owner = this;
            win.ShowDialog();
        }

        private void DependensDelete()
        {
            MessageBox.Show("Нельзя удалять зависимые поля", "!!!ОШИБКА!!!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
        }

    }
}
