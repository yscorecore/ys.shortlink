using System;
using System.Threading.Tasks;

namespace YS.ShortLink
{
    public interface IShortLinkService
    {
        Task<string> ToShort(string url);
    }
}
