namespace ChronometerDemo.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class Chronometer : IChronometer
    {
        private long milliseconds;
        private bool isRunning;

        public Chronometer()
        {
            this.Reset();
        }

        public string GetTime
            => $"{milliseconds / 60000:D2}:{ milliseconds/ 1000:D2}:{(milliseconds % 1000):D4}";

        public List<string> Laps { get; private set; }

        public string Lap()
        {
            string lap = this.GetTime;
            this.Laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            this.Stop();
            this.milliseconds = 0;
            this.Laps = new List<string>();
        }

        public void Start()
        {
            this.isRunning = true;

            Task.Run(() =>
            {
                while (isRunning)
                {
                    Thread.Sleep(1);
                    this.milliseconds++;
                }
            });
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}
