using System.Windows;

namespace TankstellenApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // mainList: um die Aufgerufene Liste die mit KlickEvent auf Eingabe erzeugt wird für das KlickEvent Speichern verfügbar zu machen 
        private List<JsonClassTankstellen> mainList;
        public MainWindow()
        {
            InitializeComponent();
        }
        // setzt den Text in der TextBox zurück, wenn der Nutzer darauf klickt
        private void txtPLZ_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_PLZ.Text = ""; 
        }
        // startet das Programm und gibt die Liste der Tankstellen aus
        private void btn_Eingabe_Click(object sender, RoutedEventArgs e)
        {
            string Strecke = radiusSlider.Value.ToString();
            string Ort = txtBox_PLZ.Text;
            string type = "Error Type";

            if (string.IsNullOrWhiteSpace(Ort))
            {
                MessageBox.Show("Bitte geben Sie eine Postleitzahl oder einen Ort ein.", "Eingabefehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Benzin.IsChecked == true)
            {
                type = "e5";
            }
            else if (Diesel.IsChecked == true)
            {
                type = "diesel";
            }
            else
            {
                type = "e10";
            }

            // neue Liste initialisieren um Ort und Strecke zu übergeben
            List<JsonClassTankstellen> neueListe = ListClass.listeErzeugen(Ort, Strecke, type);
            priceListView.ItemsSource = neueListe;
            mainList = neueListe;
        }
        // speichert die Liste in einer CSV-Datei ab
        private void btn_Speichern_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveClass.DateiSpeichern(mainList);
                MessageBox.Show("Datei erfolgreich gespeichert.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern: " + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // ruft einen File-Dialog auf um eine CSV-Datei zu laden
        private void btn_Laden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var liste = LoadClass.DateiLadenMitDialog();
                if (liste != null)
                {
                    priceListView.ItemsSource = liste;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden: " + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // öffnet das Konfigurationsfenster um API-Keys zu speichern
        private void Config_Click(object sender, RoutedEventArgs e)
        {
            var configWindow = new Config();
            configWindow.Owner = this; // setzt MainWindow als Besitzer
            configWindow.ShowDialog(); // Modal öffnen (Fenster blockiert bis es geschlossen wird)
        }
    }
}