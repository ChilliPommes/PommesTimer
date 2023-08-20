using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PommesTimer.MAUI.ViewModels
{
    public class BaseProgressBarViewModel : ObservableObject
    {
        private double _progress;
        private bool _isDone;

        public BaseProgressBarViewModel(
            Action doneBehavior,
            string name)
        {
            Name = name.Length > 36 ? name.Substring(0, 36) + ".." : name;

            DoneTapCommand = new Command(() =>
            {
                Task.Delay(300).ContinueWith(_ =>
                {
                    doneBehavior();
                });
            });
        }
        
        /// <summary>
        /// Property to publish the name of the timer item to the ui
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Property to publish the progress of the timer to the ui
        /// </summary>
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        /// <summary>
        /// Property to publish the done state to the ui
        /// </summary>
        public bool IsDone
        {
            get => _isDone;
            set => SetProperty(ref _isDone, value);
        }
        
        /// <summary>
        /// Property to connect application behavior with tap event onto ui
        /// </summary>
        public ICommand DoneTapCommand { get; init; }
    }
}