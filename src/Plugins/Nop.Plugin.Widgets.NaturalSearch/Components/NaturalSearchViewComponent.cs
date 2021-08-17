using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.NaturalSearch.Components
{
    [ViewComponent(Name = PluginDefaults.NATURAL_SEARCH_COMPONENT)]
    public class NaturalSearchViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public NaturalSearchViewComponent(
          IStoreContext storeContext,
          ISettingService settingService)
        {
            _storeContext = storeContext;
            _settingService = settingService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var settings = await _settingService.LoadSettingAsync<PluginSettings>(store.Id);

            return View($"~/Plugins/{PluginDefaults.SYSTEM_NAME}/Views/PublicInfo.cshtml");
        }
    }
}
