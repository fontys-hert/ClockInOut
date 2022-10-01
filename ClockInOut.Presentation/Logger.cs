using ClockInOut.Bll;

namespace ClockInOut.Presentation
{
    internal class Logger : ILogger
    {
        public void Write(string name)
        {
            Console.WriteLine(name);
        }
    }
}
