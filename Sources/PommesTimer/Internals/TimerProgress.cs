namespace PommesTimer.Internals
{
    /// <summary>
    /// Internal class to handle progress storage and calculation of a timer object
    /// </summary>
    sealed class TimerProgress
    {
        /// <summary>
        /// Event to hook up for the timer which published its finished state
        /// </summary>
        public event EventHandler? LimitReached;
        
        private double _progress;
        private double _steps;
        private double _limit;

        /// <summary>
        /// Constructor which sets the base value which are needed for the progress calculation
        /// </summary>
        /// <param name="limit">The maximum amount which needs to be reached by the timer loop</param>
        /// <param name="steps">The step size in which the timer will add after each loop</param>
        public TimerProgress(
            double limit,
            double steps)
        {
            _limit = limit;
            _steps = steps;
        }

        /// <summary>
        /// The Percentage reached in the progress
        /// </summary>
        public double Percentage => _progress / (_limit / Constants.MAX_PERCENTAGE);

        /// <summary>
        /// The amount of steps needed to reached at least 99.9% progress
        /// </summary>
        public double AmountOfSteps => _limit / _steps;

        /// <summary>
        /// The count of loops which are already done
        /// </summary>
        public double LoopCount => Math.Abs(_progress / _steps);

        /// <summary>
        /// Runs through the internal loop and adds one step size to the progress
        /// </summary>
        public void Loop()
        {
            _progress += _steps;

            if (_progress >= _limit)
            {
                InvokeLimitReached();
            }
        }

        /// <summary>
        /// Invokes the limit reached event
        /// </summary>
        private void InvokeLimitReached()
        {
            LimitReached?.Invoke(this, EventArgs.Empty);
        }
    }
}