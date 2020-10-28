using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModels.Helpers
{
    public class DatabaseHelper
    {
        public static string dbFile = Path.Combine(Environment.CurrentDirectory, "noteDb.db");

        public static bool Insert<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int RowNumber = conn.Insert(item);

                result = RowNumber > 0 ? true : false;
            }
            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int RowNumber = conn.Update(item);
                result = RowNumber > 0 ? true : false;
            }
            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbFile))
            {
                conn.CreateTable<T>();
                int RowNumber = conn.Delete(item);
                result = RowNumber > 0 ? true : false;
            }
            return result;
        }
    }
}
