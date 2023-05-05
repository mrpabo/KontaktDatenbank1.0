using KontakteDatenbank.Models;
using KontakteDatenbank.ViewModels;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;


namespace KontakteDatenbank
{
    /// <summary>
    /// Interaktionslogik für AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : MetroWindow
    {
        private AddContactWindowViewModel viewModel;

        public AddContactWindow()
        {
            viewModel = new AddContactWindowViewModel();

            InitializeComponent();

            DataContext = viewModel;
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

        private void CMD_SelectProfileImage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = false,
                Multiselect = false,
                InitialDirectory = @"D:\Projects-private\KontaktDatenbank-master\KontaktDatenbank-master\KontakteDatenbank\Bilder",
            };

            dialog.Filters.Add(new CommonFileDialogFilter("PNG-Datei (*.png)", "*.png"));
            dialog.Filters.Add(new CommonFileDialogFilter("JPEG-Datei (*.jpg)", "*.jpg|*.jpeg"));
            dialog.Filters.Add(new CommonFileDialogFilter("BMP-Datei (*.bmp)", "*.bmp"));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                viewModel.SetNewProfilePicture(dialog.FileName);
            }
        }

        private void CMD_SelectProfileImage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
