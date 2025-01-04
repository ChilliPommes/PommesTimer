using PommesTimer.Initialization;
using PommesTimer.Interfaces;

namespace PommesTimer.MAUI.ViewModels
{
    public sealed class ComplexProgressBarViewModel : BaseProgressBarViewModel
    {
        private readonly IComplexTimer _simpleTimer;
        
        private double _time;

        public ComplexProgressBarViewModel(
            Action doneBehavior,
            string name,
            double value,
            double steps = 1) : 
            base(doneBehavior, name)
        {
            _simpleTimer = FactoryInitializer.CreateFactory().CreateComplexTimer(
                PublishProgress,
                value,
                steps);

            _simpleTimer.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName?.Equals(nameof(_simpleTimer.IsFinished)) == true)
                {
                    IsDone = true;
                }
            };
        }

        /// <summary>
        /// Property to publish the remaining time of the timer to the ui
        /// </summary>
        public double Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        /// <summary>
        /// Callback method to get value from timer tick into ui
        /// </summary>
        /// <param name="progress">Progress of timer in percentage</param>
        /// <param name="time">Time of the timer in seconds</param>
        private void PublishProgress(double progress, double time)
        {
            Progress = Math.Round(progress / 100, 5);
            Time = time;
        }
    }
}