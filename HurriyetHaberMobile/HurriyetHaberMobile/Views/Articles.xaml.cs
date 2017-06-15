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
                .Select(s => new
                {
                    FileUrl = s.Files.FirstOrDefault().FileUrl,
                    Title = s.Title
                }).Take(10).ToList();

            listView.ItemsSource = items;
        }
    }
}
