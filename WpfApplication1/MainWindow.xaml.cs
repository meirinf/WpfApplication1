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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer dispatcherTimer;
        private object lastTime;
        private DateTimeOffset startTime;

        public MainWindow()
        {
            DispatcherTimerSetup();
            InitializeComponent();
        }
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //IsEnabled defaults to false
            //TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
           // TimerLog.Text += "Calling dispatcherTimer.Start()\n";
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
           // TimerLog.Text += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            relojito1.Text = DateTime.Now.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            MessageBoxResult result = MessageBox.Show("HOLA!!! Soy Relojito te digo la hora y si me activas, una alarma en la hora predeterminada te dare un aviso.  GRACIAS POR USARME ^^. ¿Quieres apagarme?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Adios");
                Application.Current.Shutdown();
            }
        }
        private void Programar_Click(object sender, RoutedEventArgs e)
        {
            Alarma.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
