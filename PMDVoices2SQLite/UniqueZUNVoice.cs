using System.ComponentModel.DataAnnotations;

namespace PMDVoices2SQLite
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public record UniqueZUNVoice : PMDVoiceCore
    {
        /// <summary>
        /// このデータベースで付与した一意のキー
        /// 例えば「歴代で1番目に出現した@250」は1250、
        /// 「歴代で2番目に出現した@250」は2250、というように、
        /// 1000*同音色番号の音色数 + 音色番号 の形を取る。
        /// またIDは必ず1000以上とする。
        /// </summary>
        [Key]
        public int UniqueZunVoiceID { get; set; }

        /// <summary>
        /// PMDプリセットに存在する音色かどうか　≒神主自作の音色でないかどうか
        /// (0:チェックしてない -1:無いことを確認済み 1:存在する)
        /// </summary>
        public short IsInPMDPreset { get; set; }
        public string PrisetFileName { get; set; }
        public string PrisetComment { get; set; }
    }
}
