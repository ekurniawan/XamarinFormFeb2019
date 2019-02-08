using Plugin.NetStandardStorage.Abstractions.Interfaces;
using Plugin.NetStandardStorage.Implementations;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinWithPostgres.Models;

namespace XamarinWithPostgres.DAL
{
    public class DataAccess
    {
        SQLiteConnection database;

        public SQLiteConnection GetConnection()
        {
            SQLiteConnection sqliteConnection;
            var sqliteFileName = "mydb.db3";
            IFolder folder = new FileSystem().LocalStorage;
            string path = Path.Combine(folder.FullPath, sqliteFileName);
            sqliteConnection = new SQLiteConnection(path);
            return sqliteConnection;
        }

        public DataAccess()
        {
            database = GetConnection();
            database.CreateTable<RestaurantSqlite>();
        }


    }
}
