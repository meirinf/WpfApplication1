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
        private String data;
        private Reloj reloj = new Reloj();

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
            String[] time = relojito1.Text.Split(' ');
            
            if (data != null && data.Equals(time[1]))
            {
                MessageBoxResult result = MessageBox.Show("Es la hora!!!! Quieres desactivarme ?","Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    data = "";
                }
            }
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
            Alarma.Visibility = Visibility.Visible;
            hora_alarma.Visibility = Visibility.Visible;
            OK.Visibility = Visibility.Visible;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            data = hora_alarma.Text;
            Alarma.Visibility = Visibility.Hidden;
            hora_alarma.Visibility = Visibility.Hidden;
            OK.Visibility = Visibility.Hidden;

            reloj.data = data;
            //Agregamos la alarma a la list box
            Alarmas.Items.Add(reloj.data);

        }

        private void Alarmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void turquia_Click(object sender, RoutedEventArgs e)
        {
            double horas = 3.0;
            //textTimeAlter.Text = DateTime.Now.AddHours(horas).ToShortTimeString();
            labelTurquia.Visibility = Visibility.Visible;
            labelItalia.Visibility = Visibility.Hidden;
            labelJapon.Visibility = Visibility.Hidden;
        }

        private void italia_Click(object sender, RoutedEventArgs e)
        {
            double horas = 1.0;
            //textTimeAlter.Text = DateTime.Now.AddHours(horas).ToShortTimeString();
            labelItalia.Visibility = Visibility.Visible;
            labelJapon.Visibility = Visibility.Hidden;
            labelTurquia.Visibility = Visibility.Hidden;

        }

        private void japon_Click(object sender, RoutedEventArgs e)
        {
            double horas = 9.0;
            //textTimeAlter.Text = DateTime.Now.AddHours(horas).ToShortTimeString();
            labelJapon.Visibility = Visibility.Visible;
            labelTurquia.Visibility = Visibility.Hidden;
            labelItalia.Visibility = Visibility.Hidden;

        }
    }
}
