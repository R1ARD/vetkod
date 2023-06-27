using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public static class DatabaseControl
    {
        public static bool VeterinarianIsValid(string enterEmail, string enterPassword)
        {
            using (DbAppContext ctx = new DbAppContext())
            {             
                return  (ctx.veterinarian.Any(v => v.emailaddress == enterEmail)) && (ctx.veterinarian.Any(v => v.vpassword == enterPassword));
            }
        }

        public static bool PetOwnerEmailIsValid(string enterEmail)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return (ctx.petowner.Any(v => v.emailaddress == enterEmail));
            }
        }

        public static List<pet> GetPetForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.pet.Include(p => p.PetOwnerEntity).Include(v => v.VeterinarianEntity).Include(d => d.DiseaseEntity).ThenInclude(m => m.MedecineEntity).ToList();
            }
        }
        public static void AddPet(pet pet)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.pet.Add(pet);
                ctx.SaveChanges();
            }
        }
        public static void DelPet(pet pet)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.pet.Remove(pet);
                ctx.SaveChanges();
            }
        }
        public static void UpdatePet(pet pet)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                pet _pet = ctx.pet.FirstOrDefault(p => p.id == pet.id);

                if (_pet == null)
                {
                    return;
                }

                _pet.pname = pet.pname;
                _pet.kind = pet.kind;
                _pet.status = pet.status;

                ctx.SaveChanges();
            }
        }

        public static List<card> GetCardForView(int id)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.card.Where(p => p.PetEntity.id == id).ToList();
            }
        }
        public static void AddCard(card card)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.card.Add(card);
                ctx.SaveChanges();
            }
        }
        public static void DelCard(card card)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.card.Remove(card);
                ctx.SaveChanges();
            }
        }
        public static void UpdateCard(card card)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                card _card = ctx.card.FirstOrDefault(c => c.id == card.id);

                if (_card == null)
                {
                    return;
                }

                _card.vname = card.vname;
                _card.oname = card.oname;
                _card.dname = card.dname;
                _card.recdate = card.recdate;

                ctx.SaveChanges();
            }
        }

        public static List<petowner> SearchPetOwner(string searcText)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.petowner.Where(p => 
                    p.oname.ToLower().Contains(searcText.ToLower())
                ||  p.osecondname.ToLower().Contains(searcText.ToLower())
                ||  p.ofathername.ToLower().Contains(searcText.ToLower()))
                    .Include(p => p.VeterinarianEntity).ToList();
            }
        }

        public static List<petowner> GetPetOwnerForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.petowner.Include(p => p.VeterinarianEntity).ToList();
            }
        }
        public static void AddPetOwner(petowner petowner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.petowner.Add(petowner);
                ctx.SaveChanges();
            }
        }
        public static void DelPetOwner(petowner petowner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.petowner.Remove(petowner);
                ctx.SaveChanges();
            }
        }
        public static void UpdatePetOwner(petowner petowner)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                petowner _petowner = ctx.petowner.FirstOrDefault(p => p.id == petowner.id);

                if (_petowner == null)
                {
                    return;
                }

                _petowner.oname = petowner.oname;
                _petowner.osecondname = petowner.osecondname;
                _petowner.ofathername = petowner.ofathername;
                _petowner.gender = petowner.gender;
                _petowner.oname = petowner.oname;
                _petowner.phonenumber = petowner.phonenumber;
                _petowner.emailaddress = petowner.emailaddress;
                _petowner.oaddress = petowner.oaddress;

                ctx.SaveChanges();
            }
        }


        public static List<veterinarian> GetVeterinarianForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.veterinarian.ToList();
            }
        }
        public static void AddVeterinarian(veterinarian veterinarian)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.veterinarian.Add(veterinarian);
                ctx.SaveChanges();
            }
        }
        public static void DelVeterinarian(veterinarian veterinarian)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.veterinarian.Remove(veterinarian);
                ctx.SaveChanges();
            }
        }
        public static void UpdateVeterinarian(veterinarian veterinarian)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                veterinarian _veterinarian = ctx.veterinarian.FirstOrDefault(p => p.id == veterinarian.id);

                if (_veterinarian == null)
                {
                    return;
                }

                _veterinarian.vname = veterinarian.vname;
                _veterinarian.vsecondname = veterinarian.vsecondname;
                _veterinarian.vfathername = veterinarian.vfathername;
                _veterinarian.gender = veterinarian.gender;
                _veterinarian.phonenumber = veterinarian.phonenumber;
                _veterinarian.emailaddress = veterinarian.emailaddress;
                _veterinarian.vpassword = veterinarian.vpassword;
                _veterinarian.vaddress = veterinarian.vaddress;
                _veterinarian.salary = veterinarian.salary;
                _veterinarian.education = veterinarian.education;

                ctx.SaveChanges();
            }
        }


        public static List<disease> GetDiseaseForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.disease.Include(m => m.MedecineEntity).ToList();
            }
        }
        public static void AddDisease(disease disease)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.disease.Add(disease);
                ctx.SaveChanges();
            }
        }
        public static void DelDisease(disease disease)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.disease.Remove(disease);
                ctx.SaveChanges();
            }
        }
        public static void UpdateDisease(disease disease)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                disease _disease = ctx.disease.FirstOrDefault(p => p.id == disease.id);

                if (_disease == null)
                {
                    return;
                }

                _disease.dname = disease.dname;
                _disease.dtype = disease.dtype;
                _disease.symptom = disease.symptom;

                ctx.SaveChanges();
            }
        }


        public static List<medecine> GetMedecineForView()
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                return ctx.medecine.ToList();
            }
        }
        public static void AddMedecine(medecine medecine)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.medecine.Add(medecine);
                ctx.SaveChanges();
            }
        }
        public static void DelMedecine(medecine medecine)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                ctx.medecine.Remove(medecine);
                ctx.SaveChanges();
            }
        }
        public static void UpdateMedecine(medecine medecine)
        {
            using (DbAppContext ctx = new DbAppContext())
            {
                medecine _medecine = ctx.medecine.FirstOrDefault(p => p.id == medecine.id);

                if (_medecine == null)
                {
                    return;
                }

                _medecine.mname = medecine.mname;
                _medecine.amount = medecine.amount;
                _medecine.price = medecine.price;
                _medecine.contraindications = medecine.contraindications;
                _medecine.isrecipe = medecine.isrecipe;

                ctx.SaveChanges();
            }
        }
    }
}
