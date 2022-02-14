using System.Globalization;
using System.Threading;

namespace Bakery
{
    using Bakery.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Don't forget to comment out the commented code lines in the Engine class!
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Gb");
            var engine = new Engine();

            engine.Run();
        }
    }
}
