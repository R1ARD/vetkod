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
    /// Логика взаимодействия для editmedecine.xaml
    /// </summary>
    public partial class editmedecine : Window
    {
        public medecine _tempMedecine { get; set; }
        public editmedecine(medecine Medecine)
        {
            InitializeComponent();

            _tempMedecine = Medecine;

            MedecineNameView.Text = Medecine.mname;
            MedecineAmountView.Text = Convert.ToString(Medecine.amount);
            MedecinePriceView.Text = Convert.ToString(Medecine.price);
            MedecineContraindicationsView.Text = Medecine.contraindications;
            MedecineIsRecipeView.IsChecked = Medecine.isrecipe;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MedecinePriceView.Text = MedecinePriceView.Text.Replace(".", ",");
            if (Validation.MedecineValidation(MedecineNameView.Text, Convert.ToInt32(MedecineAmountView.Text), Convert.ToDecimal(MedecinePriceView.Text), MedecineContraindicationsView.Text))
            {
                _tempMedecine.mname = MedecineNameView.Text;
                _tempMedecine.amount = Convert.ToInt32(MedecineAmountView.Text);
                _tempMedecine.price = Convert.ToDecimal(MedecinePriceView.Text);
                _tempMedecine.contraindications = MedecineContraindicationsView.Text;
                _tempMedecine.isrecipe = (bool)MedecineIsRecipeView.IsChecked;
                DatabaseControl.UpdateMedecine(_tempMedecine);
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
