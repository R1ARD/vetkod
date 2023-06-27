using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lr4
{
    internal static class Validation
    {
        static string emailPattern = @"\w\@\w";

        static string phoneNumberPattern = @"^\+[1-9]\d{3}\d{3}\d{4}$";
        static public bool MedecineValidation(string name, int amount, decimal price, string contraindications)
        {
            return (price > 0) && (amount > 0) && (name != "") && (contraindications != "");


        }
        static public bool PersonValidation(string name, string secondname, string fathername, string gender, DateTime date, string phoneNumber, string email, string address, int salary, string education) // veterinarian
        {

            return (name != "") && (secondname != "") && (fathername != "") && (gender != "") && date < DateTime.Now.Date && (Regex.IsMatch(phoneNumber, phoneNumberPattern)) && (Regex.IsMatch(email, emailPattern))  && (address != "") && (salary > 0) && (education != "");
        }
        static public bool PersonValidation(string name, string secondname, string fathername, string gender, DateTime date, string phoneNumber, string email,  string address) // PetOwner
        {

            return (name != "") && (secondname != "") && (fathername != "") && (gender != "") && date < DateTime.Now.Date && (Regex.IsMatch(phoneNumber, phoneNumberPattern)) && (Regex.IsMatch(email, emailPattern)) &&  (address != "");
        }
        static public bool DiseaseValidation (string name, string type, string symptom)
        {
            return (name != "") && (type != "") && (symptom != "");
        }
        static public bool PetValidation(string name, string kind, DateTime date, string status)
        {
            return (name != "") && (kind != "") && date < DateTime.Now.Date && (status != "");
        }
    }
}
