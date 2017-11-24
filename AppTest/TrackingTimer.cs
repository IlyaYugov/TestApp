using System;
using System.Timers;

namespace AppTest
{
    public class TrackingTimer
    {
        private int _count;
        private readonly int _maxCount;
        private readonly Timer _timer;

        public TrackingTimer(double interval = 30000,int maxCount = 5)
        {
            _count = 0;
            _maxCount = maxCount;
            _timer = new Timer(interval);
        }

        public void StartTimerForLocationTracking()
        {
            using (new BackgroundTaskHelper())
            {
                _timer.Elapsed += TimerOnElapsedForLcationUpdate;
                _timer.Start();
            }
        }

        private void TimerOnElapsedForLcationUpdate(object o, ElapsedEventArgs elapsedEventArgs)
        {
            _count++;
            Console.WriteLine(_count);
            if (_count == _maxCount)
            {
                LocationManager.LocationTracked(0, 0, new DateTime());
                Stop();
            }
        }

        public void Stop()
        {
            if(_timer == null)
                return;

            _timer.Stop();
            _timer.Close();
            _timer.Dispose();
        }
    }
}
