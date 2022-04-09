
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PMDVoices2SQLite
{
    /// <summary>
    /// 全ての東方旧作PMD楽曲から各音色を抽出したデータ
    /// </summary>
    [Serializable]
    public record AllZUNVoice : PMDVoice
    {
        #region プロパティ
        /// <summary>
        /// 主キー（プライマリキー）
        /// </summary>
        //[Key]
        //public int AllZUNVoiceID { get; set; }

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

        #endregion
        #region コンストラクタ
        public AllZUNVoice()
        {
        }

        public AllZUNVoice(PMDVoice original) : base(original)
        {
            MMLFileName = original.MMLFileName;
            RemoveDotMML();
        }
        #endregion

        #region メソッド
        public string RemoveDotMML()
        {
            if (string.IsNullOrEmpty(MMLFileName)) return string.Empty;
            MMLFileName = (MMLFileName).Replace(".MML", "");
            MMLFileName = (MMLFileName).Replace(".mml", "");
            return MMLFileName;

        }
        #endregion
    }

    /// <summary>
    /// AllZUNVoiceを対象としたメソッドのクラス
    /// </summary>
    public static class AllZUNVoiceMethod
    {

    }
}