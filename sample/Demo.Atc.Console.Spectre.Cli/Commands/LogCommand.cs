// ReSharper disable SwitchStatementHandlesSomeKnownEnumValuesWithDefault
namespace Demo.Atc.Console.Spectre.Cli.Commands;

public class LogCommand : Command<LogCommandSettings>
{
    private readonly ILogger<LogCommand> logger;

    public LogCommand(ILogger<LogCommand> logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public override int Execute(CommandContext context, LogCommandSettings settings)
    {
        var logLevel = Enum<LogLevel>.Parse(settings.LogLevel);
        switch (logLevel)
        {
            case LogLevel.Trace:
                logger.LogTrace(settings.Message);
                break;
            case LogLevel.Debug:
                logger.LogDebug(settings.Message);
                break;
            case LogLevel.Information:
                logger.LogInformation(settings.Message);
                break;
            case LogLevel.Warning:
                logger.LogWarning(settings.Message);
                break;
            case LogLevel.Error:
                logger.LogError(settings.Message);
                break;
            case LogLevel.Critical:
                logger.LogCritical(settings.Message);
                break;
            default:
                throw new SwitchCaseDefaultException(logLevel);
        }

        return ConsoleExitStatusCodes.Success;
    }
}