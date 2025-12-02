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

namespace Password_Generator
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
        // Aggiorna il valore visualizzato accanto allo slider quando il valore dello slider cambia
        private void SldLunghezza_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtValoreSlider?.Text = ((int)sldLunghezza.Value).ToString();
        }
        // Genera la password quando si clicca il pulsante "Genera"
        private void BtnGenera_Click(object sender, RoutedEventArgs e)
        {
            int length = (int)sldLunghezza.Value;
            bool includeUppercase = chkMaiuscole.IsChecked == true;
            bool includeDigits = chkNumeri.IsChecked == true;
            bool includeSpecial = chkSimboli.IsChecked == true;
            bool includeAmbiguous = chkAmbigui.IsChecked == true;

            string password = PasswordEngine.GeneratePassword(length, includeUppercase, includeDigits, includeSpecial, includeAmbiguous);

            txtPassword.Text = password;
        }
        // Copia la password negli appunti quando si clicca il pulsante "Copia"
        private void BtnCopia_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Clicca su genera password per ottenere una password...")
                MessageBox.Show("Nessuna password da copiare!", "Password", MessageBoxButton.OK, MessageBoxImage.Warning);
            else {
                Clipboard.SetText(txtPassword.Text);
                MessageBox.Show("Password copiata!", "Password", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
        }
    }
}