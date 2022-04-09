using System.Reflection;
using System.Text;

namespace PMDVoices2SQLite
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mML�t�@�C�����J��OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonMMLPath_Click(sender, e);
        }

        private void �I��XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogForm logForm = new LogForm();
            logForm.Show();
            DateTime buildDateTime = File.GetLastWriteTimeUtc(Assembly.GetExecutingAssembly().Location);
            buildDateTime += new TimeSpan(9, 0, 0);

            TextBoxLogger.Log($"�o�[�W���� {buildDateTime}");
            TextBoxLogger.Log($"�N�� {DateTime.Now}");
#if DEBUG
            this.comboBoxMMLPath.Text = @"E:\Google �h���C�u\��������p�c�[��\��������X�^�[�^�[�p�b�P�[�W\��������MML�f�[�^\zun_AMS4To1.mml";
            this.comboBoxDBPath.Text = @"C:\Users\R K\Desktop\PMD\PMDVoices.sqlite3";
            this.comboBoxMMLPath.Items.Add(@"E:\R K in E\Dropbox\DTM\pmd48s\PMD98_PresetVoices\EFFEC.MML");
            this.comboBoxMMLPath.Items.Add(@"E:\R K in E\Dropbox\DTM\pmd48s\PMD98_PresetVoices\PC88.MML");
            this.comboBoxMMLPath.Items.Add(@"E:\R K in E\Dropbox\DTM\pmd48s\PMD98_PresetVoices\X68ED.MML");
            this.comboBoxMMLPath.Items.Add(@"E:\Google �h���C�u\��������p�c�[��\��������X�^�[�^�[�p�b�P�[�W\��������MML�f�[�^\zun.mml");
            this.comboBoxMMLPath.Items.Add(@"E:\Google �h���C�u\��������p�c�[��\��������X�^�[�^�[�p�b�P�[�W\��������MML�f�[�^\zun_AMS4To1.mml");
            this.comboBoxMMLPath.Items.Add(@"E:\Google �h���C�u\��������p�c�[��\��������X�^�[�^�[�p�b�P�[�W\��������MML�f�[�^\th02_PMD\02_10.txt");
            this.comboBoxDBPath.Items.Add(@"C:\Users\R K\Desktop\PMD\PMDVoices.sqlite3");
