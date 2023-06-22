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
    /// Логика взаимодействия для editdisease.xaml
    /// </summary>
    public partial class editdisease : Window
    {
        public disease _tempdisease { get; set; }
        public editdisease(disease Disease)
        {
            InitializeComponent();

            _tempdisease = Disease;

            DiseaseNameView.Text = Disease.dname;
            DiseaseTypeView.Text = Disease.dtype;
            DiseaseSymptomView.Text = Disease.symptom;
            MedecineComboboxView.SelectedValue = Disease.MedecineEntity.id;

            MedecineComboboxView.ItemsSource = DatabaseControl.GetMedecineForView();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(Validation.DiseaseValidation(DiseaseNameView.Text, DiseaseTypeView.Text, DiseaseSymptomView.Text))
            {
                _tempdisease.dname = DiseaseNameView.Text;
                _tempdisease.dtype = DiseaseTypeView.Text;
                _tempdisease.symptom = DiseaseSymptomView.Text;
                _tempdisease.id_medecine = (int)MedecineComboboxView.SelectedValue;

                DatabaseControl.UpdateDisease(_tempdisease);
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
