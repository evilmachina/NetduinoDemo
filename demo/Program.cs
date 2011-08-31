using System.Threading;

namespace demo_led
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
