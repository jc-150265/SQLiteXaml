using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteXaml
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Insertメソッド
        private void InsertClicked(object sender, EventArgs e)
        {
            string book = insert.Text; 
            BookModel.insertBook(book); //Entryで受け取った値をInsertする
        }

        //Deleteメソッド
        private void DeleteClicked(object sender, EventArgs e)
        {
            BookModel.deleteBook(1);
            //int book = int.Parse(delete.Text);
            //BookModel.deleteBook(book);
        }

        //Selectメソッド
        private void SelectClicked(object sender, EventArgs e)
        {
            //Bookテーブルの行データを取得
            var query = BookModel.selectBook(); //中身はSELECT * FROM [Book]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }
            Content = layout;
        }
    }
}
