using System.ComponentModel;

namespace PommesTimer.Interfaces
{
    public interface ISimpleTimer : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the finished state of the timer
        /// </summary>
        bool IsFinished { get; }
    }
}