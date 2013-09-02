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
using System.Windows.Forms;
using Entities;
using Business;

namespace AFileOrganizer
{
    /// <summary>
    /// Lógica de interacción para AssociationWindow.xaml
    /// </summary>
    public partial class AssociationWindow : Window
    {
        private BAssociation _bassociation;

        //It is going be use if we open the window in edition mode.
        private int id;

        private AssociationsManager _associationManager;

        public AssociationWindow(AssociationsManager form,Association association)
        {
             
            _bassociation = new BAssociation();

            InitializeComponent();

            //Communicating two windows for updating datagrid.
            _associationManager = null;
            _associationManager = form as AssociationsManager;

            //Set values to textboxes.
            this.id = association.Id;
            txtName.Text = association.Name;
            txtExtension.Text = association.Extension;
            txtDestination.Text = association.Destination;
            cmbActions.SelectedValue = association.Action;
             
            //We are going to change the event for the button to update.
            btnSave.Click -= btnSave_Click;
            btnSave.Click += btnUpdate_Click;
        }

        public AssociationWindow(AssociationsManager form)
        {
            //Communicating two windows for updating datagrid.
            _associationManager = null;
            _associationManager = form as AssociationsManager;

            InitializeComponent();

            //
            _bassociation = new BAssociation();
        }

        private void btnChooseFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
            if (_folderBrowserDialog.ShowDialog().ToString().Equals("OK"))
            {
                txtDestination.Text = _folderBrowserDialog.SelectedPath;
            }
           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Association _association = new Association();
                _association.Name = txtName.Text;
                _association.Extension = txtExtension.Text;
                _association.Action = cmbActions.Text;
                _association.Destination = txtDestination.Text;

                _bassociation.Add(_association);
                _associationManager.dgAssociations.ItemsSource = _bassociation.getListOfAssociations();

                 System.Windows.MessageBox.Show("Association has been added sucessfully!¡");
            }
            catch (Exception ex)
            {
                 System.Windows.MessageBox.Show(ex.Message);
            }
        }

        //If you open the window in edition mode, I am going to replace the main event of adding with this one to update.
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                 Association _association = new Association();
                _association.Id = this.id;
                _association.Name = txtName.Text;
                _association.Extension = txtExtension.Text;
                _association.Action = cmbActions.Text;
                _association.Destination = txtDestination.Text;

                _bassociation.Update(_association);
                _associationManager.dgAssociations.ItemsSource = _bassociation.getListOfAssociations();

                System.Windows.MessageBox.Show("Association has been updated sucessfully!¡");

            }catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
             this.Close();
        }
    }
}
