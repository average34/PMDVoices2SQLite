using System.Text;

namespace PMDVoices2SQLite
{
    public class TextBoxLogger
    {
        private static TextBox? myConsole;
        const string logFileName = "logfile.txt";

        public TextBoxLogger(TextBox textBox)
        {
            myConsole = textBox;
        }

        public static void Log(string line)
        {
            if (line != string.Empty)
            {
                if (myConsole != null)
                {
                    myConsole.AppendText(line + "\r\n");
                }
                LogToFile(line);
            }
        }

        //ログファイル出力
        private static void LogToFile(string line)
        {
            using (var sw = new StreamWriter(logFileName, true, Encoding.Default))
            {
                string lineNew = DateTime.Now.ToString() + " " + line;
                sw.WriteLine(lineNew);
            }
        }
    }

}