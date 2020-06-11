namespace maReplace
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.maLV = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pathTC = new System.Windows.Forms.TabControl();
            this.refTP = new System.Windows.Forms.TabPage();
            this.refLV = new System.Windows.Forms.ListView();
            this.textureTP = new System.Windows.Forms.TabPage();
            this.texLV = new System.Windows.Forms.ListView();
            this.abcTP = new System.Windows.Forms.TabPage();
            this.abcLV = new System.Windows.Forms.ListView();
            this.wavTP = new System.Windows.Forms.TabPage();
            this.audioLV = new System.Windows.Forms.ListView();
            this.loadBTN = new System.Windows.Forms.Button();
            this.searchBTN = new System.Windows.Forms.Button();
            this.exportBTN = new System.Windows.Forms.Button();
            this.exitBTN = new System.Windows.Forms.Button();
            this.mafileLBL = new System.Windows.Forms.Label();
            this.filepathLBL = new System.Windows.Forms.Label();
            this.aboutBTN = new System.Windows.Forms.Button();
            this.clearmaBTN = new System.Windows.Forms.Button();
            this.clearpathBTN = new System.Windows.Forms.Button();
            this.replaceBTN = new System.Windows.Forms.Button();
            this.logBTN = new System.Windows.Forms.Button();
            this.logTB = new System.Windows.Forms.TextBox();
            this.logLBL = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pathTC.SuspendLayout();
            this.refTP.SuspendLayout();
            this.textureTP.SuspendLayout();
            this.abcTP.SuspendLayout();
            this.wavTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.aboutBTN, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.clearmaBTN, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearpathBTN, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.logBTN, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.searchBTN, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.logLBL, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.maLV, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.mafileLBL, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.filepathLBL, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.pathTC, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.logTB, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.loadBTN, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.replaceBTN, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.exportBTN, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.exitBTN, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(545, 507);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // maLV
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.maLV, 2);
            this.maLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maLV.LargeImageList = this.imageList1;
            this.maLV.Location = new System.Drawing.Point(105, 49);
            this.maLV.Name = "maLV";
            this.maLV.Size = new System.Drawing.Size(391, 173);
            this.maLV.TabIndex = 1;
            this.maLV.UseCompatibleStateImageBehavior = false;
            this.maLV.View = System.Windows.Forms.View.SmallIcon;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Bucket.ico");
            this.imageList1.Images.SetKeyName(1, "Crab.ico");
            this.imageList1.Images.SetKeyName(2, "Help.ico");
            this.imageList1.Images.SetKeyName(3, "Shark.ico");
            this.imageList1.Images.SetKeyName(4, "Shell.ico");
            this.imageList1.Images.SetKeyName(5, "Starfish.ico");
            this.imageList1.Images.SetKeyName(6, "Sun.ico");
            this.imageList1.Images.SetKeyName(7, "Sunshade.ico");
            this.imageList1.Images.SetKeyName(8, "Surf.ico");
            this.imageList1.Images.SetKeyName(9, "Wave.ico");
            this.imageList1.Images.SetKeyName(10, "red_delete_32px_1075470_easyicon.net.png");
            this.imageList1.Images.SetKeyName(11, "folder_32px_1201082_easyicon.net.ico");
            // 
            // pathTC
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pathTC, 2);
            this.pathTC.Controls.Add(this.refTP);
            this.pathTC.Controls.Add(this.textureTP);
            this.pathTC.Controls.Add(this.abcTP);
            this.pathTC.Controls.Add(this.wavTP);
            this.pathTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathTC.Location = new System.Drawing.Point(105, 284);
            this.pathTC.Name = "pathTC";
            this.pathTC.SelectedIndex = 0;
            this.pathTC.Size = new System.Drawing.Size(391, 173);
            this.pathTC.TabIndex = 2;
            // 
            // refTP
            // 
            this.refTP.Controls.Add(this.refLV);
            this.refTP.Location = new System.Drawing.Point(4, 22);
            this.refTP.Name = "refTP";
            this.refTP.Padding = new System.Windows.Forms.Padding(3);
            this.refTP.Size = new System.Drawing.Size(383, 147);
            this.refTP.TabIndex = 0;
            this.refTP.Text = "Reference";
            this.refTP.UseVisualStyleBackColor = true;
            // 
            // refLV
            // 
            this.refLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refLV.Location = new System.Drawing.Point(3, 3);
            this.refLV.Name = "refLV";
            this.refLV.Size = new System.Drawing.Size(377, 141);
            this.refLV.TabIndex = 0;
            this.refLV.UseCompatibleStateImageBehavior = false;
            this.refLV.View = System.Windows.Forms.View.Details;
            // 
            // textureTP
            // 
            this.textureTP.Controls.Add(this.texLV);
            this.textureTP.Location = new System.Drawing.Point(4, 22);
            this.textureTP.Name = "textureTP";
            this.textureTP.Padding = new System.Windows.Forms.Padding(3);
            this.textureTP.Size = new System.Drawing.Size(383, 158);
            this.textureTP.TabIndex = 1;
            this.textureTP.Text = "Texture";
            this.textureTP.UseVisualStyleBackColor = true;
            // 
            // texLV
            // 
            this.texLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texLV.Location = new System.Drawing.Point(3, 3);
            this.texLV.Name = "texLV";
            this.texLV.Size = new System.Drawing.Size(377, 152);
            this.texLV.TabIndex = 0;
            this.texLV.UseCompatibleStateImageBehavior = false;
            this.texLV.View = System.Windows.Forms.View.Details;
            // 
            // abcTP
            // 
            this.abcTP.Controls.Add(this.abcLV);
            this.abcTP.Location = new System.Drawing.Point(4, 22);
            this.abcTP.Name = "abcTP";
            this.abcTP.Size = new System.Drawing.Size(383, 158);
            this.abcTP.TabIndex = 2;
            this.abcTP.Text = "ABC";
            this.abcTP.UseVisualStyleBackColor = true;
            // 
            // abcLV
            // 
            this.abcLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abcLV.Location = new System.Drawing.Point(0, 0);
            this.abcLV.Name = "abcLV";
            this.abcLV.Size = new System.Drawing.Size(383, 158);
            this.abcLV.TabIndex = 0;
            this.abcLV.UseCompatibleStateImageBehavior = false;
            this.abcLV.View = System.Windows.Forms.View.Details;
            // 
            // wavTP
            // 
            this.wavTP.Controls.Add(this.audioLV);
            this.wavTP.Location = new System.Drawing.Point(4, 22);
            this.wavTP.Name = "wavTP";
            this.wavTP.Padding = new System.Windows.Forms.Padding(3);
            this.wavTP.Size = new System.Drawing.Size(383, 158);
            this.wavTP.TabIndex = 3;
            this.wavTP.Text = "Audio";
            this.wavTP.UseVisualStyleBackColor = true;
            // 
            // audioLV
            // 
            this.audioLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.audioLV.Location = new System.Drawing.Point(3, 3);
            this.audioLV.Name = "audioLV";
            this.audioLV.Size = new System.Drawing.Size(377, 152);
            this.audioLV.TabIndex = 0;
            this.audioLV.UseCompatibleStateImageBehavior = false;
            this.audioLV.View = System.Windows.Forms.View.Details;
            // 
            // loadBTN
            // 
            this.loadBTN.Location = new System.Drawing.Point(15, 49);
            this.loadBTN.Name = "loadBTN";
            this.loadBTN.Size = new System.Drawing.Size(75, 23);
            this.loadBTN.TabIndex = 3;
            this.loadBTN.Text = "Load...";
            this.loadBTN.UseVisualStyleBackColor = true;
            this.loadBTN.Click += new System.EventHandler(this.loadBTN_Click);
            // 
            // searchBTN
            // 
            this.searchBTN.Location = new System.Drawing.Point(15, 284);
            this.searchBTN.Name = "searchBTN";
            this.searchBTN.Size = new System.Drawing.Size(75, 23);
            this.searchBTN.TabIndex = 4;
            this.searchBTN.Text = "Search";
            this.searchBTN.UseVisualStyleBackColor = true;
            this.searchBTN.Click += new System.EventHandler(this.searchBTN_Click);
            // 
            // exportBTN
            // 
            this.exportBTN.Location = new System.Drawing.Point(105, 463);
            this.exportBTN.Name = "exportBTN";
            this.exportBTN.Size = new System.Drawing.Size(75, 23);
            this.exportBTN.TabIndex = 5;
            this.exportBTN.Text = "Export";
            this.exportBTN.UseVisualStyleBackColor = true;
            this.exportBTN.Click += new System.EventHandler(this.exportBTN_Click);
            // 
            // exitBTN
            // 
            this.exitBTN.Location = new System.Drawing.Point(15, 463);
            this.exitBTN.Name = "exitBTN";
            this.exitBTN.Size = new System.Drawing.Size(75, 23);
            this.exitBTN.TabIndex = 6;
            this.exitBTN.Text = "Exit";
            this.exitBTN.UseVisualStyleBackColor = true;
            this.exitBTN.Click += new System.EventHandler(this.exitBTN_Click);
            // 
            // mafileLBL
            // 
            this.mafileLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mafileLBL.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.mafileLBL, 2);
            this.mafileLBL.Location = new System.Drawing.Point(105, 34);
            this.mafileLBL.Name = "mafileLBL";
            this.mafileLBL.Size = new System.Drawing.Size(95, 12);
            this.mafileLBL.TabIndex = 7;
            this.mafileLBL.Text = "Maya ACSII File";
            // 
            // filepathLBL
            // 
            this.filepathLBL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filepathLBL.AutoSize = true;
            this.filepathLBL.Location = new System.Drawing.Point(105, 269);
            this.filepathLBL.Name = "filepathLBL";
            this.filepathLBL.Size = new System.Drawing.Size(59, 12);
            this.filepathLBL.TabIndex = 8;
            this.filepathLBL.Text = "File Path";
            // 
            // aboutBTN
            // 
            this.aboutBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutBTN.ImageIndex = 2;
            this.aboutBTN.ImageList = this.imageList1;
            this.aboutBTN.Location = new System.Drawing.Point(502, 15);
            this.aboutBTN.Name = "aboutBTN";
            this.aboutBTN.Size = new System.Drawing.Size(28, 28);
            this.aboutBTN.TabIndex = 9;
            this.aboutBTN.UseVisualStyleBackColor = true;
            this.aboutBTN.Click += new System.EventHandler(this.aboutBTN_Click);
            // 
            // clearmaBTN
            // 
            this.clearmaBTN.ImageIndex = 10;
            this.clearmaBTN.ImageList = this.imageList1;
            this.clearmaBTN.Location = new System.Drawing.Point(502, 49);
            this.clearmaBTN.Name = "clearmaBTN";
            this.clearmaBTN.Size = new System.Drawing.Size(28, 30);
            this.clearmaBTN.TabIndex = 10;
            this.clearmaBTN.UseVisualStyleBackColor = true;
            this.clearmaBTN.Click += new System.EventHandler(this.clearmaBTN_Click);
            // 
            // clearpathBTN
            // 
            this.clearpathBTN.ImageIndex = 10;
            this.clearpathBTN.ImageList = this.imageList1;
            this.clearpathBTN.Location = new System.Drawing.Point(502, 284);
            this.clearpathBTN.Name = "clearpathBTN";
            this.clearpathBTN.Size = new System.Drawing.Size(28, 30);
            this.clearpathBTN.TabIndex = 11;
            this.clearpathBTN.UseVisualStyleBackColor = true;
            this.clearpathBTN.Click += new System.EventHandler(this.clearpathBTN_Click);
            // 
            // replaceBTN
            // 
            this.replaceBTN.Location = new System.Drawing.Point(195, 463);
            this.replaceBTN.Name = "replaceBTN";
            this.replaceBTN.Size = new System.Drawing.Size(115, 23);
            this.replaceBTN.TabIndex = 12;
            this.replaceBTN.Text = "Replace to New";
            this.replaceBTN.UseVisualStyleBackColor = true;
            this.replaceBTN.Click += new System.EventHandler(this.replaceBTN_Click);
            // 
            // logBTN
            // 
            this.logBTN.ImageIndex = 11;
            this.logBTN.ImageList = this.imageList1;
            this.logBTN.Location = new System.Drawing.Point(502, 228);
            this.logBTN.Name = "logBTN";
            this.logBTN.Size = new System.Drawing.Size(28, 28);
            this.logBTN.TabIndex = 13;
            this.logBTN.UseVisualStyleBackColor = true;
            this.logBTN.Click += new System.EventHandler(this.logBTN_Click);
            // 
            // logTB
            // 
            this.logTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.logTB, 2);
            this.logTB.Location = new System.Drawing.Point(105, 231);
            this.logTB.Name = "logTB";
            this.logTB.ReadOnly = true;
            this.logTB.Size = new System.Drawing.Size(391, 21);
            this.logTB.TabIndex = 14;
            // 
            // logLBL
            // 
            this.logLBL.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logLBL.AutoSize = true;
            this.logLBL.Location = new System.Drawing.Point(46, 236);
            this.logLBL.Name = "logLBL";
            this.logLBL.Size = new System.Drawing.Size(53, 12);
            this.logLBL.TabIndex = 15;
            this.logLBL.Text = "Log Path";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "mainForm";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pathTC.ResumeLayout(false);
            this.refTP.ResumeLayout(false);
            this.textureTP.ResumeLayout(false);
            this.abcTP.ResumeLayout(false);
            this.wavTP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView maLV;
        private System.Windows.Forms.TabControl pathTC;
        private System.Windows.Forms.TabPage refTP;
        private System.Windows.Forms.TabPage textureTP;
        private System.Windows.Forms.TabPage abcTP;
        private System.Windows.Forms.Button loadBTN;
        private System.Windows.Forms.Button searchBTN;
        private System.Windows.Forms.Button exportBTN;
        private System.Windows.Forms.Button exitBTN;
        private System.Windows.Forms.Label mafileLBL;
        private System.Windows.Forms.Label filepathLBL;
        private System.Windows.Forms.Button aboutBTN;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage wavTP;
        private System.Windows.Forms.Button clearmaBTN;
        private System.Windows.Forms.Button clearpathBTN;
        private System.Windows.Forms.ListView refLV;
        private System.Windows.Forms.ListView texLV;
        private System.Windows.Forms.ListView abcLV;
        private System.Windows.Forms.ListView audioLV;
        private System.Windows.Forms.Button replaceBTN;
        private System.Windows.Forms.Button logBTN;
        private System.Windows.Forms.TextBox logTB;
        private System.Windows.Forms.Label logLBL;
    }
}

