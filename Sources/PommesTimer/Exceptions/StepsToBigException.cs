namespace PommesTimer.Exceptions
{
    /// <summary>
    /// Custom exception to handle logic wise errors
    /// </summary>
    public class StepsToBigException : Exception
    {
        /// <summary>
        /// Default constructor with message which is given to exception base
        /// </summary>
        /// <param name="message">Reason of exception</param>
        public StepsToBigException(string message) : base(message)
        {
        }
    }
}