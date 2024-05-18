using FluentMigrator;
using LinqToDB;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.ScheduleTasks;
using Nop.Core.Domain.Security;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.UpgradeTo470;

[NopUpdateMigration("2024-05-18 00:00:00", "4.70 TaskSchedule", UpdateMigrationType.Data)]
public class DataMigrationTaskSchedule : Migration
{
    private readonly INopDataProvider _dataProvider;

    public DataMigrationTaskSchedule(INopDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        var scheduleTask = _dataProvider.GetTable<ScheduleTask>();
        if (!scheduleTask.Any(alt => alt.Name == "Log current DateTime"))
            _dataProvider.InsertEntity(
                new ScheduleTask
                {
                    Name = "Log current DateTime",
                    Type = "Nop.Services.Common.LogCurrentDateTimeTask, Nop.Services",
                    Seconds = 600,
                    Enabled = true,
                    StopOnError = false
                }
            );
    }

    public override void Down()
    {
        //add the downgrade logic if necessary 
    }
}