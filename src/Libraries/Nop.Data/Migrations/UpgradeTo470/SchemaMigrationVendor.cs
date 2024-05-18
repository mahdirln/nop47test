using FluentMigrator;
using FluentMigrator.Runner.Generators.Base;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Forums;
using Nop.Core.Domain.Logging;
using Nop.Core.Domain.Messages;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Vendors;
using Nop.Data.Extensions;
using Nop.Data.Mapping;

namespace Nop.Data.Migrations.UpgradeTo470;

[NopSchemaMigration("2024-05-18 15:00:00", "SchemaMigration vendor for 4.70.0")]
public class SchemaMigrationVendor : ForwardOnlyMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        var vendorTableName = nameof(Vendor);
        if (!Schema.Table(vendorTableName).Column("StoreName").Exists())
            Alter.Table(vendorTableName)
                .AddColumn("StoreName").AsString(250).Nullable();
    }
}