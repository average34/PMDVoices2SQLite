using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDVoices2SQLite
{
    public record class Voice2MusicList
    {
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// 音色データベースで付与したキー
        /// UniqueZUNVoice.UniqueZUNVoicesID に関連付けされる
        /// </summary>
        public int UniqueZUNVoicesID { get; set; }
        /// <summary>
        /// 音色番号(その曲における)
        /// </summary>
        public byte NM { get; set; }

        /// <summary>
        /// 曲名
        /// （MML内の#Title タグから取得）
        /// </summary>
        public string? MusicName { get; set; }

        /// <summary>
        /// 出展作品名
        /// （フォルダ名から取得）
        /// </summary>
        public string? WorksName { get; set; }

    }
}
