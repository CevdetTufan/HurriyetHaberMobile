using HurriyetHaberMobile.Core;
using HurriyetHaberMobile.Model;
using HurriyetHaberMobile.Provider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HurriyetHaberMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Articles : ContentPage
    {
        public Articles()
        {
            InitializeComponent();
            HurriyetApi api = new HurriyetApi();
            var articlesJson = api.Get("v1/articles");

            JsonModelMapper<ArticlesModel> jsonModel = new JsonModelMapper<ArticlesModel>();
            var articles = jsonModel.GetList(articlesJson);

            var items = articles
                .Where(q => q.Files.Count > 0)
                .Select(s => new ArticlesListViewModel
                {
                    Id = s.Id,
                    FileUrl = s.Files.FirstOrDefault().FileUrl,
                    Title = s.Title,
                    Path = s.Path
                }).Take(10).ToList();

            listView.ItemsSource = items;
        }


        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            ArticlesListViewModel selectedItem = (ArticlesListViewModel)e.SelectedItem;

            //navigate to Detail page
            await Navigation.PushModalAsync(new Detail(selectedItem));

            var lv=(ListView)sender;
            lv.SelectedItem = null;
        }
    }
}
