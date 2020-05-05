using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using YS.Knife;

namespace YS.ShortLink.Impl
{
    [ServiceClass(typeof(IShortLinkService), ServiceLifetime.Singleton)]
    [ServiceClass(typeof(IShortCodeResolverService), ServiceLifetime.Singleton)]
    public class ShortLinkService : IShortLinkService, IShortCodeResolverService
    {
        public Task<string> ResolveShort(string shortCode)
        {
            return Task.FromResult($"..{shortCode}");
        }

        public Task<string> ToShort(string link)
        {
            return Task.FromResult($"_{link}");
        }
    }
}
