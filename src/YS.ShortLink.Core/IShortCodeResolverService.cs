using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YS.ShortLink
{
    public interface IShortCodeResolverService { 
        Task<(bool Exists, string Url)> ResolveShort(string shortCode);
    }
}
