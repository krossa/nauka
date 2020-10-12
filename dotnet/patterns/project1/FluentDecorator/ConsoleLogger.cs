namespace patterns.FluentDecorator
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void LogInformation(string msg)
        {
            System.Console.WriteLine(msg);
        }
    }
}