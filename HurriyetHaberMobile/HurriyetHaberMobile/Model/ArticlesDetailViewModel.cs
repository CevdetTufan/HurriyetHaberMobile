using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HurriyetHaberMobile.Model
{
    public class ArticlesDetailViewModel
    {
        public List<FilesModel> Images { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
