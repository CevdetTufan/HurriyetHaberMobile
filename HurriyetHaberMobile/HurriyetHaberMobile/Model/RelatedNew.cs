using System.Collections.Generic;

namespace HurriyetHaberMobile.Model
{
    public class RelatedNew
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public List<FilesModel> Files { get; set; }
        public List<RelatedNew> RelatedNews { get; set; }
        public string StartDate { get; set; }
        public List<string> Tags { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public List<string> Writers { get; set; }
    }
}
