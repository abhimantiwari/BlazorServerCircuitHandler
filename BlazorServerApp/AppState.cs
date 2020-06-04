using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    public class AppState : IDisposable
    {
        System.Timers.Timer timer;
        public string Id { get; set; }
        public string Naam { get; set; }
        public Logger _logger;
        public bool running = true;

        public AppState(Logger logger)
        {
            Id = Guid.NewGuid().ToString();
            _logger = logger;

            //new Task(PrintAlive).Start();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += (sender, args) => PrintAlive();
            timer.Start();
            PrintAlive();
        }

        private void PrintAlive()
        {
            _logger.SetAlive(Id);
        }

        public void Dispose()
        {
           // Debug.WriteLine($"{Id} is disposed");
            //timer.Dispose();
            _logger.SetDisposed(Id);
        }


    }
}
