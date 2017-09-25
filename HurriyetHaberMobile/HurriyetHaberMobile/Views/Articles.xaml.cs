using HurriyetHaberMobile.Core;
using HurriyetHaberMobile.Model;
using HurriyetHaberMobile.Provider;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HurriyetHaberMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Articles : ContentPage
    {
        private int coumter = 0;
        public Articles()
        {
            InitializeComponent();
            HurriyetApi api = new HurriyetApi();
            var articlesJson = api.Get($"v1/articles?$top=10&$skip={coumter * 10}");

            JsonModelMapper<ArticlesModel> jsonModel = new JsonModelMapper<ArticlesModel>();
            var articles = jsonModel.GetList(articlesJson);

            var items = articles
                .Where(q => q.Files.Count > 0)
                .Select(s => new ArticlesListViewModel
                {
                    Id = s.Id,
                    FileUrl = s.Files.FirstOrDefault().FileUrl,
                    Title = s.Title,
                    Path = $"{s.Path.TagSubstring()} - {s.ModifiedDate.ToDate().ToString("dd.MM.yyyy HH:ss")}",
                    Tags = s.Tags.Count > 0 ? $"Tags : {s.Tags.StringListToString()}" : string.Empty
                }).ToList();

            listView.ItemsSource = items;
            listView.ItemSelected += ListView_ItemSelected;
        }

       

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            ArticlesListViewModel selectedItem = (ArticlesListViewModel)e.SelectedItem;

            //navigate to Detail page
            await Navigation.PushModalAsync(new Detail(selectedItem));

            var lv = (ListView)sender;
            lv.SelectedItem = null;
        }
    }
}