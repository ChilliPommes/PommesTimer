namespace PommesTimer.Interfaces
{
    public interface ITimerFactory
    {
        /// <summary>
        /// Creates a simple timer object with given parameters
        /// </summary>
        /// <param name="callback">Callback for the creating part of the timer to track progress</param>
        /// <param name="value">Value which should be reached by timer loop</param>
        /// <param name="steps">Step size for the looper</param>
        /// <param name="delay">Delay of the timer start</param>
        /// <param name="tickRate">Frequency of the timer tick</param>
        /// <returns><see cref="ISimpleTimer"/></returns>
        public ISimpleTimer CreateSimpleTimer(
            Action<double> callback,
            double value, 
            double steps = 1,
            double delay = 0, 
            double tickRate = 1);

        /// <summary>
        /// Creates a complex timer object with given parameters
        /// </summary>
        /// <param name="callback">Callback for the creating part of the timer to track progress</param>
        /// <param name="value">Value which should be reached by timer loop</param>
        /// <param name="steps">Step size for the looper</param>
        /// <param name="delay">Delay of the timer start</param>
        /// <param name="tickRate">Frequency of the timer tick</param>
        /// <returns><see cref="IComplexTimer"/></returns>
        public IComplexTimer CreateComplexTimer(
            Action<double, double> callback,
            double value, 
            double steps = 1, 
            double delay = 0, 
            double tickRate = 1);
    }
}