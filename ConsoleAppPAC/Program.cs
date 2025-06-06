// ConsoleAppPAC/Program.cs
using System;
using System.Timers; // Required for System.Timers.Timer
using System.Threading; // Required for CancellationTokenSource and Task.Delay
using System.Threading.Tasks; // Required for Task.Delay

namespace ConsoleAppPAC
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    public class Program
    {
        // Declare a static timer to keep it alive for the duration of the application.
        // Explicitly specify System.Timers.Timer to resolve ambiguity.
        private static System.Timers.Timer _aTimer;
        private static int _tickCount = 0;

        public static async Task Main(string[] args) // Make Main method asynchronous
        {
            Console.WriteLine("Hello from ConsoleAppPAC!");
            Console.WriteLine("Application started. It will run for 2 minutes then exit automatically.");

            // Set up the timer
            SetTimer();

            // Create a CancellationTokenSource to manage the application's lifetime
            using (var cancellationTokenSource = new CancellationTokenSource())
            {
                // Wait for 2 minutes (120,000 milliseconds)
                try
                {
                    await Task.Delay(TimeSpan.FromMinutes(2), cancellationTokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    // This catch block handles if the task is cancelled, though in this simple case,
                    // it will just complete after the delay.
                }
            }

            // After 2 minutes, stop the timer and dispose of it.
            _aTimer.Stop();
            _aTimer.Dispose();
            Console.WriteLine("2 minutes elapsed. Application exiting.");
        }

        private static void SetTimer()
        {
            // Create a new timer with an interval of 1 minute (60,000 milliseconds).
            // This means the OnTimedEvent will fire every minute.
            _aTimer = new System.Timers.Timer(60000);

            // Hook up the Elapsed event for the timer.
            // This method will be called every time the timer interval elapses.
            _aTimer.Elapsed += OnTimedEvent;

            // Set the timer to auto-reset.
            // If AutoReset is true, the timer raises the Elapsed event repeatedly.
            _aTimer.AutoReset = true;

            // Enable the timer. It will start raising events after this.
            _aTimer.Enabled = true;
        }

        // Event handler for the timer's Elapsed event.
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            _tickCount++;
            Console.WriteLine($"Timer tick #{_tickCount}: The Elapsed event was raised at {e.SignalTime:HH:mm:ss.fff}");

            // Example of using the Calculator here (optional)
            // Calculator calc = new Calculator();
            // Console.WriteLine($"  Current time hash: {calc.Add(e.SignalTime.Second, e.SignalTime.Minute)}");
        }
    }
}
