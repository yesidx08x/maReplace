using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace maReplace
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        private string locpath = System.Environment.CurrentDirectory;
        private string[] headerA = new string[] 
        { "file -rdi 1 -ns ", 
            "file -r -ns " ,
        "createNode AlembicNode -n ",
        "createNode reference -n ",
        "createNode audio -n "};

        private void loadBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Maya ASCII Files";
            ofd.Filter = "Maya ASCII File(*.ma)|*.ma";
            ofd.Multiselect = true;
            DialogResult result=ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach(string filename in ofd.FileNames)
                {
                    if(File.Exists(filename))
                    {
                        FileInfo fi=new FileInfo(filename);
                        ListViewItem item = new ListViewItem();
                        item.Name = fi.FullName;
                        item.Text = fi.Name;
                        item.SubItems.Add(fi.FullName);
                        item.SubItems[1].Text = fi.FullName;
                        item.Text = fi.Name;
                        item.ImageIndex = 5;
                        maLV.Items.Add(item);
                    }

                }
            }
            ofd.Dispose();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " " + Application.ProductVersion;
            setPathLV();
            logTB.Text = Path.Combine(locpath, "log");
        }

        private void searchBTN_Click(object sender, EventArgs e)
        {
            string strLine = "";
            string logpath = logTB.Text;
            FileInfo[] fiLogA = logFileInfo(logpath);
            Dictionary<string, Dictionary<string, string>> logDictD=new Dictionary<string,Dictionary<string,string>>();
            if (fiLogA == null)
            {
                return;
            }
            else
            {
                logDictD=getDictFromLog(fiLogA);
            }
            System.DateTime TimeNow = new DateTime();
            TimeSpan TimeCount = new TimeSpan();
            TimeNow = DateTime.Now;

            foreach (ListViewItem item in maLV.Items)
            {
                try
                {
                    FileStream fs = new FileStream(item.SubItems[1].Text, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    strLine = sr.ReadLine();
                    while (strLine != null)
                    {
                        if (strLine.Contains("connectAttr "))
                            break;
                        if (strLine.Length > 7 && strLine.Substring(0, 7) == "file -r")
                        {
                            strLine = sr.ReadLine();
                            string[] strLineA = strLine.Split('\"');
                            if (strLineA.Length > 3 && strLineA[strLineA.Length - 1] == ";")
                            {
                                string refFile = strLineA[strLineA.Length - 2];
                                ListViewItem itm = new ListViewItem();
                                itm.Text = item.Text;
                                item.Name = item.Name;
                                itm.SubItems.Add(refFile);
                                //从log找到新复制过的文件
                                string newfile = searchInLog(refFile, logDictD);
                                if(newfile=="")
                                {
                                    itm.SubItems.Add("null");
                                }
                                else
                                {
                                    itm.SubItems.Add(newfile);
                                }
                                //加类型名
                                itm.SubItems.Add("reference");
                                refLV.Items.Add(itm);
                            }

                        }
                        else if (strLine.Contains("createNode AlembicNode -n ")
                            || strLine.Contains("createNode file -n ")
                            || strLine.Contains("createNode reference -n ")
                            || strLine.Contains("createNode audio -n "))
                        {
                            string label = strLine.Split(' ')[1];
                            strLine = sr.ReadLine();
                            //bool strChk = strLine.Length > 11 && strLine.Substring(0, 11) == "createNode ";
                            while (strLine != null)
                            {
                                if (strLine.Contains("setAttr \".f"))
                                {
                                    string[] strLineA = strLine.Split('\"');
                                    if (strLineA.Length > 3 && strLineA[strLineA.Length - 1] == ";")
                                    {
                                        string destFile = strLineA[strLineA.Length - 2];
                                        ListViewItem itm = new ListViewItem();
                                        itm.Text = item.Text;
                                        itm.SubItems.Add(destFile);
                                        //从log找到新复制过的文件
                                        string newfile = searchInLog(destFile, logDictD);
                                        if (newfile == "")
                                        {
                                            itm.SubItems.Add("null");
                                        }
                                        else
                                        {
                                            itm.SubItems.Add(newfile);
                                        }
                                        //加类型名
                                        if (label == "AlembicNode")
                                        {
                                            itm.SubItems.Add("alembic");
                                            abcLV.Items.Add(itm);
                                        }
                                        else if (label == "file")
                                        {
                                            itm.SubItems.Add("texture");
                                            texLV.Items.Add(itm);
                                        }
                                        else if (label == "audio")
                                        {
                                            itm.SubItems.Add("audio");
                                            audioLV.Items.Add(itm);
                                        }
                                        else if (label == "reference")
                                        {
                                            itm.SubItems.Add("subReference");
                                            refLV.Items.Add(itm);
                                        }
                                        //MessageBox.Show(strLineA[strLineA.Length - 2]);
                                    }


                                }
                                else if (!strLine.Contains("setAttr ") && !strLine.Contains("rename -uid "))
                                    break;
                                strLine = sr.ReadLine();
                            }
                        }
                        strLine = sr.ReadLine();

                    }
                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:文件读取错误\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TimeCount = DateTime.Now - TimeNow;
            string txtTimeShow = string.Format("{0:00}:{1:00}:{2:00}", TimeCount.Hours, TimeCount.Minutes, TimeCount.Seconds);

            MessageBox.Show("Information:查询ma场景完成\r\n共 " + maLV.Items.Count.ToString() + " 个文件\r\n共耗时 " + txtTimeShow, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearmaBTN_Click(object sender, EventArgs e)
        {
            maLV.Items.Clear();
        }

        private void clearpathBTN_Click(object sender, EventArgs e)
        {
            refLV.Items.Clear();
            abcLV.Items.Clear();
            texLV.Items.Clear();
            audioLV.Items.Clear();
        }
        /// <summary>
        /// 重设pathLV头
        /// </summary>
        private void setPathLV()
        {
            refLV.MultiSelect = true;
            refLV.CheckBoxes = false;
            refLV.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            abcLV.MultiSelect = true;
            abcLV.CheckBoxes = false;
            abcLV.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            texLV.MultiSelect = true;
            texLV.CheckBoxes = false;
            texLV.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            audioLV.MultiSelect = true;
            audioLV.CheckBoxes = false;
            audioLV.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "ma File";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 180;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Ref Path";
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            columnHeader2.Width = 400;

            ColumnHeader columnHeader3 = new ColumnHeader();
            columnHeader3.Text = "New Path";
            columnHeader3.TextAlign = HorizontalAlignment.Left;
            columnHeader3.Width = 400;

            ColumnHeader columnHeader4 = new ColumnHeader();
            columnHeader4.Text = "Kind";
            columnHeader4.TextAlign = HorizontalAlignment.Left;
            columnHeader4.Width = 80;

            refLV.Columns.Add(columnHeader1);
            refLV.Columns.Add(columnHeader2);
            refLV.Columns.Add(columnHeader3);
            refLV.Columns.Add(columnHeader4);

            ColumnHeader columnHeader1a = new ColumnHeader();
            columnHeader1a.Text = "ma File";
            columnHeader1a.TextAlign = HorizontalAlignment.Left;
            columnHeader1a.Width = 180;

            ColumnHeader columnHeader2a = new ColumnHeader();
            columnHeader2a.Text = "Abc Path";
            columnHeader2a.TextAlign = HorizontalAlignment.Left;
            columnHeader2a.Width = 400;

            ColumnHeader columnHeader3a = new ColumnHeader();
            columnHeader3a.Text = "New Path";
            columnHeader3a.TextAlign = HorizontalAlignment.Left;
            columnHeader3a.Width = 400;


            ColumnHeader columnHeader4a = new ColumnHeader();
            columnHeader4a.Text = "Kind";
            columnHeader4a.TextAlign = HorizontalAlignment.Left;
            columnHeader4a.Width = 80;

            abcLV.Columns.Add(columnHeader1a);
            abcLV.Columns.Add(columnHeader2a);
            abcLV.Columns.Add(columnHeader3a);
            abcLV.Columns.Add(columnHeader4a);

            ColumnHeader columnHeader1b = new ColumnHeader();
            columnHeader1b.Text = "ma File";
            columnHeader1b.TextAlign = HorizontalAlignment.Left;
            columnHeader1b.Width = 180;

            ColumnHeader columnHeader2b = new ColumnHeader();
            columnHeader2b.Text = "Textrue Path";
            columnHeader2b.TextAlign = HorizontalAlignment.Left;
            columnHeader2b.Width = 400;

            ColumnHeader columnHeader3b = new ColumnHeader();
            columnHeader3b.Text = "New Path";
            columnHeader3b.TextAlign = HorizontalAlignment.Left;
            columnHeader3b.Width = 400;

            ColumnHeader columnHeader4b = new ColumnHeader();
            columnHeader4b.Text = "Kind";
            columnHeader4b.TextAlign = HorizontalAlignment.Left;
            columnHeader4b.Width = 80;

            texLV.Columns.Add(columnHeader1b);
            texLV.Columns.Add(columnHeader2b);
            texLV.Columns.Add(columnHeader3b);
            texLV.Columns.Add(columnHeader4b);

            ColumnHeader columnHeader1c = new ColumnHeader();
            columnHeader1c.Text = "ma File";
            columnHeader1c.TextAlign = HorizontalAlignment.Left;
            columnHeader1c.Width = 180;

            ColumnHeader columnHeader2c = new ColumnHeader();
            columnHeader2c.Text = "Audio Path";
            columnHeader2c.TextAlign = HorizontalAlignment.Left;
            columnHeader2c.Width = 400;

            ColumnHeader columnHeader3c = new ColumnHeader();
            columnHeader3c.Text = "New Path";
            columnHeader3c.TextAlign = HorizontalAlignment.Left;
            columnHeader3c.Width = 400;

            ColumnHeader columnHeader4c = new ColumnHeader();
            columnHeader4c.Text = "Kind";
            columnHeader4c.TextAlign = HorizontalAlignment.Left;
            columnHeader4c.Width = 80;

            audioLV.Columns.Add(columnHeader1c);
            audioLV.Columns.Add(columnHeader2c);
            audioLV.Columns.Add(columnHeader3c);
            audioLV.Columns.Add(columnHeader4c);

        }

        private void exitBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 导出四个ListView里的内容为csv文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportBTN_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            List<string[]> csvList=exportCSV();
            string csvTxt = "";
            foreach(string[] cellA in csvList)
            {
                csvTxt = csvTxt + string.Join(",", cellA) + ",\r\n";
            }
            sfd.Title = "Save As CSV File";
            sfd.Filter = "csv File(*.csv)|*.csv";
             DialogResult result=sfd.ShowDialog();
            if (result == DialogResult.OK)
            {
                string csvfile = sfd.FileName;
                try
                {
                    if (File.Exists(csvfile))
                    {
                        DialogResult over = MessageBox.Show("Warning:目标文件已经存在，是否覆盖？", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (over == DialogResult.Yes)
                        {
                            File.Delete(csvfile);
                        }
                    }
                    File.WriteAllText(csvfile,csvTxt);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error:导出文件出错！\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<string[]> exportCSV()
        {
            List<string[]> fileTxtL = new List<string[]>();
            List<string> cellL = new List<string>();
            foreach(ListViewItem item in refLV.Items)
            {
                cellL.Add(item.SubItems[0].Text);
                cellL.Add(item.SubItems[1].Text);
                cellL.Add(item.SubItems[2].Text);
                cellL.Add(item.SubItems[3].Text);
                fileTxtL.Add(cellL.ToArray());
                cellL = new List<string>();

            }
            foreach (ListViewItem item in abcLV.Items)
            {
                cellL.Add(item.SubItems[0].Text);
                cellL.Add(item.SubItems[1].Text);
                cellL.Add(item.SubItems[2].Text);
                cellL.Add(item.SubItems[3].Text);
                fileTxtL.Add(cellL.ToArray());
                cellL = new List<string>();

            }
            foreach (ListViewItem item in texLV.Items)
            {
                cellL.Add(item.SubItems[0].Text);
                cellL.Add(item.SubItems[1].Text);
                cellL.Add(item.SubItems[2].Text);
                cellL.Add(item.SubItems[3].Text);
                fileTxtL.Add(cellL.ToArray());
                cellL = new List<string>();

            }
            foreach (ListViewItem item in audioLV.Items)
            {
                cellL.Add(item.SubItems[0].Text);
                cellL.Add(item.SubItems[1].Text);
                cellL.Add(item.SubItems[2].Text);
                cellL.Add(item.SubItems[3].Text);
                fileTxtL.Add(cellL.ToArray());
                cellL = new List<string>();

            }
            return fileTxtL;
        }
        /// <summary>
        /// 找目录下的log文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private FileInfo[] logFileInfo(string path)
        {
            List<FileInfo> fiL = new List<FileInfo>();
            if(!Directory.Exists(path))
            {
                MessageBox.Show("Error:log文件目录并不存在！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach(FileInfo fi in dir.GetFiles())
            {
                if(fi.Extension==".log")
                {
                    fiL.Add(fi);
                }
            }
            return fiL.ToArray();
        }
        /// <summary>
        /// 从log文件整理出字典
        /// </summary>
        /// <param name="fiPathA"></param>
        /// <returns></returns>
        private Dictionary<string, Dictionary<string, string>> getDictFromLog(FileInfo[] fiPathA)
        {
            string strLine = "";
            Dictionary<string, Dictionary<string, string>> logDictD = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> oneDict = new Dictionary<string, Dictionary<string, string>>();
            foreach(FileInfo fi in fiPathA)
            {
                 try
                {
                    FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    strLine = sr.ReadLine();
                    while (strLine != null)
                    {
                        oneDict=JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(strLine);
                        foreach(string key in oneDict.Keys)
                        {
                            logDictD.Add(logDictD.Keys.Count.ToString(),oneDict[key]);
                        }
                        strLine = sr.ReadLine();
                     }
                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:log文件读取错误！\r\n"+ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return logDictD;
        }
        /// <summary>
        /// 在log文件字典里找到原文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string searchInLog(string path, Dictionary<string, Dictionary<string, string>> logDictD)
        {

            string sourcefile = "";
            string destfile = "";
            foreach (string key in logDictD.Keys)
            {
                sourcefile = logDictD[key]["sourcefile"].Replace("\\", "/").ToLower();
                destfile = logDictD[key]["destfile"].Replace("\\", "/");
                string oldpath=path.Replace("\\", "/").ToLower();
                //可能有{1}这样的玩意儿,可能用了多象相UV,可能是序列纹理
                if ( oldpath == sourcefile)
                {
                    return destfile;
                }
                else if (oldpath.Length > 2 && sourcefile.Length > 2 && oldpath.ToCharArray()[1] == ':' && sourcefile.ToCharArray()[1] == ':')
                {
                    if(oldpath.Split(':')[1]==sourcefile.Split(':')[1])
                    {
                        return destfile;
                    }
                }
                else if(path.Contains('{')&& path.Split('{')[0] == sourcefile.ToLower())
                {
                    return destfile + "{" + path.Split('{')[1];
                }
            }
            return "";
        }

        private void aboutBTN_Click(object sender, EventArgs e)
        {
            AboutBox abtfrm = new AboutBox();
            abtfrm.ShowDialog();
        }
        /// <summary>
        /// 加载手工log目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logBTN_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if(result==DialogResult.OK)
            {
                logTB.Text = fbd.SelectedPath;
            }
        }

        /// <summary>
        /// 替换所有的文件内容里的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replaceBTN_Click(object sender, EventArgs e)
        {
            if(refLV.Items.Count<1 && texLV.Items.Count<1 && abcLV.Items.Count<1 && audioLV.Items.Count<1)
            {
                MessageBox.Show("Information:没有找到的文件路径！\r\n请先加载文件，点击search查找。", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string strLine="";
            string newLine = "";
            string bakFile = "";
            string oldLine = "";
            
            List<FileInfo> oldfiL = new List<FileInfo>();

            System.DateTime TimeNow = new DateTime();
            TimeSpan TimeCount = new TimeSpan();
            TimeNow = DateTime.Now;
            int n = 0;
             foreach (ListViewItem item in maLV.Items)
            {
                oldfiL = new List<FileInfo>();
                 FileInfo fi= new FileInfo(item.SubItems[1].Text);
                 oldfiL.Add(fi);
                 if (!renameFile(oldfiL.ToArray()))
                 {
                     return;
                 }
                 //当前场景的新旧文件路径字典
                 Dictionary<string, string> pathDict = getDict(item.Text);
                 
                 try
                 {
                     bakFile=item.SubItems[1].Text+".bak";
                     FileInfo ofi = new FileInfo(item.SubItems[1].Text);
                     using (FileStream fws = new FileStream(ofi.FullName+".rep", FileMode.OpenOrCreate, FileAccess.Write))
                     {

                         FileStream frs = new FileStream(bakFile, FileMode.Open, FileAccess.Read);
                         StreamReader srr = new StreamReader(frs);
                         strLine = srr.ReadLine();
                         while (strLine != null)
                         {
                             oldLine = strLine + "\r\n";
                             if (!oldLine.Contains("connectAttr \"")&&oldLine.Contains("\""))
                             {
                                 string[] oldLineA = oldLine.ToLower().Split('\"');
                                 newLine = oldLine;
                                 //foreach (string txt in oldLineA)
                                 
                                 if (oldLineA.Count()>2)
                                 {
                                     string txt = oldLineA[oldLineA.Count() - 2];
                                     foreach(string key in pathDict.Keys)
                                     {
                                         if (key.Replace("\\", "/").ToLower() == txt.Replace("\\", "/"))
                                         {
                                             string[] oldA=oldLine.Split('\"');
                                             oldA[oldA.Count()-2]=pathDict[key];
                                             newLine = String.Join("\"", oldA);
                                             n++;
                                             break;
                                         }
                                     }
                                 }
                             }
                             else
                             {
                                 newLine = oldLine ;
                             }

                             byte[] buffer = Encoding.Default.GetBytes(newLine);
                             fws.Write(buffer, 0, buffer.Length);
                             strLine = srr.ReadLine();
                         }
                         srr.Close();
                         srr.Dispose();
                         frs.Close();
                         frs.Dispose();
                         fws.Close();
                         fws.Dispose();
                     } 
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Error:文件读写错误！\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 
             }
             TimeCount = DateTime.Now - TimeNow;
             string txtTimeShow = string.Format("{0:00}:{1:00}:{2:00}", TimeCount.Hours, TimeCount.Minutes, TimeCount.Seconds);
             MessageBox.Show("Information:替换ma场景里的路径完成\r\n共 " + n.ToString() + " 个路径\r\n共耗时 " + txtTimeShow, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
        }
        private Dictionary<string, string> getDict(string maFile)
        {
            Dictionary<string, string> pathDict = new Dictionary<string, string>();
            foreach(ListViewItem item in refLV.Items)
            {
                if(item.Text == maFile)
                {
                    if (!pathDict.Keys.Contains(item.SubItems[1].Text.Replace("\\", "/")))
                    {
                        pathDict.Add(item.SubItems[1].Text.Replace("\\", "/"), item.SubItems[2].Text.Replace("\\", "/"));
                    }
                }
            }
            foreach (ListViewItem item in texLV.Items)
            {
                if (item.Text == maFile)
                {
                    if (!pathDict.Keys.Contains(item.SubItems[1].Text.Replace("\\", "/")))
                    {
                        pathDict.Add(item.SubItems[1].Text.Replace("\\", "/"), item.SubItems[2].Text.Replace("\\", "/"));
                    }
                }
            }
            foreach (ListViewItem item in abcLV.Items)
            {
                if (item.Text == maFile)
                {
                    if (!pathDict.Keys.Contains(item.SubItems[1].Text.Replace("\\", "/")))
                    {
                        pathDict.Add(item.SubItems[1].Text.Replace("\\", "/"), item.SubItems[2].Text.Replace("\\", "/"));
                    }
                }
            }
            foreach (ListViewItem item in audioLV.Items)
            {
                if (item.Text == maFile)
                {
                    if (!pathDict.Keys.Contains(item.SubItems[1].Text.Replace("\\", "/")))
                    {
                        pathDict.Add(item.SubItems[1].Text.Replace("\\", "/"), item.SubItems[2].Text.Replace("\\", "/"));
                    }
                }
            }
            return pathDict;
        }
        /// <summary>
        /// 先要创建bak文件备份
        /// </summary>
        /// <param name="fiA"></param>
        private bool renameFile(FileInfo[] fiA)
        {
            try
            {
                foreach (FileInfo fi in fiA)
                {
                    if (File.Exists(fi.FullName))
                    {
                        if (File.Exists(fi.FullName + ".bak"))
                            File.Delete(fi.FullName + ".bak");
                        File.Copy(fi.FullName, fi.FullName+".bak");

                    }
                    else
                    {
                        MessageBox.Show("Error:文件不存在！\r\n"+fi.FullName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:文件操作错误！\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
