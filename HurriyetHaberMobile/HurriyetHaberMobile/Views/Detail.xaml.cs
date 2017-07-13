using HurriyetHaberMobile.Core;
using HurriyetHaberMobile.Model;
using HurriyetHaberMobile.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HurriyetHaberMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detail : ContentPage
	{
		public Detail (ArticlesListViewModel model)
		{
			InitializeComponent ();

            HurriyetApi api = new HurriyetApi();
            var articlesJson = api.Get($"v1/articles/{model.Id}");

            JsonModelMapper<ArticlesDetailModel> jsonModel = new JsonModelMapper<ArticlesDetailModel>();
            var article = jsonModel.GetItem(articlesJson);

            cvImages.ItemsSource = article.Files;
            lblTitle.Text = article.Title;
        }
        public Detail()
        {
            InitializeComponent();

            HurriyetApi api = new HurriyetApi();
            var articlesJson = api.Get($"v1/articles/40518710");

            JsonModelMapper<ArticlesDetailModel> jsonModel = new JsonModelMapper<ArticlesDetailModel>();
            var article = jsonModel.GetItem(articlesJson);

            cvImages.ItemsSource = article.Files;
            lblTitle.Text = article.Title;
        }
	}
}
