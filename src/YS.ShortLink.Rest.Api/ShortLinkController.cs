using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.Knife.Rest.Api;

namespace YS.ShortLink.Rest.Api
{
    [Route("short")]
    public class ShortLinkController : ApiBase<IShortLinkService>, IShortLinkService
    {
        [HttpPost]
        public Task<string> ToShort([FromQuery]string url)
        {
            return this.Delegater.ToShort(url);
        }
    }
}
