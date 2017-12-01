using System;
using Xamarin.Forms;

namespace SQLiteXaml
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };

            //Bookテーブルに適当なデータを追加
            BookModel.insertBook("Test");
            //↑この辺をボタンに突っ込む

            //Bookテーブルの行データを取得
            var query = BookModel.selectBook();

            foreach (var book in query)
            {
                //Userテーブルの名前列をLabelに書き出します
                layout.Children.Add(new Label { Text = book.Name });
            }

            Content = layout;

        }
        /*
        public MainPage()
        {
            InitializeComponent();
            //Insertボタンイベントハンドラ
            private void InsertClicked(object sender, EventArgs e)
            {
                string book = insert.Text;
                BookModel.insertBook(book); //Entryで受け取った値をInsertする
            }

            //Deleteボタンイベントハンドラ
            private void DeleteClicked(object sender, EventArgs e)
            {
                BookModel.deleteBook(1);
                //int book = int.Parse(delete.Text);
                //BookModel.deleteBook(book);
            }

            //Selectボタンイベントハンドラ
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
        */
    }
}
