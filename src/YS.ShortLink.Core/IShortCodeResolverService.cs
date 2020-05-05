using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YS.ShortLink
{
    public interface IShortCodeResolverService { 
        Task<string> ResolveShort(string shortCode);
    }
}
