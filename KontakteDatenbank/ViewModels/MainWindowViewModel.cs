﻿using KontakteDatenbank.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static KontakteDatenbank.Models.Contact;

namespace KontakteDatenbank.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            //using (var context = new ContactContext())
            //{
            //    context.Contacts.Add(newContact);
            //    context.SaveChanges();
            //}
        }

        public async Task RefreshAsync()
        {
            Contacts = new ObservableCollection<Contact>()
            {
                new Contact()
                {
                    FirstName = "Dagobert",
                    LastName = "Duck",
                    Email = "DagobertD@entenhausen.com",
                    Addres = "Entenhausen 1",
                    Phone = "+43664/12345678",
                    Age = 75,
                    Mantra = "Ich schwimme im Geld ",
                    Id = 1,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\dagobert.png"
                },
                new Contact()
                {
                    FirstName = "Donald",
                    LastName = "Duck",
                    Email = "DonaldD@entenhausen.com",
                    Addres = "Entenhausen 10",
                    Phone = "+43664/87654321",
                    Age = 45,
                    Mantra = "Quack Quack",
                    Id = 2,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\donald.png"
                },
                 new Contact()
                {
                    FirstName = "Elon",
                    LastName = "Musk",
                    Email = "ElonMusk@SiliconValley.com",
                    Addres = "MuskisHome 1",
                    Phone = "+4366/66666666",
                    Mantra = "The Wolrd is mine",
                    Age = 52,
                    Id = 3,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\elon-musk.png"
                } ,
                 new Contact()
                {
                    FirstName = "Batman",
                    LastName = "",
                    Email = "Batman@batman-cave.com",
                    Addres = "Batcave 1",
                    Phone = "+Scream or Bad-Signal",
                    Mantra = "I fuck you bad guy",
                    Age = 95,
                    Id = 4,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\Batman.png"
                },
                new Contact()
                {
                    FirstName = "Snoop Dogg",
                    LastName = "",
                    Email = "SnoopDogg@doggystyle.com",
                    Addres = "SnoopysHome 1",
                    Phone = "+43/00000420",
                    Mantra = "DoggyStyle",
                    Age = 52,
                    Id = 5,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\SnoopDogg.png"
                },
                new Contact()
                {
                    FirstName = "No",
                    LastName = "Body",
                    Email = "nobody@nothing.com",
                    Addres = "Streetless",
                    Phone = "noNumber",
                    Mantra = "nothing",
                    Age = 000,
                    Id = 6,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\person.png"
                },
                new Contact()
                {
                    FirstName = "James",
                    LastName = "Bond",
                    Email = "007@MI6.com",
                    Addres = "TopSecretStreet 7",
                    Phone = "+00/00000007",
                    Mantra = "shaken not stirred",
                    Age = 70,
                    Id = 7,
                    ImageFileName = @"D:\Benutzerdateien\Desktop\images.png"
                }
            };

            await LoadProfilePicturesAsync();
        }

        public string SelectedContactFilter { get; set; }

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public Contact SelectedContact { get; set; }

        public ImageSource GetImageSourceFromFile(string fileName)
        {
            using (Image image = Image.FromFile(fileName))
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                stream.Close();

                return bitmapImage;
            }
        }


        internal async Task LoadProfilePicturesAsync()
        {
            Contacts.ToList().ForEach(x => x.LoadImage());
        }



        public void DeleteContact(Contact contact)
        {
            Contacts.Remove(contact);
        }


    }


}

