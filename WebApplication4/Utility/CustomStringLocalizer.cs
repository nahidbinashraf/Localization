using Microsoft.Extensions.Localization;
using Services.Repository;

namespace Localization.Utility
{
    public class CustomStringLocalizer : IStringLocalizer
    {
        private readonly ILocalizationServices _localizationService;
        public CustomStringLocalizer(ILocalizationServices localizationService)
        {
            _localizationService = localizationService;
        }
        public LocalizedString this[string name]
        {
            get
            {
                var value = _localizationService.GetResourceValue(name);
                return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = _localizationService.GetResourceValue(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, resourceNotFound: format == null);
            }
        }
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
           return
                _localizationService.GetAllStrings()
                .Select(r => new LocalizedString(r.Key, r.Value, true));
        }
    }
}
