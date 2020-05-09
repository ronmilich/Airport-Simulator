using ProjectLibrary;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AirportSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Simulator simulator = Simulator.Instance;
        public StationsManager stationsManager = StationsManager.Instance;
        PlaneDrawer planeDrawer = new PlaneDrawer();

        /// <summary>
        /// This timer raise an event that update the data in the UI.
        /// </summary>
        public System.Timers.Timer dataLoadingTimer = new System.Timers.Timer(1300);
        /// <summary>
        /// This timer raise an event that update the messages in the UI from the simulator class.
        /// </summary>
        public System.Timers.Timer messagesTimer = new System.Timers.Timer(500);

        /// <summary>
        /// Initialize all the needed components for the UI.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            planeDrawer.AirportCanvas = AirportCanvas;
        }

        /// <summary>
        /// Loaded at the start of the application, set initial state of the buttons,
        /// add events for the timers and load resourses from the server.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlaySimulatorButton.IsEnabled = false;
            ResetFlightsButton.IsEnabled = false;
            StopSimulatorButton.IsEnabled = false;
            dataLoadingTimer.Elapsed += UpdateView;
            messagesTimer.Elapsed += UpdateMessagesTextBox;
            new Thread(() => simulator.LoadAssetsCurrentState()).Start();
        }

        /// <summary>
        /// Load resourses from server.
        /// </summary>
        private void Load_Flights(object sender, RoutedEventArgs e)
        {
            PlaySimulatorButton.IsEnabled = true;
            new Thread(() => simulator.LoadAssetsCurrentState()).Start();

            this.Dispatcher.Invoke(() =>
            {
                FlightsDataGrid.ItemsSource = new List<Flight>(simulator.Flights);
                StationsDataGrid.ItemsSource = new List<Station>(stationsManager.GetStations());
                MessagesTextBox.Text = "Flights Loaded...\n";
            });

            WaitEmulator();
        }

        /// <summary>
        /// Start the simulator, activates timers and update buttons state.
        /// </summary>
        private void Start_Simulator(object sender, RoutedEventArgs e)
        {
            MessagesTextBox.Text = "Simulation started...\n";

            PlaySimulatorButton.IsEnabled = false;
            LoadFlightsButton.IsEnabled = false;
            ResetFlightsButton.IsEnabled = true;
            StopSimulatorButton.IsEnabled = true;

            simulator.StartSimulator(5000);
            dataLoadingTimer.Start();
            messagesTimer.Start();
        }

        /// <summary>
        /// Stops The simulator, timers, update buttons state and saves the flights current state to the server.
        /// </summary>
        private void Stop_Simulator(object sender, RoutedEventArgs e)
        {
            planeDrawer.ClearPlainsImages();
            MessagesTextBox.Text = "";
            StopSimulatorButton.IsEnabled = false;
            LoadFlightsButton.IsEnabled = true;

            FlightsDataGrid.ItemsSource = null;
            StationsDataGrid.ItemsSource = null;

            simulator.StopSimulator();
            dataLoadingTimer.Stop();
            messagesTimer.Stop();

            WaitEmulator();
        }

        /// <summary>
        /// Stops The simulator, timers, update buttons state and delete all flights from the server.
        /// </summary>
        private void Reset_Flights(object sender, RoutedEventArgs e)
        {
            planeDrawer.ClearPlainsImages();
            LoadFlightsButton.IsEnabled = true;
            StopSimulatorButton.IsEnabled = false;
            ResetFlightsButton.IsEnabled = false;

            // Nullify item source to earase the data from the datagrids
            FlightsDataGrid.ItemsSource = null;
            StationsDataGrid.ItemsSource = null;

            simulator.ResetSimulationFlights();
            stationsManager.ResetStations();
            dataLoadingTimer.Stop();
            messagesTimer.Stop();
            MessagesTextBox.Text = "";
            WaitEmulator();
        }

        /// <summary>
        /// Emulates waiting process in order to wait for the application integrate with the server.
        /// </summary>
        private static void WaitEmulator()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Thread.Sleep(2000);
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        /// <summary>
        /// An event raised by the messagesTimer that responsible for updating the messages textbox in the UI
        /// </summary>
        private void UpdateMessagesTextBox(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                MessagesTextBox.Text = simulator.SimulationMessages;
                MessagesTextBox.ScrollToEnd();
            });
        }

        /// <summary>
        /// An event raised by the dataLoadingTimer thar responsible for updating the data in the UI.
        /// </summary>
        private void UpdateView(object sender, ElapsedEventArgs e)
        {
            planeDrawer.ClearPlainsImages();
            this.Dispatcher.Invoke(() =>
            {
                FlightsDataGrid.ItemsSource = new List<Flight>(simulator.Flights);
                StationsDataGrid.ItemsSource = new List<Station>(stationsManager.GetStations());
                planeDrawer.AddPlainImages(new List<Flight>(simulator.Flights));
            });
        }

        /// <summary>
        /// Updates the number of flights that can be in the airport simultaneously in the Simulator class.
        /// </summary>
        private void NumberOfFlightsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            Configuration.MaxFlights = int.Parse((string)value.Content);
        }

        /// <summary>
        /// Updates the speed of the flight movement in the Configuration class.
        /// </summary>
        private void FlightsMovmentSpeedComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            var value = (ComboBoxItem)combo.SelectedValue;
            double speed = 1000 * (2 - double.Parse((string)value.Content));

            Configuration.FlightsMovementSpeed = (int)speed;
        }
    }
}
