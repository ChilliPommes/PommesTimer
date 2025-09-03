using System.ComponentModel;

namespace PommesTimer.Interfaces
{
    public interface IComplexTimer : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the finished state of the timer
        /// </summary>
        bool IsFinished { get; }

        /// <summary>
        /// Stops the timer and marks it as finished.
        /// The timer is disposed to free resources, and the state is updated
        /// to indicate the completion of the timer process.
        /// </summary>
        void StopTimer();
    }
}