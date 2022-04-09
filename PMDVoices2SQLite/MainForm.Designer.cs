namespace PMDVoices2SQLite
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMLファイルを開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mMLファイルを保存SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonMMLPath = new System.Windows.Forms.Button();
            this.buttonDBPath = new System.Windows.Forms.Button();
            this.buttonMML2SQLite = new System.Windows.Forms.Button();
            this.buttonSQLite2MML = new System.Windows.Forms.Button();
            this.buttonSearchDB = new System.Windows.Forms.Button();
            this.comboBoxMMLPath = new System.Windows.Forms.ComboBox();
            this.comboBoxDBPath = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mMLファイルを開くOToolStripMenuItem,
            this.mMLファイルを保存SToolStripMenuItem,
            this.toolStripSeparator1,
            this.終了XToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.ファイルToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // mMLファイルを開くOToolStripMenuItem
            // 
            this.mMLファイルを開くOToolStripMenuItem.Name = "mMLファイルを開くOToolStripMenuItem";
            this.mMLファイルを開くOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mMLファイルを開くOToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.mMLファイルを開くOToolStripMenuItem.Text = "MMLファイルを開く(&O)";
            this.mMLファイルを開くOToolStripMenuItem.Click += new System.EventHandler(this.mMLファイルを開くOToolStripMenuItem_Click);
            // 
            // mMLファイルを保存SToolStripMenuItem
            // 
            this.mMLファイルを保存SToolStripMenuItem.Name = "mMLファイルを保存SToolStripMenuItem";
            this.mMLファイルを保存SToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.mMLファイルを保存SToolStripMenuItem.Text = "MMLファイルを保存(&S)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(273, 6);
            // 
            // 終了XToolStripMenuItem
            // 
            this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
            this.終了XToolStripMenuItem.Size = new System.Drawing.Size(276, 26);
            this.終了XToolStripMenuItem.Text = "終了(&X)";
            this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "MMLファイルパス";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "SQLiteファイルパス";
            // 
            // buttonMMLPath
            // 
            this.buttonMMLPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMMLPath.Location = new System.Drawing.Point(694, 62);
            this.buttonMMLPath.Name = "buttonMMLPath";
            this.buttonMMLPath.Size = new System.Drawing.Size(94, 29);
            this.buttonMMLPath.TabIndex = 7;
            this.buttonMMLPath.Text = "参照…";
            this.buttonMMLPath.UseVisualStyleBackColor = true;
            this.buttonMMLPath.Click += new System.EventHandler(this.buttonMMLPath_Click);
            // 
            // buttonDBPath
            // 
            this.buttonDBPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDBPath.Location = new System.Drawing.Point(694, 118);
            this.buttonDBPath.Name = "buttonDBPath";
            this.buttonDBPath.Size = new System.Drawing.Size(94, 29);
            this.buttonDBPath.TabIndex = 8;
            this.buttonDBPath.Text = "参照…";
            this.buttonDBPath.UseVisualStyleBackColor = true;
            this.buttonDBPath.Click += new System.EventHandler(this.buttonDBPath_Click);
            // 
            // buttonMML2SQLite
            // 
            this.buttonMML2SQLite.Location = new System.Drawing.Point(13, 188);
            this.buttonMML2SQLite.Name = "buttonMML2SQLite";
            this.buttonMML2SQLite.Size = new System.Drawing.Size(147, 29);
            this.buttonMML2SQLite.TabIndex = 9;
            this.buttonMML2SQLite.Text = "MML -> SQLite";
            this.buttonMML2SQLite.UseVisualStyleBackColor = true;
            this.buttonMML2SQLite.Click += new System.EventHandler(this.buttonMML2SQLite_Click);
            // 
            // buttonSQLite2MML
            // 
            this.buttonSQLite2MML.Location = new System.Drawing.Point(166, 188);
            this.buttonSQLite2MML.Name = "buttonSQLite2MML";
            this.buttonSQLite2MML.Size = new System.Drawing.Size(147, 29);
            this.buttonSQLite2MML.TabIndex = 10;
            this.buttonSQLite2MML.Text = "SQLite -> MML";
            this.buttonSQLite2MML.UseVisualStyleBackColor = true;
            this.buttonSQLite2MML.Click += new System.EventHandler(this.buttonSQLite2MML_Click);
            // 
            // buttonSearchDB
            // 
            this.buttonSearchDB.Location = new System.Drawing.Point(13, 223);
            this.buttonSearchDB.Name = "buttonSearchDB";
            this.buttonSearchDB.Size = new System.Drawing.Size(300, 29);
            this.buttonSearchDB.TabIndex = 11;
            this.buttonSearchDB.Text = "SQLiteDB内をMMLの音色でサーチ";
            this.buttonSearchDB.UseVisualStyleBackColor = true;
            this.buttonSearchDB.Click += new System.EventHandler(this.buttonSearchDB_Click);
            // 
            // comboBoxMMLPath
            // 
            this.comboBoxMMLPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMMLPath.FormattingEnabled = true;
            this.comboBoxMMLPath.Location = new System.Drawing.Point(140, 64);
            this.comboBoxMMLPath.Name = "comboBoxMMLPath";
            this.comboBoxMMLPath.Size = new System.Drawing.Size(548, 28);
            this.comboBoxMMLPath.TabIndex = 12;
            this.comboBoxMMLPath.SelectedIndexChanged += new System.EventHandler(this.comboBoxMMLPath_SelectedIndexChanged);
            // 
            // comboBoxDBPath
            // 
            this.comboBoxDBPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDBPath.FormattingEnabled = true;
            this.comboBoxDBPath.Location = new System.Drawing.Point(140, 119);
            this.comboBoxDBPath.Name = "comboBoxDBPath";
            this.comboBoxDBPath.Size = new System.Drawing.Size(548, 28);
            this.comboBoxDBPath.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBoxDBPath);
            this.Controls.Add(this.comboBoxMMLPath);
            this.Controls.Add(this.buttonSearchDB);
            this.Controls.Add(this.buttonSQLite2MML);
            this.Controls.Add(this.buttonMML2SQLite);
            this.Controls.Add(this.buttonDBPath);
            this.Controls.Add(this.buttonMMLPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PMDVoices2SQLite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ファイルToolStripMenuItem;
        private ToolStripMenuItem mMLファイルを開くOToolStripMenuItem;
        private ToolStripMenuItem mMLファイルを保存SToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem 終了XToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Button buttonMMLPath;
        private Button buttonDBPath;
        private Button buttonMML2SQLite;
        private Button buttonSQLite2MML;
        private Button buttonSearchDB;
        private ComboBox comboBoxMMLPath;
        private ComboBox comboBoxDBPath;
    }
}