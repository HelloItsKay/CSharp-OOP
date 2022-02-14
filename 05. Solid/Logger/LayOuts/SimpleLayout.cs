
namespace LoggerLibrary.LayOuts
{
    using LoggerLibrary.interfaces;
    public class SimpleLayout: ILayout

    {
        public string Template => "{0} - {1} - {2}";
    }
}





