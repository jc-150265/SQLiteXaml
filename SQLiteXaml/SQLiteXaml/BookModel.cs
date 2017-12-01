﻿using System;
using System.Collections.Generic;
using SQLite;

//参考url http://dev-suesan.hatenablog.com/entry/2017/03/06/005206
//SQLメソッドの参考url https://www.tmp1024.com/programming/use-sqlite

namespace SQLiteXaml
{
    //テーブル名を指定
    [Table("Book")]
    public class BookModel
    {
        //プライマリキー　自動採番されます
        [PrimaryKey, AutoIncrement, Column("_id")]
        //idカラム 主キー
        public int Id { get; set; }
        //名前カラム
        public string Name { get; set; }

        //Bookテーブルに行追加するメソッドです
        //------------------------Insert文的なの--------------------------
        public static void insertBook(string name)
        {
            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースにBookテーブルを作成します
                    db.CreateTable<BookModel>();

                    //Bookテーブルに行追加します
                    db.Insert(new BookModel() { Name = name }); //受け取ったnameをNameに入れる

                    db.Commit();

                }
                catch (Exception e)
                {

                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);

                }
            }
        }
        /*
        //id name オーバーロード
        public static void insertBook(int id, string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<BookModel>();

                    db.Insert(new BookModel() { Name = name, Id = id });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }
        */

        //Bookテーブルのbookを削除するメソッド (今は全削除)
        //--------------------------delete文的なの--------------------------
        public static void deleteBook(int id)
        {

            //データベースに接続
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                db.BeginTransaction();  //このサイト https://qiita.com/alzybaad/items/9356b5a651603a548278
                try
                {
                    db.CreateTable<BookModel>();
                    db.DropTable<BookModel>();

                    //db.Delete(id);
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }

        }


        //Bookテーブルの行データを取得します
        //--------------------------select文的なの--------------------------
        public static List<BookModel> selectBook()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行します
                    return db.Query<BookModel>("SELECT * FROM [Book]");

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

    }
}
