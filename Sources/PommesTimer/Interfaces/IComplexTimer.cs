using System.ComponentModel;

namespace PommesTimer.Interfaces
{
    public interface IComplexTimer : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the finished state of the timer
        /// </summary>
        bool IsFinished { get; }
    }
}