using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSort
{
    public partial class Form1 : Form
    {
        private static List<string> img = new List<string> { "img", "bmp", "png", "jpeg", "gif" };
        private static List<string> vid = new List<string> { "mp4", "avi", "vid", "mkv", "mpeg" };
        private static List<string> app = new List<string> { "exe", "bat", "com" };
        private static List<string> doc = new List<string> { "txt", "doc", "docx", "jnt", "xls", "xlsx", "pdf" };

        private DirectoryInfo dir;

        public Form1()
        {
            InitializeComponent();
        }

        private void init(DirectoryInfo d)
        {
            if (cimg.Checked==true && !Directory.Exists(Path.Combine(d.FullName, "Images")))
                d.CreateSubdirectory("Images");
            if (cvid.Checked == true && !Directory.Exists(Path.Combine(d.FullName, "Videos")))
                d.CreateSubdirectory("Videos");
            if (cdoc.Checked == true && !Directory.Exists(Path.Combine(d.FullName, "Documents")))
                d.CreateSubdirectory("Documents");
            if (capp.Checked == true && !Directory.Exists(Path.Combine(d.FullName, "Applications")))
                d.CreateSubdirectory("Applications");
            if (!Directory.Exists(Path.Combine(d.FullName, "Other")))
                d.CreateSubdirectory("Other");
            if (!Directory.Exists(Path.Combine(d.FullName, "Invalid")))
                d.CreateSubdirectory("Invalid");
        }

        private void sortFiles(DirectoryInfo d)
        {
            foreach (var f in d.GetFiles())
            {
                lcfile.Text = f.Name + "...";
                string s;
                int x=1;

                #region moves
                try
                {
                    if (cimg.Checked == true && img.Contains(f.Name.Split('.')[1]))
                    {
                        s = Path.Combine(dir.FullName, "Images", f.Name);
                        if (s != f.FullName)
                        {
                            while (File.Exists(s))
                            {
                                s = (x == 1) ? (s.Split('.')[0] + "(1)." + s.Split('.')[1]) : (s.Split('(')[0] + "(" + x.ToString() + ")." + s.Split('.')[1]);
                                x++;
                            }
                            f.MoveTo(s);
                        }
                    }
                    else if (cvid.Checked == true && vid.Contains(f.Name.Split('.')[1]))
                    {
                        s = Path.Combine(dir.FullName, "Videos", f.Name);
                        if (s != f.FullName)
                        {
                            while (File.Exists(s))
                            {
                                s = (x == 1) ? s.Split('.')[0] + "(1)." + s.Split('.')[1] : s.Split('(')[0] + "(" + x.ToString() + ")." + s.Split('.')[1];
                                x++;
                            }
                            f.MoveTo(s);
                        }
                    }
                    else if (cdoc.Checked == true && doc.Contains(f.Name.Split('.')[1]))
                    {
                        s = Path.Combine(dir.FullName, "Documents", f.Name);
                        if (s != f.FullName)
                        {
                            while (File.Exists(s))
                            {
                                s = (x == 1) ? s.Split('.')[0] + "(1)." + s.Split('.')[1] : s.Split('(')[0] + "(" + x.ToString() + ")." + s.Split('.')[1];
                                x++;
                            }
                            f.MoveTo(s);
                        }
                    }
                    else if (capp.Checked == true && app.Contains(f.Name.Split('.')[1]))
                    {
                        s = Path.Combine(dir.FullName, "Applications", f.Name);
                        if (s != f.FullName)
                        {
                            while (File.Exists(s))
                            {
                                s = (x == 1) ? s.Split('.')[0] + "(1)." + s.Split('.')[1] : s.Split('(')[0] + "(" + x.ToString() + ")." + s.Split('.')[1];
                                x++;
                            }
                            f.MoveTo(s);
                        }
                    }
                    else
                    {
                        s = Path.Combine(dir.FullName, "Other", f.Name);
                        if (s != f.FullName)
                        {
                            while (File.Exists(s))
                            {
                                s = (x == 1) ? s.Split('.')[0] + "(1)." + s.Split('.')[1] : s.Split('(')[0] + "(" + x.ToString() + ")." + s.Split('.')[1];
                                x++;
                            }
                            f.MoveTo(s);
                        }
                    }
                }
                catch (Exception e)
                {
                    x = 1;
                    s = Path.Combine(dir.FullName, "Invalid", f.Name);
                    if (s != f.FullName)
                    {
                        while (File.Exists(s))
                        {
                            s = (x == 1) ? s.Split('.')[0] + "(1)." + s.Split('.')[1] : s.Split('(')[0] + "(" + x.ToString() + ")." + s.Split('.')[1];
                            x++;
                        }
                        f.MoveTo(s);
                    }
                    MessageBox.Show(e.Message);
                }
                #endregion
            }
            foreach (var d2 in d.GetDirectories())
                sortFiles(d2);
            if (!(d.Name == "Images" || d.Name == "Videos" || d.Name == "Documents" || d.Name == "Applications" || d.Name == "Other" || d.Name == "Invalid" || d.Name == dir.Name))
                d.Delete(true);
        }

        private void bbrowse_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                lstatus.Text = "Stand by...";
                tbdir.Text = folderDialog.SelectedPath;
                dir = new DirectoryInfo(folderDialog.SelectedPath);
                bsort.Enabled = true;
                cimg.Enabled = true;
                cvid.Enabled = true;
                capp.Enabled = true;
                cdoc.Enabled = true;
            }
        }

        private void bsort_Click(object sender, EventArgs e)
        {
            lstatus.Text = "Sorting...";
            bsort.Enabled = false;
            cimg.Enabled = false;
            cvid.Enabled = false;
            capp.Enabled = false;
            cdoc.Enabled = false;
            bbrowse.Enabled = false;

            init(dir);
            sortFiles(dir);

            lstatus.Text = "Completed";
            bsort.Enabled = true;
            cimg.Enabled = true;
            cvid.Enabled = true;
            capp.Enabled = true;
            cdoc.Enabled = true;
            bbrowse.Enabled = true;
        }


    }
}
