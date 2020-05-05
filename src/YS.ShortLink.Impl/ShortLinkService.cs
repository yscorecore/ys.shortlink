using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using YS.Cache;
using YS.Knife;
using YS.Sequence;

namespace YS.ShortLink.Impl
{
    [ServiceClass(typeof(IShortLinkService))]
    [ServiceClass(typeof(IShortCodeResolverService))]
    public class ShortLinkService : IShortLinkService, IShortCodeResolverService
    {
        const string SEQUENCE_KEY = "SHORT_LINK";
        public ShortLinkService(IOptions<ShortLinkOptions> options, ICacheService cacheService, ISequenceService sequenceService)
        {
            this.options = options.Value;
            this.cacheService = cacheService;
            this.sequenceService = sequenceService;
        }
        private ShortLinkOptions options;
        private ICacheService cacheService;
        private ISequenceService sequenceService;
        public async Task<(bool Exists, string Url)> ResolveShort(string shortCode)
        {
            var data = await cacheService.Get<string>(shortCode);
            return (data.Exists, data.Value ?? options.NotFoundPage);
        }

        public async Task<string> ToShort(string link)
        {
            if (link.StartsWith(options.HostAddress, StringComparison.InvariantCultureIgnoreCase))
            {
                return link;
            }
            var cache = await cacheService.Get<string>(link);
            if (cache.Exists)
            {
                return GetFullUrl(cache.Value);
            }
            var sequence = await sequenceService.GetOrCreateValue(SEQUENCE_KEY, new SequenceInfo() { Step = 1 });
            var shortcode = Hex62Convert.ConvertDecToHex62(sequence);
            await cacheService.Set(shortcode, link, TimeSpan.FromDays(30));
            await cacheService.Set(link, shortcode, TimeSpan.FromDays(30));
            return GetFullUrl(shortcode);
        }
        private string GetFullUrl(string shortcode)
        {
            return $"{options.HostAddress.TrimEnd('/', '\\')}/{shortcode}";
        }
    }
}
