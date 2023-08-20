using PommesTimer.Interfaces;
using PommesTimer.Internals;

namespace PommesTimer.Initialization
{
    public static class FactoryInitializer
    {
        public static ITimerFactory CreateFactory() => new TimerFactory();
    }
}