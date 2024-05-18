using Nop.Core;
using Nop.Plugin.Misc.PluginTest;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace Nop.Plugin.Widgets.NivoSlider;

/// <summary>
/// PLugin
/// </summary>
public class NivoSliderPlugin : BasePlugin
{
    protected readonly ILocalizationService _localizationService;
    protected readonly ISettingService _settingService;
    protected readonly IWebHelper _webHelper;

    public NivoSliderPlugin(ILocalizationService localizationService,
        ISettingService settingService,
        IWebHelper webHelper)
    {
        _localizationService = localizationService;
        _settingService = settingService;
        _webHelper = webHelper;
    }

    /// <summary>
    /// Gets a configuration page URL
    /// </summary>
    public override string GetConfigurationPageUrl()
    {
        return _webHelper.GetStoreLocation() + "Admin/PluginTest/Configure";
    }

    /// <summary>
    /// Install plugin
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    public override async Task InstallAsync()
    {
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            ["Plugins.Misc.PluginTest.ProductDescription"] = "توضیحات محصول",
            ["Plugins.Misc.PluginTest.ProductDescription.Hint"] = "متن نوشته شده به انتهای توضیحات کوتاه محصول ایجاد شده اضافه می شود",
        });

        await base.InstallAsync();
    }

    /// <summary>
    /// Uninstall plugin
    /// </summary>
    /// <returns>A task that represents the asynchronous operation</returns>
    public override async Task UninstallAsync()
    {
        //settings
        await _settingService.DeleteSettingAsync<PluginTestSettings>();

        //locales
        await _localizationService.DeleteLocaleResourcesAsync("Plugins.Misc.PluginTest");

        await base.UninstallAsync();
    }

    /// <summary>
    /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
    /// </summary>
    public bool HideInWidgetList => false;
}