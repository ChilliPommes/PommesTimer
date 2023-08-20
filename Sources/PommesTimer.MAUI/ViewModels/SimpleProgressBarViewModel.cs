using PommesTimer.Initialization;
using PommesTimer.Interfaces;

namespace PommesTimer.MAUI.ViewModels
{
    public sealed class SimpleProgressBarViewModel : BaseProgressBarViewModel
    {
        private readonly ISimpleTimer _simpleTimer;

        public SimpleProgressBarViewModel(
            Action doneBehavior,
            string name,
            double value,
            double steps = 1) :
        base(doneBehavior, name)
        {
            _simpleTimer = FactoryInitializer.CreateFactory().CreateSimpleTimer(
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
        /// Callback method to get value from timer tick into ui
        /// </summary>
        /// <param name="progress">Progress of timer in percentage</param>
        private void PublishProgress(double progress)
        {
            Progress = Math.Round(progress / 100, 5);
        }
    }
}