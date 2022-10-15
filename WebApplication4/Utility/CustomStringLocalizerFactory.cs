using Microsoft.Extensions.Localization;
using Services.Repository;

namespace Localization.Utility
{
    public class CustomStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ILocalizationServices _localizationService;
        public CustomStringLocalizerFactory(ILocalizationServices localizationService)
        {
            _localizationService = localizationService;
        }
        public IStringLocalizer Create(Type resourceSource)
        {
            return new CustomStringLocalizer(_localizationService);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            return new CustomStringLocalizer(_localizationService);
        }
    }
}
