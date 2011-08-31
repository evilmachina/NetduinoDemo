using System.Threading;

namespace DemoNetduino
{
    public class Program
    {
        public static void Main()
        {
            var r = new DistansDetector();
            r.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}