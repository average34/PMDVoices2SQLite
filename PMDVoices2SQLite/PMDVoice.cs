using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDVoices2SQLite
{
    /// <summary>
    /// PMDの1つの音色を扱うレコード
    /// </summary>
    [Serializable]
    public record struct PMDVoice
    {
        /// <summary>
        /// MMLファイルの名前です。
        /// </summary>
        public string? mmlFileName = "None";
        /// <summary>
        /// nm alg fbl の値を入力した右側の位置に存在するコメントです。
        /// = または ; から始まります。
        /// </summary>
        public string? comment = "";
        public byte nm = 0, alg = 0, fbl = 0;
        byte ar1 = 31, dr1 = 0, sr1 = 0, rr1 = 15, sl1 = 0, tl1 = 0, ks1 = 0, ml1 = 0, dt1_1 = 0, dt2_1 = 0, ams1 = 0;
        byte ar2 = 31, dr2 = 0, sr2 = 0, rr2 = 15, sl2 = 0, tl2 = 0, ks2 = 0, ml2 = 0, dt1_2 = 0, dt2_2 = 0, ams2 = 0;
        byte ar3 = 31, dr3 = 0, sr3 = 0, rr3 = 15, sl3 = 0, tl3 = 0, ks3 = 0, ml3 = 0, dt1_3 = 0, dt2_3 = 0, ams3 = 0;
        byte ar4 = 31, dr4 = 0, sr4 = 0, rr4 = 15, sl4 = 0, tl4 = 0, ks4 = 0, ml4 = 0, dt1_4 = 0, dt2_4 = 0, ams4 = 0;

        public static PMDVoice VoiceParser(string pmdVoiceText)
        {
            if (string.IsNullOrEmpty(pmdVoiceText))
            {
                throw new ArgumentException($"'{nameof(pmdVoiceText)}' を NULL または空にすることはできません。", nameof(pmdVoiceText));
            }
            //文字列を行毎に分割する（ただし、それぞれの行の末尾には改行文字を追加する）
            string[]? lines = pmdVoiceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select((elem) => elem.Trim() + Environment.NewLine).ToArray();
            if(!lines.Any(s => s.StartsWith('@')))
            {
                throw new ArgumentException($"'{nameof(pmdVoiceText)}' の行の先頭に@が含まれていません。音色データのテキストではない可能性があります。");

            }

            PMDVoice voice = new();

            return voice;
        }
    }

    #region 資料 PMDMML.MANより
    //    §3-1	FM音色定義
    //	@
    //-------------------------------------------------------------------------------
    //[書式1]	@ 音色番号 ＡＬＧ ＦＢ
    //ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＡＭＳ
    //ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＡＭＳ
    //ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＡＭＳ
    //ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＡＭＳ
    //[書式2]	@ 音色番号 ＡＬＧ ＦＢ
    //ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＤＴ２ ＡＭＳ
    //	 ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＤＴ２ ＡＭＳ
    //	 ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＤＴ２ ＡＭＳ
    //	 ＡＲ ＤＲ ＳＲ ＲＲ ＳＬ ＴＬ ＫＳ ＭＬ ＤＴ ＤＴ２ ＡＭＳ
    //[書式3]	@ 音色番号 ＡＬＧ ＦＢ
    //	 ＡＲ ＤＲ ＲＲ ＳＬ ＴＬ ＫＳＬ ＭＬ ＫＳＲ ＥＧＴ ＶＩＢ ＡＭ
    //	 ＡＲ ＤＲ ＲＲ ＳＬ ＴＬ ＫＳＬ ＭＬ ＫＳＲ ＥＧＴ ＶＩＢ ＡＭ
    //-------------------------------------------------------------------------------
    //[備考] 任意の位置に、= 音色名 を表記する事が出来る。
    //-------------------------------------------------------------------------------
    //[範囲] [書式1および2] ＡＬＧ	････	0～7
    //			ＦＢ	････	0～7
    //			ＡＲ	････	0～31
    //			ＤＲ	････	0～31
    //			ＳＲ	････	0～31
    //			ＲＲ	････	0～15
    //			ＳＬ	････	0～15
    //			ＴＬ	････	0～127
    //			ＫＳ	････	0～3
    //			ＭＬ	････	0～15
    //			ＤＴ	････	-3～3 または 0～7
    //			ＡＭＳ	････	0～1
    //	[書式2] ＤＴ２	････	0～3
    //	[書式3] ＡＬＧ	････	0～1
    //			ＦＢ	････	0～7
    //			ＡＲ	････	0～15
    //			ＤＲ	････	0～15
    //			ＲＲ	････	0～15
    //			ＳＬ	････	0～15
    //			ＴＬ	････	0～63
    //			ＫＳＬ	････	0～3
    //			ＭＬ	････	0～15
    //			ＫＳＲ	････	0～1
    //			ＥＧＴ	････	0～1
    //			ＶＩＢ	････	0～1
    //			ＡＭ	････	0～1
    //-------------------------------------------------------------------------------
    //	ＦＭ音源の音色を定義するコマンドです。

    //	@ 記号は必ず行頭に表記し、数値と数値の間には、１つ以上の
    //	SPACE、TAB、カンマ、改行のいずれかが必要です。
    //	ただし、音色名の区切りはTABと改行のみです。

    //	[書式1] は、	MC.EXEに /M オプションを付けていないか、
    //			#DT2Flag off の状態での書式。
    //	[書式2] は、	MC.EXEに /M オプションを付けているか、
    //			#DT2Flag on  の状態での書式。
    //	[書式3] は、	MC.EXEに /L オプションを付けている状態での書式
    //	となっています。

    //	@ から、最後の値まで、; か = を付けずに、数字以外の文字を書くと、
    //	エラーになります。
    //	音色名以外の各数値の省略は出来ません。

    //	各パラメータの意味は、本体マニュアルやFM音源マニュアルを参照して
    //	下さい。

    //[注意]	MC.EXEを使用する際は、音色データを曲データ中に定義するように(->MC.DOC)
    //	しないと、定義されていても無効となります。

    //[例１]
    //@  0  4  5		=falsyn?
    //    31  0  0  0  0  22  0  2  3   0
    //    18 10  0  6  0   0  0  8  3   0
    //    31  0  0  0  0  23  0  4 -3   0
    //    18 10  0  6  0   0  0  4 -3   0
    //[結果]	音色番号 0 に falsyn? を定義する。

    //[例２]	MC.EXE /Mオプション指定時 または #DT2Flag on 指定時
    //; NM AG FB		Falcom Synth(?)
    //@  0  4  5		=falsyn?
    //;   AR DR SR RR SL  TL KS ML DT DT2 AMS
    //    31  0  0  0  0  22  0  2  3   0   0
    //    18 10  0  6  0   0  0  8  3   0   0
    //    31  0  0  0  0  23  0  4 -3   0   0
    //    18 10  0  6  0   0  0  4 -3   0   0
    //[結果]	音色番号 0 に falsyn? を定義する。

    //[例３]	MC.EXE /Lオプション指定時
    //; NM AG FB		E.Bass
    //@  2  0  5		=E.Bass
    //;   AR DR RR SL TL KSL ML KSR EGT VIB AM
    //    11  5  2  2 29   0  0   0   0   1  0
    //    12  8  6  1  0   0  1   1   1   1  0
    //[結果]	音色番号 2 に E.Bass を定義する。

    //[関連]	@ コマンド(MML) (->§6-1)
    //	#DT2Flag コマンド (->§2-14)
    //	MC.EXE /N /M /L オプション (->MC.DOC)
    #endregion

}
