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
    /*
CREATE TABLE Veterinarian  
(
	Id serial PRIMARY KEY,
	vName text NOT NULL,
	vsecondname text NOT NULL,
	vfathername text,
	gender text NOT NULL,
	birthdate date NOT NULL,
	PhoneNumber text NOT NULL,
	EmailAddress text NOT NULL,
	vPassword text NOT NULL,
	vAddress text NOT NULL,
	Salary integer NOT NULL,
	Education text NOT NULL
);
INSERT INTO Veterinarian (vName, vsecondname, vfathername, gender, birthdate, PhoneNumber, EmailAddress, vPassword, vAddress, Salary, Education)
VALUES               ('Alex', 'Alexov', 'Johnovich', 'male', '2011-11-21', '+5550000', 'biden@gmail.ru', 'zxc', 'New York', 10000, 'PHD');
INSERT INTO Veterinarian (vName, vsecondname, vfathername, gender, birthdate, PhoneNumber, EmailAddress, vPassword, vAddress, Salary, Education)
VALUES               ('John', 'Geog', 'Hoseyavitch', 'apach', '2001-11-12', '+6660000', 'obama@gmail.ru', 'abc', 'Las Vegas', 20000, 'PTY');
INSERT INTO Veterinarian (vName, vsecondname, vfathername, gender, birthdate, PhoneNumber, EmailAddress, vPassword, vAddress, Salary, Education)
VALUES               ('Barby', 'Gosling', 'Ryanovna', 'female', '2011-10-17', '+8880000', 'trump@gmail.ru', 'qwerty', 'Iowa', 30000, 'FPD');
INSERT INTO Veterinarian (vName, vsecondname, vfathername, gender, birthdate, PhoneNumber, EmailAddress, vPassword, vAddress, Salary, Education)
VALUES               ('Test', 'Testow', 'Testovich', 'androgin', '2001-09-11', '+8880000', 'e@m', '123', 'TestBox', 2280000, 'XYZ');

CREATE TABLE PetOwner  
(
	Id serial PRIMARY KEY,
	oName text NOT NULL,
	osecondname text NOT NULL,
	ofathername text,
	gender text NOT NULL,
	birthdate date NOT NULL,
	PhoneNumber text NOT NULL,
	EmailAddress text NOT NULL,
	oAddress text NOT NULL,
	
	id_veterinarian INT NOT NULL,
	FOREIGN KEY (id_veterinarian) REFERENCES Veterinarian(Id) ON DELETE CASCADE
);
INSERT INTO PetOwner (oName, osecondname, ofathername, gender, birthdate, PhoneNumber, EmailAddress,  oAddress, id_veterinarian)
VALUES               ('Ivan', 'Ivanovitch', 'Ivanov', 'male', '2011-11-11', '+79000000000', 'slava@kpss.ru',  'Moscow', 1);
INSERT INTO PetOwner (oName, osecondname, ofathername, gender, birthdate, PhoneNumber, EmailAddress,  oAddress, id_veterinarian)
VALUES               ('Dmitri', 'Cyber', 'Antonovich', 'male', '2011-10-11', '+78000000000', 'ded@doest.ru',  'Yekaterinburg', 1);
INSERT INTO PetOwner (oName, osecondname, ofathername, gender, birthdate, PhoneNumber, EmailAddress,  oAddress, id_veterinarian)
VALUES               ('Semen', 'Hromtsov', 'Yourevich', 'male', '2011-08-30', '+75000000000', 'dia@bet.su',  'Sisert', 2);
INSERT INTO PetOwner (oName, osecondname, ofathername, gender, birthdate, PhoneNumber, EmailAddress,  oAddress, id_veterinarian)
VALUES               ('Kirill', 'Kodolov', 'Ovegovich', 'male', '2011-11-28', '+74000000000', 'kir@hines.ru', 'Yekaterinburg', 3);


CREATE TABLE Medecine  
(
	Id serial PRIMARY KEY,
	mName text NOT NULL,
	Amount integer NOT NULL,
	Price decimal NOT NULL,
	Contraindications text,
	IsRecipe bool NOT NULL
);

INSERT INTO Medecine (mName, Amount, Price,  Contraindications, IsRecipe)
VALUES               ('Holy water', 666, 999.99, 'Ateism', False);
INSERT INTO Medecine (mName, Amount, Price,  Contraindications, IsRecipe)
VALUES               ('Asperin', 100, 9.99, 'Pregnancy', True );
INSERT INTO Medecine (mName, Amount, Price,  Contraindications, IsRecipe)
VALUES               ('Thermopsis', 100000, 1.99, 'Pregnancy', False );

CREATE TABLE Disease  
(
	Id serial PRIMARY KEY,
	dName text NOT NULL,
	dType text NOT NULL,
	Symptom text NOT NULL,
	
	id_medecine INT NOT NULL,
	FOREIGN KEY (id_medecine) REFERENCES Medecine(Id) ON DELETE CASCADE
);
INSERT INTO Disease (dName, dType, Symptom,   id_medecine)
VALUES               ('Rabies', 'Virus', 'hydrophobia', 1);
INSERT INTO Disease (dName, dType, Symptom,   id_medecine)
VALUES               ('Chlamydia', 'STD', 'hydrophobia', 2);
INSERT INTO Disease (dName, dType, Symptom,   id_medecine)
VALUES               ('Zombie', 'Virus', 'Anger', 3);

CREATE TABLE Pet  
(
	Id serial PRIMARY KEY,
	pName text NOT NULL,
	Kind text NOT NULL,
	birthdate date NOT NULL,
	Status text NOT NULL,
	
	id_owner INT NOT NULL,
	id_veterinarian INT NOT NULL,
	id_disease INT,
	FOREIGN KEY (id_owner) REFERENCES PetOwner(Id) ON DELETE CASCADE,
	FOREIGN KEY (id_veterinarian) REFERENCES Veterinarian(Id) ON DELETE CASCADE,
	FOREIGN KEY (id_disease) REFERENCES Disease(Id) ON DELETE CASCADE
);
INSERT INTO Pet (pName, Kind, birthdate, Status,  id_owner, id_veterinarian, id_disease)
VALUES               ('Sharik', 'Dog', '2015-10-10', 'Stable', 1, 1, 1);
INSERT INTO Pet (pName, Kind, birthdate, Status,  id_owner, id_veterinarian, id_disease)
VALUES               ('Murzik', 'Cat','2015-10-10', 'Serious', 1, 2, 2);
INSERT INTO Pet (pName, Kind, birthdate, Status,  id_owner, id_veterinarian, id_disease)
VALUES               ('Druzhok', 'Dog','2015-10-10', 'Stable', 2, 1, 2);
INSERT INTO Pet (pName, Kind, birthdate, Status,  id_owner, id_veterinarian, id_disease)
VALUES               ('Kesha', 'Parrot','2015-10-10', 'Stable', 3, 2, 1);
INSERT INTO Pet (pName, Kind, birthdate, Status,  id_owner, id_veterinarian, id_disease)
VALUES               ('Pinky', 'Rat','2015-10-10', 'Serious', 3, 1, 2);
INSERT INTO Pet (pName, Kind, birthdate, Status,  id_owner, id_veterinarian, id_disease)
VALUES               ('Waddles', 'Pig', '2015-10-10', 'Stable', 4, 3, 1);

CREATE TABLE card  
(
	Id serial PRIMARY KEY,
	recdate TIMESTAMP NOT NULL,
	pstatus text NOT NULL,
	vname text NOT NULL,
	oname text NOT NULL,
	dname text NOT NULL,

	id_pet INT NOT NULL,
	FOREIGN KEY (id_pet) REFERENCES Pet(Id) ON DELETE CASCADE
);

     */
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
