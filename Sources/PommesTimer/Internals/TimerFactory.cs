using PommesTimer.Exceptions;
using PommesTimer.Interfaces;

namespace PommesTimer.Internals
{
    class TimerFactory : ITimerFactory
    {
        public ISimpleTimer CreateSimpleTimer(
            Action<double> callback,
            double value,
            double steps = 1,
            double delay = 0,
            double tickRate = 1)
        {
            if (steps > value)
            {
                throw new StepsToBigException("Step can't be bigger than value");
            }
            
            return new SimpleTimer(callback, value, steps, delay, tickRate);
        }

        public IComplexTimer CreateComplexTimer(
            Action<double, double> callback, 
            double value, 
            double steps = 1, 
            double delay = 0, 
            double tickRate = 1)
        {
            if (steps > value)
            {
                throw new StepsToBigException("Step can't be bigger than value");
            }

            return new ComplexTimer(callback, value, steps, delay, tickRate);
        }
    }
}