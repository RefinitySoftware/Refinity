namespace RefinityHandler;
/// <summary>
/// Represents an error handler that handles unhandled exceptions in the application.
/// </summary>
public class ErrorHandler
{
    /// <summary>
    /// Initializes a new instance of the ErrorHandler class.
    /// </summary>
    public ErrorHandler()
    {
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(RefinityHandler);
    }

    /// <summary>
    /// Handles the unhandled exception.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="args">The event data.</param>
    void RefinityHandler(object sender, UnhandledExceptionEventArgs args)
    {
        Exception e = (Exception)args.ExceptionObject;
        Console.WriteLine("Refinity has encountered an unhandled exception. Please report this to the developer.");
    }
}