using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFBasics.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtName.Focus();

            //DATA FOR LISTS FEATURE
            availableLists = new List<List<string>>();
            
            
        }

        private void btnSubmitName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBlock txb = new TextBlock();
                string name = SubmitName(txtName.Text,txtName);
                txb.Text = $"Welkom, {name}!";
                txb.Margin = new Thickness(10);
                wrpResult.Children.Add(txb);
                txtName.Text = string.Empty;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private string SubmitName(string input, TextBox inputTextBox)
        {
            if (!string.IsNullOrEmpty(input))
            {
                inputTextBox.Text = string.Empty;
                return input;
            }
            else
            {
                inputTextBox.Text = string.Empty;
                inputTextBox.Focus();
                throw new Exception("Geef een geldige naam in"); 
            }
        }

        //Make Lists and then add or remove items on list

        List<List<string>> availableLists;
        private void btnAddList_Click(object sender, RoutedEventArgs e)
        {
            availableLists.Add(new List<string>());
            lstAvailableLists.Items.Add(txtNewList.Text);
            cmbSelectList.Items.Add(txtNewList.Text);            
        }

        private void cmbSelectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstShowList.ItemsSource = availableLists[cmbSelectList.SelectedIndex];

        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            availableLists[lstAvailableLists.SelectedIndex].Add(txtNewItem.Text);
        }
    }
}