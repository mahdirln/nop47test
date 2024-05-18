using Nop.Core.Caching;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Configuration;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.News;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Polls;
using Nop.Core.Domain.Topics;
using Nop.Core.Domain.Vendors;
using Nop.Core.Events;
using Nop.Services.Catalog;
using Nop.Services.Cms;
using Nop.Services.Events;
using Nop.Services.Logging;
using Nop.Services.Plugins;
using Nop.Web.Framework.Models.Cms;

namespace Nop.Plugin.Misc.PluginTest.Infrastructure;

/// <summary>
/// Model cache event consumer (used for caching of presentation layer models)
/// </summary>
public partial class EventConsumer :
    //products
    IConsumer<EntityInsertedEvent<Product>>
{
    #region Fields

    protected readonly IProductService _productService;
    protected readonly ILogger _logger;
    protected readonly PluginTestSettings _pluginTestSettings;

    #endregion

    #region Ctor

    public EventConsumer(IProductService productService,
        ILogger logger,
        PluginTestSettings pluginTestSettings)
    {
        _productService = productService;
        _logger = logger;
        _pluginTestSettings = pluginTestSettings;
    }

    #endregion

    #region Methods

    #region Products

    public async Task HandleEventAsync(EntityInsertedEvent<Product> eventMessage)
    {
        var product = eventMessage.Entity;

        product.ShortDescription += _pluginTestSettings.ProductDescription;

        await _productService.UpdateProductAsync(product);

        _logger.InsertLog(Core.Domain.Logging.LogLevel.Information, "توضیحات pluginTest به محصول جدید اضافه شد - product id = " + product.Id);
    }

    #endregion

    #endregion
}