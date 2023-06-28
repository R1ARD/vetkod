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
    /// Логика взаимодействия для showcard.xaml
    /// </summary>
    public partial class showcard : Window
    {
        public pet _tempPet { get; set; }
        public showcard(pet Pet)
        {
            InitializeComponent();

            _tempPet = Pet;

            CardDataGridView.ItemsSource = DatabaseControl.GetCardForView(Pet.id);


        }
        public void RefreshTable()
        {
            CardDataGridView.ItemsSource = null;
            CardDataGridView.ItemsSource = DatabaseControl.GetCardForView(_tempPet.id);
        }
        public void CardDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            card c = CardDataGridView.SelectedItem as card;

            if (c != null)
            {
                    DatabaseControl.DelCard(c);
                    RefreshTable();

            }
            else
            {
                MessageBox.Show("Выберите элемент для удаления");
            }
        }
    }
}
