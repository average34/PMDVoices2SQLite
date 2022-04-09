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
    public record PMDVoice : PMDVoiceCore
    {
        #region プロパティ
        /// <summary>
        /// 主キー（プライマリキー）
        /// </summary>
        [Key]
        public int PMDVoiceID { get; set; }
        /// <summary>
        /// MMLファイルの名前です。
        /// </summary>
        public string? MMLFileName { get; set; } = "None";
        /// <summary>
        /// NM ALG FBL の値を入力した右側の位置に存在するコメントです。
        /// = または ; から始まります。
        /// </summary>
        public string? Comment { get; set; } = "";

        #endregion

        #region コンストラクタ
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
        #endregion




        #region メソッド

        #endregion


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
        public static IEnumerable<PMDVoice> VoiceParser(string pmdVoiceText, string fileName = "")
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
                // 空要素を削除
                var nmAlgFblComment = lines[index].Split(' ', StringSplitOptions.None).ToList();
                nmAlgFblComment.RemoveAll(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s));
                if (!nmAlgFblComment.Any() || nmAlgFblComment.Count < 3)
                {
                    throw new ArgumentException("nmAlgFblComment");
                }

                //2行目
                string comment = "";
                _ = byte.TryParse(Regex.Replace(nmAlgFblComment[0], @"[^0-9]", ""), out byte NM);
                _ = byte.TryParse(Regex.Replace(nmAlgFblComment[1], @"[^0-9]", ""), out byte ALG);
                byte FBL;

                //PMDVoice.FBLとCommentの代入
                //4つ目の配列がある場合
                if (nmAlgFblComment.Count >= 4)
                {
                    if (nmAlgFblComment[3].Contains('='))
                    {
                        comment = nmAlgFblComment[3].Substring(nmAlgFblComment[3].IndexOf("="));
                    }
                    else if (nmAlgFblComment[3].Contains(';'))
                    {
                        comment = nmAlgFblComment[3].Substring(nmAlgFblComment[3].IndexOf(";"));
                    }
                    _ = byte.TryParse(Regex.Replace(nmAlgFblComment[2], @"[^0-9]", ""), out FBL);

                }
                //3つ目の配列が長い場合
                else if (nmAlgFblComment[2].Length >= 4)
                {
                    string strFBL;
                    if (nmAlgFblComment[2].Contains('='))
                    {
                        comment = nmAlgFblComment[2].Substring(nmAlgFblComment[2].IndexOf("="));
                        strFBL = nmAlgFblComment[2].Substring(0, nmAlgFblComment[2].IndexOf("="));
                    }
                    else if (nmAlgFblComment[2].Contains(';'))
                    {
                        comment = nmAlgFblComment[2].Substring(nmAlgFblComment[2].IndexOf(";"));
                        strFBL = nmAlgFblComment[2].Substring(0, nmAlgFblComment[2].IndexOf(";"));

                    }
                    else
                        strFBL = nmAlgFblComment[2];

                    _ = byte.TryParse(Regex.Replace(strFBL, @"[^0-9]", ""), out FBL);
                }
                else
                    _ = byte.TryParse(Regex.Replace(nmAlgFblComment[2], @"[^0-9]", ""), out FBL);


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
                        var nmAlgFblCommentNext = lines[index + countLinesPlus].Split(' ', StringSplitOptions.None).ToList();

                        // 空要素を削除
                        nmAlgFblCommentNext.RemoveAll(s => string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s));

                        if (nmAlgFblCommentNext[0].Contains(';')) continue;
                        else if (nmAlgFblCommentNext.Count < 10) continue;
                        else if (nmAlgFblCommentNext.Count > 12) continue;

                        switch (countModule)
                        {
                            case 0:
                                if (nmAlgFblCommentNext.Count == 11)
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
                                if (nmAlgFblCommentNext.Count == 11)
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
                                if (nmAlgFblCommentNext.Count == 11)
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
                                if (nmAlgFblCommentNext.Count == 11)
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
                    fileName, comment);
                voicesList.Add(voice);
            }



            return voicesList;
        }


        /// <summary>
        /// 音色のオブジェクトをMML形式の文字列に変換
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



        /// <summary>
        /// 2つの音色の距離
        /// </summary>
        /// <param name="voice1">音色1</param>
        /// <param name="voice2">音色2</param>
        /// <returns>差(0以上)</returns>
        public static int CoreDistance(this PMDVoice voice1,PMDVoice voice2)
        {
            int ret = 0;
            if (voice2.ALG != voice1.ALG) ret += 10000000;
            ret += Math.Abs(voice2.FBL - voice1.FBL) * 10;
            ret += Math.Abs(voice2.AR1 - voice1.AR1);
            ret += Math.Abs(voice2.AR2 - voice1.AR2);
            ret += Math.Abs(voice2.AR3 - voice1.AR3);
            ret += Math.Abs(voice2.AR4 - voice1.AR4);
            ret += Math.Abs(voice2.DR1 - voice1.DR1);
            ret += Math.Abs(voice2.DR2 - voice1.DR2);
            ret += Math.Abs(voice2.DR3 - voice1.DR3);
            ret += Math.Abs(voice2.DR4 - voice1.DR4);
            ret += Math.Abs(voice2.SR1 - voice1.SR1);
            ret += Math.Abs(voice2.SR2 - voice1.SR2);
            ret += Math.Abs(voice2.SR3 - voice1.SR3);
            ret += Math.Abs(voice2.SR4 - voice1.SR4);
            ret += Math.Abs(voice2.RR1 - voice1.RR1);
            ret += Math.Abs(voice2.RR2 - voice1.RR2);
            ret += Math.Abs(voice2.RR3 - voice1.RR3);
            ret += Math.Abs(voice2.RR4 - voice1.RR4);
            ret += Math.Abs(voice2.SL1 - voice1.SL1);
            ret += Math.Abs(voice2.SL2 - voice1.SL2);
            ret += Math.Abs(voice2.SL3 - voice1.SL3);
            ret += Math.Abs(voice2.SL4 - voice1.SL4);
            ret += Math.Abs(voice2.TL1 - voice1.TL1);
            ret += Math.Abs(voice2.TL2 - voice1.TL2);
            ret += Math.Abs(voice2.TL3 - voice1.TL3);
            ret += Math.Abs(voice2.TL4 - voice1.TL4);
            ret += Math.Abs(voice2.KS1 - voice1.KS1);
            ret += Math.Abs(voice2.KS2 - voice1.KS2);
            ret += Math.Abs(voice2.KS3 - voice1.KS3);
            ret += Math.Abs(voice2.KS4 - voice1.KS4);
            ret += Math.Abs(voice2.ML1 - voice1.ML1) * 10;
            ret += Math.Abs(voice2.ML2 - voice1.ML2) * 10;
            ret += Math.Abs(voice2.ML3 - voice1.ML3) * 10;
            ret += Math.Abs(voice2.ML4 - voice1.ML4) * 10;
            ret += Math.Abs(voice2.DT1 - voice1.DT1);
            ret += Math.Abs(voice2.DT2 - voice1.DT2);
            ret += Math.Abs(voice2.DT3 - voice1.DT3);
            ret += Math.Abs(voice2.DT4 - voice1.DT4);
            ret += Math.Abs(voice2.DT2_1 - voice1.DT2_1);
            ret += Math.Abs(voice2.DT2_2 - voice1.DT2_2);
            ret += Math.Abs(voice2.DT2_3 - voice1.DT2_3);
            ret += Math.Abs(voice2.DT2_4 - voice1.DT2_4);
            ret += Math.Abs(voice2.AMS1 - voice1.AMS1);
            ret += Math.Abs(voice2.AMS2 - voice1.AMS2);
            ret += Math.Abs(voice2.AMS3 - voice1.AMS3);
            ret += Math.Abs(voice2.AMS4 - voice1.AMS4);

            return ret;
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
