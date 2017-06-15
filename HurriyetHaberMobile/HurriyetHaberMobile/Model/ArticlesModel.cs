using System.Collections.Generic;

namespace HurriyetHaberMobile.Model
{
    public class ArticlesModel
    {
        public string Id { get; set; }
        public string ContentType { get; set; }
        public string CreatedDate { get; set; }
        public string Description { get; set; }
        public List<FilesModel> Files { get; set; }
        public string ModifiedDate { get; set; }
        public string Path { get; set; }
        public string StartDate { get; set; }
        public List<string> Tags { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
