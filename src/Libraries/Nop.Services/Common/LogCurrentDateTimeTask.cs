using Nop.Services.Logging;
using Nop.Services.ScheduleTasks;

namespace Nop.Services.Common;

public partial class LogCurrentDateTimeTask : IScheduleTask
{
    #region Fields

    protected readonly ILogger _logger;

    #endregion

    #region Ctor

    public LogCurrentDateTimeTask(ILogger logger)
    {
        _logger = logger;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Executes a task
    /// </summary>
    public async Task ExecuteAsync()
    {
        await _logger.InsertLogAsync(Core.Domain.Logging.LogLevel.Information, "تاریخ و زمان جاری: " + DateTime.UtcNow.ToString());
    }

    #endregion
}