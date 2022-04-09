using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PMDVoices2SQLite
{
    /// <summary>
    /// PMDの1つの音色を扱うレコードの基幹部分
    /// </summary>
    [Serializable]
    public record PMDVoiceCore : IPMDVoice
    {
        #region プロパティ
        private byte aLG = 0;
        private byte fBL = 0;
        private byte aMS1 = 0;
        private byte aMS2 = 0;
        private byte aMS3 = 0;
        private byte aMS4 = 0;


        /// <summary>
        /// 音色番号
        /// 0-255
        /// </summary>
        [Required]
        public byte NM { get; set; } = 0;
        /// <summary>
        /// アルゴリズム
        /// 0-7
        /// </summary>
        [Required]
        public byte ALG
        {
            get => aLG; set
            {
                if (value > 7 || value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "アルゴリズムALGの値は0以上7以下までです。");
                aLG = value;
            }
        }
        /// <summary>
        /// フィードバック
        /// 0-7
        /// </summary>
        [Required]
        public byte FBL
        {
            get => fBL; set
            {
                if (value > 7 || value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "フィードバックFBLの値は0以上7以下までです。");

                fBL = value;
            }
        }



        /// <summary>
        /// Attack Rate	0～31
        /// </summary>
        public byte AR1 { get; set; } = 31;
        public byte AR2 { get; set; } = 31;
        public byte AR3 { get; set; } = 31;
        public byte AR4 { get; set; } = 31;
        /// <summary>
        /// Decay Rate	0～31
        /// </summary>
        public byte DR1 { get; set; } = 0;
        public byte DR2 { get; set; } = 0;
        public byte DR3 { get; set; } = 0;
        public byte DR4 { get; set; } = 0;
        /// <summary>
        /// Sustain Rate	0～31
        /// </summary>
        public byte SR1 { get; set; } = 0;
        public byte SR2 { get; set; } = 0;
        public byte SR3 { get; set; } = 0;
        public byte SR4 { get; set; } = 0;
        /// <summary>
        /// Release Rate	0～15
        /// </summary>
        public byte RR1 { get; set; } = 15;
        public byte RR2 { get; set; } = 15;
        public byte RR3 { get; set; } = 15;
        public byte RR4 { get; set; } = 15;
        /// <summary>
        /// Sustain Level	0～15
        /// </summary>
        public byte SL1 { get; set; } = 0;
        public byte SL2 { get; set; } = 0;
        public byte SL3 { get; set; } = 0;
        public byte SL4 { get; set; } = 0;

        /// <summary>
        /// Total Level	0～127
        /// </summary>
        public byte TL1 { get; set; } = 0;
        public byte TL2 { get; set; } = 0;
        public byte TL3 { get; set; } = 0;
        public byte TL4 { get; set; } = 0;

        /// <summary>
        /// Key Scale	0～3
        /// </summary>
        public byte KS1 { get; set; } = 0;
        public byte KS2 { get; set; } = 0;
        public byte KS3 { get; set; } = 0;
        public byte KS4 { get; set; } = 0;

        /// <summary>
        /// Multiple	0～15
        /// </summary>
        public byte ML1 { get; set; } = 0;
        public byte ML2 { get; set; } = 0;
        public byte ML3 { get; set; } = 0;
        public byte ML4 { get; set; } = 0;

        /// <summary>
        /// Detune	0～7 (または -3～3)
        /// </summary>
        public byte DT1 { get; set; } = 0;
        public byte DT2 { get; set; } = 0;
        public byte DT3 { get; set; } = 0;
        public byte DT4 { get; set; } = 0;

        /// <summary>
        /// Detune2	0～3
        /// </summary>
        public byte DT2_1 { get; set; } = 0;
        public byte DT2_2 { get; set; } = 0;
        public byte DT2_3 { get; set; } = 0;
        public byte DT2_4 { get; set; } = 0;

        /// <summary>
        /// AMS Enable	0～1
        /// </summary>
        public byte AMS1 { get => aMS1; 
            set
            {
                if (value > 1) fBL = 1;
                else if (value < 0) fBL = 0;
                else fBL = value;
            }
        }
        public byte AMS2 { get => aMS2;
            set
            {
                if (value > 1) fBL = 1;
                else if (value < 0) fBL = 0;
                else fBL = value;
            }
        }
        public byte AMS3 { get => aMS3;
            set
            {
                if (value > 1) fBL = 1;
                else if (value < 0) fBL = 0;
                else fBL = value;
            }
        }
        public byte AMS4 { get => aMS4;
            set
            {
                if (value > 1) fBL = 1;
                else if (value < 0) fBL = 0;
                else fBL = value;
            }
        }
        #endregion

        #region コンストラクタ
        public PMDVoiceCore()
        {
        }


        public PMDVoiceCore(byte nM, byte aLG, byte fBL, byte aR1, byte aR2, byte aR3, byte aR4, byte dR1, byte dR2, byte dR3, byte dR4, byte sR1, byte sR2, byte sR3, byte sR4, byte rR1, byte rR2, byte rR3, byte rR4, byte sL1, byte sL2, byte sL3, byte sL4, byte tL1, byte tL2, byte tL3, byte tL4, byte kS1, byte kS2, byte kS3, byte kS4, byte mL1, byte mL2, byte mL3, byte mL4, byte dT1, byte dT2, byte dT3, byte dT4, byte aMS1, byte aMS2, byte aMS3, byte aMS4)
        {
            NM = nM;
            ALG = aLG;
            FBL = fBL;
            AR1 = aR1;
            AR2 = aR2;
            AR3 = aR3;
            AR4 = aR4;
            DR1 = dR1;
            DR2 = dR2;
            DR3 = dR3;
            DR4 = dR4;
            SR1 = sR1;
            SR2 = sR2;
            SR3 = sR3;
            SR4 = sR4;
            RR1 = rR1;
            RR2 = rR2;
            RR3 = rR3;
            RR4 = rR4;
            SL1 = sL1;
            SL2 = sL2;
            SL3 = sL3;
            SL4 = sL4;
            TL1 = tL1;
            TL2 = tL2;
            TL3 = tL3;
            TL4 = tL4;
            KS1 = kS1;
            KS2 = kS2;
            KS3 = kS3;
            KS4 = kS4;
            ML1 = mL1;
            ML2 = mL2;
            ML3 = mL3;
            ML4 = mL4;
            DT1 = dT1;
            DT2 = dT2;
            DT3 = dT3;
            DT4 = dT4;
            AMS1 = aMS1;
            AMS2 = aMS2;
            AMS3 = aMS3;
            AMS4 = aMS4;
        }

        public PMDVoiceCore(byte nM, byte aLG, byte fBL, byte aR1, byte aR2, byte aR3, byte aR4, byte dR1, byte dR2, byte dR3, byte dR4, byte sR1, byte sR2, byte sR3, byte sR4, byte rR1, byte rR2, byte rR3, byte rR4, byte sL1, byte sL2, byte sL3, byte sL4, byte tL1, byte tL2, byte tL3, byte tL4, byte kS1, byte kS2, byte kS3, byte kS4, byte mL1, byte mL2, byte mL3, byte mL4, byte dT1, byte dT2, byte dT3, byte dT4, byte dT2_1, byte dT2_2, byte dT2_3, byte dT2_4, byte aMS1, byte aMS2, byte aMS3, byte aMS4)
        {
            NM = nM;
            ALG = aLG;
            FBL = fBL;
            AR1 = aR1;
            AR2 = aR2;
            AR3 = aR3;
            AR4 = aR4;
            DR1 = dR1;
            DR2 = dR2;
            DR3 = dR3;
            DR4 = dR4;
            SR1 = sR1;
            SR2 = sR2;
            SR3 = sR3;
            SR4 = sR4;
            RR1 = rR1;
            RR2 = rR2;
            RR3 = rR3;
            RR4 = rR4;
            SL1 = sL1;
            SL2 = sL2;
            SL3 = sL3;
            SL4 = sL4;
            TL1 = tL1;
            TL2 = tL2;
            TL3 = tL3;
            TL4 = tL4;
            KS1 = kS1;
            KS2 = kS2;
            KS3 = kS3;
            KS4 = kS4;
            ML1 = mL1;
            ML2 = mL2;
            ML3 = mL3;
            ML4 = mL4;
            DT1 = dT1;
            DT2 = dT2;
            DT3 = dT3;
            DT4 = dT4;
            DT2_1 = dT2_1;
            DT2_2 = dT2_2;
            DT2_3 = dT2_3;
            DT2_4 = dT2_4;
            AMS1 = aMS1;
            AMS2 = aMS2;
            AMS3 = aMS3;
            AMS4 = aMS4;
        }
        #endregion


        public static bool operator -(PMDVoiceCore voice1, PMDVoiceCore voice2)
        {
            return voice1.CoreEquals(voice2);
        }


        #region メソッド
        public bool CoreEquals(IPMDVoice obj)
        {
            return obj is IPMDVoice voice &&
                   ALG == voice.ALG &&
                   FBL == voice.FBL &&
                   AR1 == voice.AR1 &&
                   AR2 == voice.AR2 &&
                   AR3 == voice.AR3 &&
                   AR4 == voice.AR4 &&
                   DR1 == voice.DR1 &&
                   DR2 == voice.DR2 &&
                   DR3 == voice.DR3 &&
                   DR4 == voice.DR4 &&
                   SR1 == voice.SR1 &&
                   SR2 == voice.SR2 &&
                   SR3 == voice.SR3 &&
                   SR4 == voice.SR4 &&
                   RR1 == voice.RR1 &&
                   RR2 == voice.RR2 &&
                   RR3 == voice.RR3 &&
                   RR4 == voice.RR4 &&
                   SL1 == voice.SL1 &&
                   SL2 == voice.SL2 &&
                   SL3 == voice.SL3 &&
                   SL4 == voice.SL4 &&
                   TL1 == voice.TL1 &&
                   TL2 == voice.TL2 &&
                   TL3 == voice.TL3 &&
                   TL4 == voice.TL4 &&
                   KS1 == voice.KS1 &&
                   KS2 == voice.KS2 &&
                   KS3 == voice.KS3 &&
                   KS4 == voice.KS4 &&
                   ML1 == voice.ML1 &&
                   ML2 == voice.ML2 &&
                   ML3 == voice.ML3 &&
                   ML4 == voice.ML4 &&
                   DT1 == voice.DT1 &&
                   DT2 == voice.DT2 &&
                   DT3 == voice.DT3 &&
                   DT4 == voice.DT4 &&
                   DT2_1 == voice.DT2_1 &&
                   DT2_2 == voice.DT2_2 &&
                   DT2_3 == voice.DT2_3 &&
                   DT2_4 == voice.DT2_4 &&
                   AMS1 == voice.AMS1 &&
                   AMS2 == voice.AMS2 &&
                   AMS3 == voice.AMS3 &&
                   AMS4 == voice.AMS4;
        }


        #endregion
    }



    #region 資料 PMDMML.MANより 引用
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
