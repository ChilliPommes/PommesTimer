using System.ComponentModel;
using System.Runtime.CompilerServices;
using PommesTimer.Interfaces;

namespace PommesTimer.Internals
{
    class ComplexTimer : IComplexTimer
    {
        /// <summary>
        /// Event impl. of INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        private bool _isFinished;

        private readonly TimerProgress _timerProgress;

        private readonly Timer _timer;

        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly double _totalSeconds;
        
        /// <summary>
        /// Constructs a simple timer with given values
        /// </summary>
        /// <param name="callback">Callback for the creating part of the timer to track progress</param>
        /// <param name="value">Value which should be reached by timer loop</param>
        /// <param name="steps">Step size for the looper</param>
        /// <param name="delay">Delay of the timer start</param>
        /// <param name="tickRate">Frequency of the timer tick in seconds</param>
        public ComplexTimer(
            Action<double, double> callback,
            double value,
            double steps = 1, 
            double delay = 0, 
            double tickRate = 1)
        {
            _timerProgress = new TimerProgress(value, steps);
            _timerProgress.LimitReached += (_, _) =>
            {
                IsFinished = true;
                _timer!.Dispose();
            };

            _totalSeconds = _timerProgress.AmountOfSteps * tickRate;

            _timer = new Timer(
                obj =>
                {
                    if (obj is TimerProgress timerProgress)
                    {
                        timerProgress.Loop();

                        var remainingSeconds = _totalSeconds - timerProgress.LoopCount * tickRate;
                        callback(timerProgress.Percentage, remainingSeconds);
                    }
                },
                _timerProgress,
                TimeSpan.FromSeconds(delay),
                TimeSpan.FromSeconds(tickRate));
        }
        
        /// <summary>
        /// Stores the finished state of the timer
        /// </summary>
        public bool IsFinished
        {
            get => _isFinished;
            private set => _ = SetField(ref _isFinished, value);
        }

        /// <summary>
        /// Invoker impl. of INotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Setter impl. of INotifyPropertyChanged
        /// </summary>
        /// <param name="field">Original value as ref</param>
        /// <param name="value">Value to be set</param>
        /// <param name="propertyName">Property name</param>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <returns>True if value could be set</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}