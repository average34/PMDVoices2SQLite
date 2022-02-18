using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDVoices2SQLite
{
    internal class PMDVoicesContext : DbContext
    {
        public DbSet<PMDVoice>? Voices { get; set; }

        public string DbPath { get; }

        public PMDVoicesContext()
        {
            // 特殊フォルダ（デスクトップ）の絶対パスを取得
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // DBファイルの保存先とDBファイル名
            DbPath = $"{path}{Path.DirectorySeparatorChar}PMDVoices.sqlite3";
        }

        // デスクトップ上にSQLiteのDBファイルが作成される
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