#endif
        }

        private void buttonMMLPath_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog dlg = new())
            {
                dlg.FileName = "PMDVoices.mml";
                dlg.Filter = "MML�t�@�C��(*.mml)|*.mml|�e�L�X�g�t�@�C��(*.txt)|*.txt|���ׂẴt�@�C��(*.*)|*.*";
                //�_�C�A���O���J��
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBoxMMLPath.Text = dlg.FileName;
                }
            }
        }

        private void buttonDBPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new())
            {
                dlg.FileName = "PMDVoices.sqlite3";

                dlg.Filter = "SQLite �f�[�^�x�[�X�t�@�C��(*.db *.sqlite *.sqlite3 *.db3)|*.db;*.sqlite;*.sqlite3;*.db3|���ׂẴt�@�C��(*.*)|*.*";

                //�_�C�A���O���J��
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.comboBoxDBPath.Text = dlg.FileName;
                }
            }

        }

        private void buttonMML2SQLite_Click(object sender, EventArgs e)
        {
            MML2SQLite();
        }

        /// <summary>
        /// MML�t�@�C����DB���ɕۑ�
        /// </summary>
        /// <returns></returns>
        public void MML2SQLite()
        {

            string mmlText = ReadMML();
            string fileName = Path.GetFileName(this.comboBoxMMLPath.Text);


            IEnumerable<PMDVoice>? voices = PMDVoiceMethod.VoiceParser(mmlText, fileName);
            if (voices is not null)
            {
#pragma warning disable CS8604 // Null �Q�ƈ����̉\��������܂��B
                TextBoxLogger.Log($"���F�ϊ�����");
                foreach(var voice in voices)TextBoxLogger.Log(voice.ToMML());
                _ = Voices2SQLite(voices, this.comboBoxDBPath.Text);
#pragma warning restore CS8604 // Null �Q�ƈ����̉\��������܂��B
            }
        }

        /// <summary>
        /// MML��ǂݍ���
        /// </summary>
        /// <returns></returns>
        public string ReadMML()
        {
            string mmlText;
            //�V�t�gJIS��Encoding�I�u�W�F�N�g���쐬����
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding enc = Encoding.GetEncoding("shift_jis");

            using (StreamReader sr = new(this.comboBoxMMLPath.Text, enc))
            {
                mmlText = sr.ReadToEnd();
            }

            TextBoxLogger.Log($"MML�ǂݍ��݊��� Path:{this.comboBoxMMLPath.Text}");
            TextBoxLogger.Log($"MML�̓��e:{Environment.NewLine}{mmlText}");

            return mmlText;
        }


        public static async Task<IEnumerable<PMDVoice>?> Voices2SQLite(IEnumerable<PMDVoice> voices, string dbPath)
        {
            if (dbPath is null)
            {
                throw new ArgumentNullException(nameof(dbPath));
            }

            using var dbContext = new PMDVoicesContext(dbPath);
            await dbContext.Database.EnsureCreatedAsync();

            // �V�K�o�^
            dbContext.AddRange(voices);
            dbContext.SaveChanges();
            TextBoxLogger.Log("DB��������");
            return dbContext.Voices;
        }

        private void buttonSQLite2MML_Click(object sender, EventArgs e)
        {

        }

        private async void buttonSearchDB_Click(object sender, EventArgs e)
        {

            string mmlText = ReadMML();
            string fileName = Path.GetFileName(this.comboBoxMMLPath.Text);
            IEnumerable<PMDVoice>? voices = PMDVoiceMethod.VoiceParser(mmlText, fileName);
            var resultVoices = await SearchFromSQLite(voices, this.comboBoxDBPath.Text);
            if (resultVoices is not null)
            {
                await Voices2SQLite(resultVoices, @"C:\Users\R K\Desktop\PMD\SearchResult.sqlite3");
            }

        }


        /// <summary>
        /// DB�����v���鉹�F������
        /// </summary>
        /// <param name="voices"></param>
        /// <param name="dbPath"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<IEnumerable<PMDVoice>?> SearchFromSQLite(IEnumerable<PMDVoice> voices, string dbPath, bool optionNearVoice = true)
        {
            if (dbPath is null)
            {
                throw new ArgumentNullException(nameof(dbPath));
            }
            List<PMDVoice> returnVoices = new List<PMDVoice>();
            using var dbContext = new PMDVoicesContext(dbPath);
            await dbContext.Database.EnsureCreatedAsync();

            // ����
            if (dbContext.Voices is null) return null; 
            IEnumerable<PMDVoice> dbVoices = dbContext.Voices;
            foreach (PMDVoice voice in voices)
            {
                List<PMDVoice>? resultSearch = dbVoices.Where(v => v.CoreEquals(voice)).ToList();

                TextBoxLogger.Log($"-----------------------------------------");
                TextBoxLogger.Log($"�������ʁ@{resultSearch.Count} ��");
                var first = resultSearch.FirstOrDefault();
                if (first is not null)
                {
                    TextBoxLogger.Log($"���v���F�F {Environment.NewLine}" +
                        $"{first.ToMML(is3digits: true)} {Environment.NewLine}" +
                    $"MML�t�@�C�����F {first.MMLFileName} ");
                    returnVoices.AddRange(resultSearch);
                }
                //�������ʂ������Ȃ�΋߂����F��T��
                else if (optionNearVoice)
                {
                    PMDVoice? minDistance =
                        dbVoices.OrderBy(v => v.CoreDistance(voice)).FirstOrDefault();
                    if (minDistance is not null)
                    {

                        TextBoxLogger.Log($"�����F {minDistance.CoreDistance(voice)}");
                        TextBoxLogger.Log($"�ł��߂����F�F {Environment.NewLine}{minDistance.ToMML(is3digits: true)}");
                        TextBoxLogger.Log($"MML�t�@�C�����F {minDistance.MMLFileName} ");
                    }
                }
                TextBoxLogger.Log($"�������F�@{Environment.NewLine}{voice.ToMML(is3digits: true)} ");
            }
            TextBoxLogger.Log("�����I��");
            return returnVoices;
        }


        /// <summary>
        /// �����R�[�h�𔻕ʂ���
        /// </summary>
        /// <remarks>
        /// Jcode.pm��getcode���\�b�h���ڐA�������̂ł��B
        /// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
        /// </remarks>
        /// <param name="bytes">�����R�[�h�𒲂ׂ�f�[�^</param>
        /// <returns>�K���Ǝv����Encoding�I�u�W�F�N�g�B
        /// ���f�ł��Ȃ���������null�B</returns>
        public static System.Text.Encoding? GetCode(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 �͖���

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8));
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }

        private void comboBoxMMLPath_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}