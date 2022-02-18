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
    /// PMDの1つの音色を扱うレコード（エンティティ）
    /// </summary>
    [Serializable]
    public record PMDVoice
    {
        /// <summary>
        /// 主キー（プライマリキー）
        /// </summary>
        [Key]
        public int PMDVoiceID { get; set; }
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
        public byte ALG { get; set; } = 0;
        /// <summary>
        /// フィードバック
        /// 0-7
        /// </summary>
        [Required]
        public byte FBL { get; set; } = 0;

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
        public byte AMS1 { get; set; } = 0;
        public byte AMS2 { get; set; } = 0;
        public byte AMS3 { get; set; } = 0;
        public byte AMS4 { get; set; } = 0;

        /// <summary>
        /// MMLファイルの名前です。
        /// </summary>
        public string? MMLFileName { get; set; } = "None";
        /// <summary>
        /// nm alg fbl の値を入力した右側の位置に存在するコメントです。
        /// = または ; から始まります。
        /// </summary>
        public string? Comment { get; set; } = "";


        public PMDVoice()
        {
        }


        public PMDVoice(byte nM, byte aLG, byte fBL, byte aR1, byte aR2, byte aR3, byte aR4, byte dR1, byte dR2, byte dR3, byte dR4, byte sR1, byte sR2, byte sR3, byte sR4, byte rR1, byte rR2, byte rR3, byte rR4, byte sL1, byte sL2, byte sL3, byte sL4, byte tL1, byte tL2, byte tL3, byte tL4, byte kS1, byte kS2, byte kS3, byte kS4, byte mL1, byte mL2, byte mL3, byte mL4, byte dT1, byte dT2, byte dT3, byte dT4, byte aMS1, byte aMS2, byte aMS3, byte aMS4, string? mMLFileName = "None", string? comment = "")
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
            MMLFileName = mMLFileName;
            Comment = comment;
        }

        public PMDVoice(byte nM, byte aLG, byte fBL, byte aR1, byte aR2, byte aR3, byte aR4, byte dR1, byte dR2, byte dR3, byte dR4, byte sR1, byte sR2, byte sR3, byte sR4, byte rR1, byte rR2, byte rR3, byte rR4, byte sL1, byte sL2, byte sL3, byte sL4, byte tL1, byte tL2, byte tL3, byte tL4, byte kS1, byte kS2, byte kS3, byte kS4, byte mL1, byte mL2, byte mL3, byte mL4, byte dT1, byte dT2, byte dT3, byte dT4, byte dT2_1, byte dT2_2, byte dT2_3, byte dT2_4, byte aMS1, byte aMS2, byte aMS3, byte aMS4, string? mMLFileName = "None", string? comment = "")
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
            MMLFileName = mMLFileName;
            Comment = comment;
        }
    }

    /// <summary>
    /// PMDVoiceを対象としたメソッドのクラス
    /// </summary>
    public static class PMDVoiceMethod
    {


        /// <summary>
        /// MMLの音色定義からデータを抽出する
        /// </summary>
        /// <param name="pmdVoiceText">MMLの音色定義のテキストデータ</param>
        /// <returns>抽出したデータ</returns>
        /// <exception cref="ArgumentException"></exception>
        public static IEnumerable<PMDVoice> VoiceParser(string pmdVoiceText)
        {

            if (string.IsNullOrEmpty(pmdVoiceText))
            {
                throw new ArgumentException($"'{nameof(pmdVoiceText)}' を NULL または空にすることはできません。", nameof(pmdVoiceText));
            }
            //文字列を行毎に分割する（ただし、各行の両端の空白は削除する）
            string[]? lines = pmdVoiceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None)
                .Select((elem) => elem.Trim()).ToArray();
            if (!lines.Any(s => s.StartsWith('@')))
            {
                throw new ArgumentException($"'{nameof(pmdVoiceText)}' の行の先頭に@が含まれていません。音色データのテキストではない可能性があります。");

            }

            List<PMDVoice> voicesList = new();

            //要素とそのインデックスを匿名クラスのリストに射影
            IEnumerable<int>? atmarkIndex = lines
                .Select((s, i) => new { Content = s, Index = i })
                //上記リストをフィルタリング
                .Where(ano => ano.Content.StartsWith('@') && ano.Index >= 1)
                //インデックスだけのリストを取得
                .Select(ano => ano.Index);

            foreach (var index in atmarkIndex)
            {
                if (!lines[index].StartsWith('@')) throw new ArgumentException();
                string[]? nmAlgFblComment = lines[index].Split(' ', StringSplitOptions.None);

                if (!nmAlgFblComment.Any() || nmAlgFblComment.Length < 3) throw new ArgumentException();

                //2行目
                string comment = "";
                _ = byte.TryParse(Regex.Replace(nmAlgFblComment[0], @"[^0-9]", ""), out byte NM);
                _ = byte.TryParse(Regex.Replace(nmAlgFblComment[1], @"[^0-9]", ""), out byte ALG);
                _ = byte.TryParse(Regex.Replace(nmAlgFblComment[2], @"[^0-9]", ""), out byte FBL);

                //PMDVoice.Commentの代入
                if (Array.IndexOf(nmAlgFblComment, 3) > -1)
                {
                    if (nmAlgFblComment[3].Contains('='))
                    {
                        comment = nmAlgFblComment[3].Substring(nmAlgFblComment[3].IndexOf("="));
                    }
                    else if (nmAlgFblComment[3].Contains(';'))
                    {
                        comment = nmAlgFblComment[3].Substring(nmAlgFblComment[3].IndexOf(";"));
                    }
                }
                else if (nmAlgFblComment[2].Length >= 4)
                {
                    if (nmAlgFblComment[2].Contains('='))
                    {
                        comment = nmAlgFblComment[2].Substring(nmAlgFblComment[2].IndexOf("="));
                    }
                    else if (nmAlgFblComment[2].Contains(';'))
                    {
                        comment = nmAlgFblComment[2].Substring(nmAlgFblComment[2].IndexOf(";"));
                    }
                }

                //AR1以降


                byte AR1 = 31, AR2 = 31, AR3 = 31, AR4 = 31;
                byte DR1 = 0, DR2 = 0, DR3 = 0, DR4 = 0;
                byte SR1 = 0, SR2 = 0, SR3 = 0, SR4 = 0;
                byte RR1 = 15, RR2 = 15, RR3 = 15, RR4 = 15;
                byte SL1 = 0, SL2 = 0, SL3 = 0, SL4 = 0;
                byte TL1 = 0, TL2 = 0, TL3 = 0, TL4 = 0;
                byte KS1 = 0, KS2 = 0, KS3 = 0, KS4 = 0;
                byte ML1 = 0, ML2 = 0, ML3 = 0, ML4 = 0;
                byte DT1 = 0, DT2 = 0, DT3 = 0, DT4 = 0;
                byte DT2_1 = 0, DT2_2 = 0, DT2_3 = 0, DT2_4 = 0;
                byte AMS1 = 0, AMS2 = 0, AMS3 = 0, AMS4 = 0;


                byte countModule = 0;
                byte countLinesPlus = 0;
                while (countModule < 4)
                {
                    countLinesPlus++;
                    if (lines.Length > index + countLinesPlus + 1)
                    {
                        string[]? nmAlgFblCommentNext = lines[index + countLinesPlus].Split(' ', StringSplitOptions.None);
                        if (nmAlgFblCommentNext[0].Contains(';')) continue;
                        else if (nmAlgFblCommentNext.Length < 10) continue;
                        else if (nmAlgFblCommentNext.Length > 12) continue;

                        switch (countModule)
                        {
                            case 0:
                                if (nmAlgFblCommentNext.Length == 11)
                                {
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out DT2_1);
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[10], @"[^0-9]", ""), out AMS1);
                                }
                                else
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out AMS1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[0], @"[^0-9]", ""), out AR1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[1], @"[^0-9]", ""), out DR1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[2], @"[^0-9]", ""), out SR1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[3], @"[^0-9]", ""), out RR1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[4], @"[^0-9]", ""), out SL1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[5], @"[^0-9]", ""), out TL1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[6], @"[^0-9]", ""), out KS1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[7], @"[^0-9]", ""), out ML1);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[8], @"[^0-9]", ""), out DT1);
                                break;
                            case 1:
                                if (nmAlgFblCommentNext.Length == 11)
                                {
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out DT2_2);
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[10], @"[^0-9]", ""), out AMS2);
                                }
                                else
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out AMS2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[0], @"[^0-9]", ""), out AR2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[1], @"[^0-9]", ""), out DR2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[2], @"[^0-9]", ""), out SR2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[3], @"[^0-9]", ""), out RR2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[4], @"[^0-9]", ""), out SL2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[5], @"[^0-9]", ""), out TL2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[6], @"[^0-9]", ""), out KS2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[7], @"[^0-9]", ""), out ML2);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[8], @"[^0-9]", ""), out DT2);
                                break;
                            case 2:
                                if (nmAlgFblCommentNext.Length == 11)
                                {
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out DT2_3);
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[10], @"[^0-9]", ""), out AMS3);
                                }
                                else
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out AMS3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[0], @"[^0-9]", ""), out AR3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[1], @"[^0-9]", ""), out DR3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[2], @"[^0-9]", ""), out SR3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[3], @"[^0-9]", ""), out RR3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[4], @"[^0-9]", ""), out SL3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[5], @"[^0-9]", ""), out TL3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[6], @"[^0-9]", ""), out KS3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[7], @"[^0-9]", ""), out ML3);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[8], @"[^0-9]", ""), out DT3);
                                break;
                            case 3:
                                if (nmAlgFblCommentNext.Length == 11)
                                {
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out DT2_4);
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[10], @"[^0-9]", ""), out AMS4);
                                }
                                else
                                    _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[9], @"[^0-9]", ""), out AMS4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[0], @"[^0-9]", ""), out AR4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[1], @"[^0-9]", ""), out DR4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[2], @"[^0-9]", ""), out SR4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[3], @"[^0-9]", ""), out RR4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[4], @"[^0-9]", ""), out SL4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[5], @"[^0-9]", ""), out TL4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[6], @"[^0-9]", ""), out KS4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[7], @"[^0-9]", ""), out ML4);
                                _ = byte.TryParse(Regex.Replace(nmAlgFblCommentNext[8], @"[^0-9]", ""), out DT4);
                                break;
                            default:
                                break;
                        }


                        countModule++;
                        //成功したので次の行へ
                        continue;
                    }
                }

                PMDVoice voice = new(NM, ALG, FBL,
                    AR1, AR2, AR3, AR4,
                    DR1, DR2, DR3, DR4,
                    SR1, SR2, SR3, SR4,
                    RR1, RR2, RR3, RR4,
                    SL1, SL2, SL3, SL4,
                    TL1, TL2, TL3, TL4,
                    KS1, KS2, KS3, KS4,
                    ML1, ML2, ML3, ML4,
                    DT1, DT2, DT3, DT4,
                    DT2_1, DT2_2, DT2_3, DT2_4,
                    AMS1, AMS2, AMS3, AMS4,
                    "None", comment);
                voicesList.Add(voice);
            }



            return voicesList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="voice"></param>
        /// <param name="is3digits"></param>
        /// <param name="isExistDT2"></param>
        /// <returns></returns>
        public static string ToMML(this PMDVoice voice, bool is3digits = false, bool isExistDT2 = false)
        {
            string format;
            string returnMML = $"; NM ALG FBL{Environment.NewLine}@";

            if (is3digits) format = "D3";
            else format = "D";

            //2行目
            returnMML += $"{voice.NM.ToString(format)} {voice.ALG.ToString(format)} {voice.FBL.ToString(format)} ";
            if (string.IsNullOrEmpty(voice.Comment)) { }
            else if (voice.Comment.StartsWith('=') || voice.Comment.StartsWith(';'))
                returnMML += voice.Comment;
            else
                returnMML += "= " + voice.Comment;
            returnMML += Environment.NewLine;

            //3行目
            if (isExistDT2)
                returnMML += $"; AR  DR  SR  RR  SL  TL  KS  ML  DT DT2 AMS{Environment.NewLine}";
            else
                returnMML += $"; AR  DR  SR  RR  SL  TL  KS  ML  DT AMS{Environment.NewLine}";

            //4-7行目
            if (isExistDT2)
            {
                returnMML += $" {voice.AR1.ToString(format)} {voice.DR1.ToString(format)} {voice.SR1.ToString(format)} {voice.RR1.ToString(format)} {voice.SL1.ToString(format)} {voice.TL1.ToString(format)} {voice.KS1.ToString(format)} {voice.ML1.ToString(format)} {voice.DT1.ToString(format)} {voice.DT2_1.ToString(format)} {voice.AMS1.ToString(format)} {Environment.NewLine}";
                returnMML += $" {voice.AR2.ToString(format)} {voice.DR2.ToString(format)} {voice.SR2.ToString(format)} {voice.RR2.ToString(format)} {voice.SL2.ToString(format)} {voice.TL2.ToString(format)} {voice.KS2.ToString(format)} {voice.ML2.ToString(format)} {voice.DT2.ToString(format)} {voice.DT2_2.ToString(format)}  {voice.AMS2.ToString(format)} {Environment.NewLine}";
                returnMML += $" {voice.AR3.ToString(format)} {voice.DR3.ToString(format)} {voice.SR3.ToString(format)} {voice.RR3.ToString(format)} {voice.SL3.ToString(format)} {voice.TL3.ToString(format)} {voice.KS3.ToString(format)} {voice.ML3.ToString(format)} {voice.DT3.ToString(format)} {voice.DT2_3.ToString(format)}  {voice.AMS3.ToString(format)} {Environment.NewLine}";
                returnMML += $" {voice.AR4.ToString(format)} {voice.DR4.ToString(format)} {voice.SR4.ToString(format)} {voice.RR4.ToString(format)} {voice.SL4.ToString(format)} {voice.TL4.ToString(format)} {voice.KS4.ToString(format)} {voice.ML4.ToString(format)} {voice.DT4.ToString(format)} {voice.DT2_4.ToString(format)}  {voice.AMS4.ToString(format)} {Environment.NewLine}";
            }
            else
            {
                returnMML += $" {voice.AR1.ToString(format)} {voice.DR1.ToString(format)} {voice.SR1.ToString(format)} {voice.RR1.ToString(format)} {voice.SL1.ToString(format)} {voice.TL1.ToString(format)} {voice.KS1.ToString(format)} {voice.ML1.ToString(format)} {voice.DT1.ToString(format)} {voice.AMS1.ToString(format)} {Environment.NewLine}";
                returnMML += $" {voice.AR2.ToString(format)} {voice.DR2.ToString(format)} {voice.SR2.ToString(format)} {voice.RR2.ToString(format)} {voice.SL2.ToString(format)} {voice.TL2.ToString(format)} {voice.KS2.ToString(format)} {voice.ML2.ToString(format)} {voice.DT2.ToString(format)} {voice.AMS2.ToString(format)} {Environment.NewLine}";
                returnMML += $" {voice.AR3.ToString(format)} {voice.DR3.ToString(format)} {voice.SR3.ToString(format)} {voice.RR3.ToString(format)} {voice.SL3.ToString(format)} {voice.TL3.ToString(format)} {voice.KS3.ToString(format)} {voice.ML3.ToString(format)} {voice.DT3.ToString(format)} {voice.AMS3.ToString(format)} {Environment.NewLine}";
                returnMML += $" {voice.AR4.ToString(format)} {voice.DR4.ToString(format)} {voice.SR4.ToString(format)} {voice.RR4.ToString(format)} {voice.SL4.ToString(format)} {voice.TL4.ToString(format)} {voice.KS4.ToString(format)} {voice.ML4.ToString(format)} {voice.DT4.ToString(format)} {voice.AMS4.ToString(format)} {Environment.NewLine}";
            }

            return returnMML;

        }

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
