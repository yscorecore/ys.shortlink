using YS.Knife;

namespace YS.ShortLink.Impl
{
    [OptionsClass]
    public class ShortLinkOptions
    {
        public string HostAddress { get; set; } = "http://localhost";

        public string NotFoundPage { get; set; } = "http://localhost/pages/notfound.html";
    }
}
