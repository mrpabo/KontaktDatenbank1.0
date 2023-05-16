using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PhoneNumber = KontakteDatenbankDB.Entities.PhoneNumber;

namespace KontakteDatenbankDB.Models
{
    public class Contact : ModelBase
    {
        #region Entity

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mantra { get; set; }

        public void UpdateAge()
        {
            CalculateAge();
        }

        private int age;

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int value)
        {
            age = value;
        }

        public ObservableCollection<Mailaddress> Mailaddresses { get; set; } = new ObservableCollection<Mailaddress>();
        public ObservableCollection<Address> Addresses { get; set; } = new ObservableCollection<Address>();
        public ObservableCollection<PhoneNumber> PhoneNumbers { get; set; } = new ObservableCollection<PhoneNumber>();

        #endregion

        #region Properties

        private int _age;

        public string FullName => FirstName + " " + LastName;
        //public ImageSource Image { get; set; }

        #endregion

        #region Public Methods

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }

        #endregion

        #region Private Methods

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (today < BirthDate.AddYears(age))
                age--;
            return age;
        }

        #endregion

        #region Public Static Methods

        public static Contact FromEntity(Entities.Person entity, PhoneNumber phoneNumber)
        {
            Contact contact = new Contact();

            contact.Id = entity.Id;
            contact.FirstName = entity.FirstName;
            contact.LastName = entity.LastName;
            contact.Mantra = entity.Mantra;
            contact.BirthDate = entity.BirthDate;
            contact.Addresses = new ObservableCollection<Address>(entity.Addresses.Select(x => Address.FromEntity(x)).ToList());
            contact.Mailaddresses = new ObservableCollection<Mailaddress>(entity.Mailaddresses.Select(x => Mailaddress.FromEntity(x)).ToList());
            contact.PhoneNumbers = new ObservableCollection<PhoneNumber>();

            if (phoneNumber != null)
            {
                contact.PhoneNumbers.Add(phoneNumber);
            }

            return contact;
        }

        public Entities.Person ToEntity()
        {
            if (this == null)
            {
                return null; // Optional: Behandeln Sie den Fall, wenn das Model null ist.
            }

            Entities.Person entity = new Entities.Person
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Mantra = Mantra,
                BirthDate = BirthDate,
                Addresses = Addresses.Select(address => address.ToEntity()).ToList(),
                Mailaddresses = Mailaddresses.Select(mailaddress => mailaddress.ToEntity()).ToList(),
                PhoneNumbers = PhoneNumbers.Select(phoneNumber => phoneNumber.ToEntity()).ToList()
            };

            return entity;
        }


        internal static PhoneNumber GetX()
        {
            PhoneNumber phoneNumbers = new PhoneNumber();

            return phoneNumbers;
        }

        #endregion
    }
}
