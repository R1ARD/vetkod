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
    /// Логика взаимодействия для addmedecine.xaml
    /// </summary>
    public partial class addmedecine : Window
    {
        public addmedecine()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MedecinePriceView.Text = MedecinePriceView.Text.Replace(".", ",");
            if (Validation.MedecineValidation(MedecineNameView.Text, Convert.ToInt32(MedecineAmountView.Text), Convert.ToDecimal(MedecinePriceView.Text), MedecineContraindicationsView.Text))
            {
                DatabaseControl.AddMedecine(new medecine
                {
                    mname = MedecineNameView.Text,
                    amount = Convert.ToInt32(MedecineAmountView.Text),
                    price = Convert.ToDecimal(MedecinePriceView.Text),
                    contraindications = MedecineContraindicationsView.Text,
                    isrecipe = (bool)MedecineIsRecipeView.IsChecked,
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
