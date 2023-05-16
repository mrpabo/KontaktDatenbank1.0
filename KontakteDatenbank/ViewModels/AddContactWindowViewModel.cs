using KontakteDatenbankDB.Entities;
using KontakteDatenbankDB.Models;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace KontakteDatenbankDB.ViewModels
{
    public class AddContactWindowViewModel : ViewModelBase
    {
        public AddContactWindowViewModel()
        {

            //using (var context = new ContactContext())
            //{
            //    context.Contacts.Add(newContact);
            //    context.SaveChanges();
            //}


            SelectedContact = new Contact()
            {
                FirstName = "",
                LastName = "",
                BirthDate = DateTime.Now
                






                //ImageFileName = @"D:\Benutzerdateien\Desktop\person.png"
            };

            //SelectedContact.LoadImage();
        }

       

        public Contact SelectedContact { get; set; } = new Contact();

       

        //public void SetNewProfilePicture(string fileName)
        //{
        //    SelectedContact.ImageFileName = fileName;
        //    SelectedContact.LoadImage();
        //}
    }


    public class AddressesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<string> addresses)
            {
                return string.Join(Environment.NewLine, addresses);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string addressesString)
            {
                return addressesString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            return null;
        }
    }
}
