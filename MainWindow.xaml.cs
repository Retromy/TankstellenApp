using System.Windows;

namespace TankstellenApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // mainList: um die Aufgerufene Liste die mit KlickEvent auf Eingabe erzeugt wird für das KlickEvent Speichern verfügbar zu machen 
        private List<TankstellenClass> mainList;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void txtPLZ_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPLZ.Text = ""; 
        }
        private void btnEingabe_Click(object sender, RoutedEventArgs e)
        {
            string Strecke = radiusSlider.Value.ToString();
            string Ort = txtPLZ.Text;
            string type = "Error Type";

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
            List<TankstellenClass> neueListe = ListClass.listeErzeugen(Ort, Strecke, type);
            priceListView.ItemsSource = neueListe;
            mainList = neueListe;
        }

        private void Speichern_Click(object sender, RoutedEventArgs e)
        {
            SaveClass.DateiSpeichern(mainList);
        }

        private void Config_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}