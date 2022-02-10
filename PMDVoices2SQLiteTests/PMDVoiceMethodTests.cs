using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMDVoices2SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMDVoices2SQLite.Tests
{
    [TestClass()]
    public class PMDVoiceMethodTests
    {

        [TestMethod()]
        public void VoiceParserTest()
        {
            string? pmdVoiceText;
            pmdVoiceText = ";NM ALG FBL" + Environment.NewLine +
                "@000 002 007				=	APiano" + Environment.NewLine +
                "; ar  dr  sr  rr  sl  tl  ks  ml  dt ams" + Environment.NewLine +
                " 031 005 000 006 001 037 000 001 007 000" + Environment.NewLine +
                " 031 005 003 006 001 047 002 012 000 000" + Environment.NewLine +
                " 031 005 000 006 001 035 000 003 003 000" + Environment.NewLine +
                " 015 004 000 007 015 000 003 001 000 000" + Environment.NewLine;

            PMDVoice voice = new PMDVoice(0, 2, 7,
                31, 31, 31, 31, 5, 5, 5, 4,
                0, 3, 0, 0, 6, 6, 6, 7,
                1, 1, 1, 15, 37, 47, 35, 0,
                0, 2, 0, 3, 1, 12, 3, 1,
                0, 0, 0, 0, 0, 0, 0, 0,
                  0, 0, 0, 0, 
                 "None", "=	APiano");
            PMDVoice[]? expected = new PMDVoice[] { voice };

            List<PMDVoice>? actual = (List<PMDVoice>)PMDVoiceMethod.VoiceParser(pmdVoiceText);
            Assert.AreEqual(expected[0], actual[0]);

        }
    }
}