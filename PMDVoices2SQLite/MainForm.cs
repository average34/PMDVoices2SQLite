namespace PMDVoices2SQLite
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mMLファイルを開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _ = SeedingAsync();
        }

        public static async Task SeedingAsync()
        {

            using (var dbContext = new PMDVoicesContext())
            {
                await dbContext.Database.EnsureCreatedAsync();
                // 新規登録
                dbContext.Add(new PMDVoice(0, 2, 7,
                31, 31, 31, 15, 5, 5, 5, 4,
                0, 3, 0, 0, 6, 6, 6, 7,
                1, 1, 1, 15, 37, 47, 35, 0,
                0, 2, 0, 3, 1, 12, 3, 1,
                7, 0, 3, 0, 0, 0, 0, 0,
                  0, 0, 0, 0,
                 "None", "= Test1"));
                dbContext.SaveChanges();

                // 読み込み
                PMDVoice? voice = dbContext.Voices.First();
                Console.WriteLine($"読み込み 番号:{voice.NM}");

                // 更新
                dbContext.Voices.Add(new PMDVoice(0, 2, 7,
                 31, 31, 15, 15, 5, 5, 5, 4,
                 0, 3, 0, 0, 6, 6, 6, 7,
                 1, 1, 1, 15, 37, 47, 35, 0,
                 0, 2, 0, 3, 1, 12, 3, 1,
                 7, 0, 3, 0, 0, 0, 0, 0,
                   0, 0, 0, 0,
                  "None", "= Test2"));
                dbContext.SaveChanges();
                Console.WriteLine("更新");

            }
        }

    }
}