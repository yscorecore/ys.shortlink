using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YS.Knife.Rest.Api;

namespace YS.ShortLink.Rest.Api
{
    [Route("/")]

    public class RedirectController : ApiBase<IShortCodeResolverService>
    {
        [HttpGet("/{shortCode}")]
        public async Task<ActionResult> ResolveShort(string shortCode)
        {
            var data = await this.Delegater.ResolveShort(shortCode);
            return new RedirectResult(data.Url, data.Exists, true);
        }
    }
}
