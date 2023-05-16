
using KontakteDatenbankDB.Entities;
using KontakteDatenbankDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontakteDatenbankDB.Managers
{
    public class PersonsManager : ManagerBase
    {
        public PersonsManager()
        {

        }

        public List<Contact> GetPersons()
        {
            using (var db = new ContactsEntities())
            {
                var persons = db.Persons.ToList();

                return persons.Select(person => Contact.FromEntity(person, Contact.GetX()))
                    .ToList();
            }
        }




        public void AddPerson(Contact contact)
        {
            using (var db = new ContactsEntities())
            {
                var person = Contact.ToEntity(contact);
                db.Persons.Add(person);
                db.SaveChanges();
            }



            var personsManager = new PersonsManager();
            _ = personsManager.GetPersons();
            var newContact = new Contact()
            {
                //FirstName = "",
                //LastName = "",
                //BirthDate = new DateTime(),

            };
            personsManager.AddPerson(newContact);
        }

    }
}
