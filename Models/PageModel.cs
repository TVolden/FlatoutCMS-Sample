using FlatoutCMS.Core.Content;

namespace FlatoutCMS_Sample.Models
{
    public class PageModel : IPageModel
    {
        public string View { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
