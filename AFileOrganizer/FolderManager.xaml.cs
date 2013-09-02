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
    /// Lógica de interacción para FolderManager.xaml
    /// </summary>
    public partial class FolderManager : Window
    {

        private Observer _observer;

        private BObserver _bobserver;

        public FolderManager()
        {
            
            InitializeComponent();
            _bobserver = new BObserver();
            _observer = null;
        }

        private void btnSearchFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
            if (_folderBrowserDialog.ShowDialog().ToString().Equals("OK"))
            {
                txtFolder.Text = _folderBrowserDialog.SelectedPath;
            }
        }

        private void dgAssociations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._observer = dgAssociations.SelectedItem as Observer;
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Observer observer = new Observer();
                observer.Folder = txtFolder.Text;

                _bobserver.Add(observer);
                dgAssociations.ItemsSource = _bobserver.getListOfObservers();
                this._observer = null;
                System.Windows.MessageBox.Show("Folder has been added sucessfully to be monitorized!");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_observer != null)
                {
                    _bobserver.Delete(_observer);
                    System.Windows.MessageBox.Show("Folder has been deleted successfully!");
                    dgAssociations.ItemsSource = _bobserver.getListOfObservers();
                    this._observer = null;
                }
                else
                {
                    System.Windows.MessageBox.Show("You must choose a folder to continue!");
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
            try
            {
                if (_observer != null)
                {
                    Observer observer = new Observer();
                    observer.Id = this._observer.Id;
                    observer.Folder = txtFolder.Text;
                    _bobserver.Update(observer);

                    dgAssociations.ItemsSource = _bobserver.getListOfObservers();
                    System.Windows.MessageBox.Show("Folder has been updated successfully!");
                    this._observer = null;
                }
                else
                {
                    System.Windows.MessageBox.Show("You must choose a folder to continue!");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgAssociations.ItemsSource = _bobserver.getListOfObservers();
        }

       
    }
}
