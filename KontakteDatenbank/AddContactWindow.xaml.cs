using KontakteDatenbankDB.Managers;
using KontakteDatenbankDB.Models;
using KontakteDatenbankDB.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;


namespace KontakteDatenbankDB
{
    /// <summary>
    /// Interaktionslogik für AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : MetroWindow
    {
        private AddContactWindowViewModel viewModel;
        private PersonsManager _personsManager;

        public AddContactWindow()
        {
            viewModel = new AddContactWindowViewModel();

            InitializeComponent();

            _personsManager = new PersonsManager();
            DataContext = viewModel;


        }

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        private DependencyPropertyChangedEventArgs nameof(ObservableCollection<Contact> contacts)
        {
            throw new NotImplementedException();
        }

        private void Cmd_Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            AddedContact = viewModel.SelectedContact;
        }

        private void Cmd_Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public Contact AddedContact { get; set; }


        private void Cmd_Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        //private void CMD_SelectProfileImage_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    var dialog = new CommonOpenFileDialog
        //    {
        //        IsFolderPicker = false,
        //        Multiselect = false,
        //        InitialDirectory = @"D:\Projects-private\KontaktDatenbank-master\KontaktDatenbank-master\KontakteDatenbank\Bilder",
        //    };

        //    dialog.Filters.Add(new CommonFileDialogFilter("PNG-Datei (*.png)", "*.png"));
        //    dialog.Filters.Add(new CommonFileDialogFilter("JPEG-Datei (*.jpg)", "*.jpg|*.jpeg"));
        //    dialog.Filters.Add(new CommonFileDialogFilter("BMP-Datei (*.bmp)", "*.bmp"));

        //    if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        //    {
        //        viewModel.SetNewProfilePicture(dialog.FileName);
        //    }
        //}

        //private void CMD_SelectProfileImage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        public void LoadContacts()
        {
            Contacts = new ObservableCollection<Contact>(_personsManager.GetPersons());
        }

    }
}
