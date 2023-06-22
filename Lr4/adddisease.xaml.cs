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
    /// Логика взаимодействия для adddisease.xaml
    /// </summary>
    public partial class adddisease : Window
    {
        public adddisease()
        {
            InitializeComponent();

            MedecineComboboxView.ItemsSource = DatabaseControl.GetMedecineForView();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.DiseaseValidation(DiseaseNameView.Text, DiseaseTypeView.Text, DiseaseSymptomView.Text))
            {
                DatabaseControl.AddDisease(new disease
                {

                    dname = DiseaseNameView.Text,
                    dtype = DiseaseTypeView.Text,
                    symptom = DiseaseSymptomView.Text,
                    id_medecine = (int)MedecineComboboxView.SelectedValue,
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
