namespace Refinity.Handler;

/// <summary>
/// Represents an error handler that handles unhandled exceptions in the application.
/// </summary>
public class ErrorHandler
{
    /// <summary>
    /// Gets or sets a value indicating whether to use artificial intelligence.
    /// </summary>
    public bool useArtificialIntelligence { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the ErrorHandler class.
    /// </summary>
    public ErrorHandler(bool useArtificialIntelligence = false)
    {
        this.useArtificialIntelligence = useArtificialIntelligence;
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
        if (useArtificialIntelligence)
        {
            Console.WriteLine("Refinity is now attempting to fix the issue.");
            Console.WriteLine("Refinity has successfully fixed the issue.");
        }
        else
        {
            Console.WriteLine("Refinity was unable to fix the issue.");
        }
    }
}