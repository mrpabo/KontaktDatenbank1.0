using KontakteDatenbank.Extensions;
using KontakteDatenbank.Models;
using KontakteDatenbank.ViewModels;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace KontakteDatenbank
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainWindowViewModel viewModel;
        //private object items;
        bool _initialized = false;

        public MainWindow()
        {
            viewModel = new MainWindowViewModel();

            InitializeComponent();

            DataContext = viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_initialized == false)
            {
                await viewModel.RefreshAsync();
                _initialized = true;
            }
        }

        private void Cmd_AddContact_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddContactWindow window = new AddContactWindow();
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                viewModel.Contacts.Add(window.AddedContact);
            }
        }

        private void Cmd_AddContact_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Cmd_DeleteContact_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            viewModel.DeleteContact(viewModel.SelectedContact);
        }

        private void Cmd_DeleteContact_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (viewModel.SelectedContact != null)
            {
                e.CanExecute = true;
            }
        }

        private void Cmd_Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }


        public void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item != null && e.Item is Contact)
            {
                Contact contact = (Contact)e.Item;

                if (String.IsNullOrWhiteSpace(viewModel.SelectedContactFilter) == false)
                {
                    e.Accepted =
                        contact.FirstName.Contains(viewModel.SelectedContactFilter, StringComparison.OrdinalIgnoreCase) ||
                        contact.LastName.Contains(viewModel.SelectedContactFilter, StringComparison.OrdinalIgnoreCase) ||
                        contact.Email.Contains(viewModel.SelectedContactFilter, StringComparison.OrdinalIgnoreCase);

                    return;
                }
            }

            e.Accepted = true;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var collection = (CollectionViewSource)this.Resources["Cvs_Contacts"];

            collection.View.Refresh();
        }



        //private bool UserFilter(object item)
        //{

        //    Contact.ItemsSource = items;

        //    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Contact.ItemsSource);
        //    view.Filter = UserFilter;


        //    if (String.IsNullOrEmpty(txtFilter.Text))
        //        return true;
        //    else
        //        return ((item as Contact).LastName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);




        //}



        //private void TxtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    CollectionViewSource.GetDefaultView(Contact.ItemsSource).Refresh(); =
        //}
    }
}
