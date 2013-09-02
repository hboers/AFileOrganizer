using System;
using System.Collections.Generic;
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
using Entities;
using Business;

namespace AFileOrganizer
{
    /// <summary>
    /// Lógica de interacción para AssociationsManager.xaml
    /// </summary>
    public partial class AssociationsManager : Window
    {
        private BAssociation _bassociation;
        private Association _association;

        public AssociationsManager()
        {
            _association = null;

            InitializeComponent();
            //
            _bassociation = new BAssociation();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            AssociationWindow _associationWindow = new AssociationWindow(this);
            _associationWindow.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgAssociations.ItemsSource = _bassociation.getListOfAssociations();
        }

        private void dgAssociations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _association = dgAssociations.SelectedItem as Association;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_association != null)
                {
                    _bassociation.Delete(_association);
                    dgAssociations.ItemsSource = _bassociation.getListOfAssociations();
                    System.Windows.MessageBox.Show("Association has been deleted successfully!");
                }
                else
                {
                    System.Windows.MessageBox.Show("You must choose an item to continue!");
                }
            }
            catch (Exception ex) 
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
         
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (_association != null)
            {
                AssociationWindow _associationWindow = new AssociationWindow(this,_association);
                _associationWindow.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("You must choose an item to continue!");
            }
        }
    }
}
