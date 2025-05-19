using System.Windows;

namespace TankstellenApp
{
    public partial class Config : Window
    {
        /// <summary>
        /// Initialisiert das Konfigurationsfenster und zeigt gespeicherte API-Keys an.
        /// </summary>
        public Config()
        {
            InitializeComponent();

            txtBlo_GeoApiKey.Text = VariablenClass.GetUserEnvironmentVariable("GeoApiKey") ?? "Variable nicht gefunden";
            txtBlo_TankApiKey.Text = VariablenClass.GetUserEnvironmentVariable("TankerkoenigApiKey") ?? "Variable nicht gefunden";
        }
        /// <summary>
        /// Speichert den GeoApiKey nach Bestätigung durch den Nutzer.
        /// </summary>
        private void btn_SaveGeoApiKey_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Möchten Sie den GeoApiKey wirklich speichern?",
                "Bestätigung",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                VariablenClass.SaveVariable("GeoApiKey", txtBox_GeoApiKey);
            }
        }
        /// <summary>
        /// Speichert den Tankerkönig-ApiKey nach Bestätigung durch den Nutzer.
        /// </summary>
        private void btn_SaveTankApiKey_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Möchten Sie den Tankerkönig ApiKey wirklich speichern?",
                "Bestätigung",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                VariablenClass.SaveVariable("TankerkoenigApiKey", txtBox_TankApiKey);
            }
        }
        // setzt den Text in der TextBox zurück, wenn der Nutzer darauf klickt
        private void txtBox_TankApiKey_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_TankApiKey.Text = "";
        }
        // setzt den Text in der TextBox zurück, wenn der Nutzer darauf klickt
        private void txtBox_GeoApiKey_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBox_GeoApiKey.Text = "";
        }
    }
}
