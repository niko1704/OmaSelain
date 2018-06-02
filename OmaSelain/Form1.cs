using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OmaSelain
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            ControlBox = false;
            Text = null;

            suljeVälilehtiToolStripMenuItem.Enabled = false;

            AvaaValilehti();
        }
        //WebBrowser wb = new WebBrowser();
        int i = 0;
        Microsoft.Win32.RegistryKey key;
        



        public void wb_DocumentCompleted(object sender, EventArgs e)
        {
            //      browser.Size = browser.Document.Body.ScrollRectangle.Size;
            //      Form1.ActiveForm.Width = browser.Document.Body.ScrollRectangle.Width;
            // Form1.ActiveForm.Size = WebBrowser.Size;

            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
            if (!toolStripComboBox1.Focused == true)

            {
                toolStripComboBox1.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url.AbsoluteUri;
            }
        }
        


        private void MeneOsoitteeseen()
        {
            if (toolStripComboBox1.Text.Contains("."))
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(toolStripComboBox1.Text);
                if (!toolStripComboBox1.Items.Contains(toolStripComboBox1.Text))
                {
                    toolStripComboBox1.Items.Add(toolStripComboBox1.Text);
                }
                //browser.Navigate(comboBox1.Text);
            }

            else
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("https://www.google.fi/search?q=" + (toolStripComboBox1.Text));
            }

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            // textBox1.Text = winFormsBrowserView1.URL;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // comboBox1.Text = textBox1.Text;
            // comboBox1.Text = winFormsBrowserView1.URL;

            // tabPage1.Text = winFormsBrowserView1.URL.Substring(8,9);
            //tabPage.Text = winFormsBrowserView1.URL.Substring(8, 9);
        }

        public void toolStripButton2_Click(object sender, EventArgs e)
        {
            AvaaValilehti();
        }

        public void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //textBox1.Text = webBrowser1.Url.ToString();
            //  textBox1.Text = this.webBrowser.Url.ToString();


        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            
            toolStripProgressBar1.Maximum = (int)e.MaximumProgress;
            if (e.CurrentProgress > 0)
                try
                {
                    toolStripProgressBar1.Value = (int)e.CurrentProgress;
                }
                catch { }


        }

        public void toolStripButton1_Click(object sender, EventArgs e)
        {

            MeneOsoitteeseen();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1.PerformClick();
            }
        }



        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int currWidth = toolStripComboBox1.Width;
            int x = toolStrip1.Items.OfType<ToolStripItem>().Sum(t => t.Width);
            toolStripComboBox1.Size = new Size(toolStrip1.Width - x + currWidth - 30, toolStripComboBox1.Height);
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            // string currentKey = key.GetValue("OmaSelain.exe").ToString();
            //if (currentKey != "0")

            //  if (key.GetValue("OmaSelain.exe").ToString() != null)
            //if (key.GetValue="OmaSelain.exe);
            if (key != null)

            {
                key.SetValue("OmaSelain.exe", unchecked((int)0x2af9), RegistryValueKind.DWord);
            }
            else
            {


            }
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AvaaValilehti();
        }

        private void toolStrip1_Layout(object sender, LayoutEventArgs e)
        {


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int currWidth = toolStripComboBox1.Width;
            int x = toolStrip1.Items.OfType<ToolStripItem>().Sum(t => t.Width);
            toolStripComboBox1.Size = new Size(toolStrip1.Width - x + currWidth - 30, toolStripComboBox1.Height);
        }

        private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton1.PerformClick();
            }
        }

        private void kopioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^c");
        }

        private void liitäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^v");
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!Clipboard.ContainsText())
            {
                liitäToolStripMenuItem.Enabled = false;
            }
            else
            {
                liitäToolStripMenuItem.Enabled = true;
            }

            if (tabControl1.TabPages.Count - 1 > 0)
            {
                suljeVälilehtiToolStripMenuItem.Enabled = true;
            }


        }

        private void suljeVälilehtiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
            tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
            i -= 1;

        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            suljeVälilehtiToolStripMenuItem.Enabled = false;

        }

        private void uusiVälilehtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AvaaValilehti();
            
        }
        public void AvaaValilehti()
        {
            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.IsWebBrowserContextMenuEnabled = false;
            wb.ContextMenuStrip = contextMenuStrip1;
            wb.Navigate("www.google.com");
            wb.ScriptErrorsSuppressed = true;
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_DocumentCompleted);
            wb.ProgressChanged += new WebBrowserProgressChangedEventHandler(webBrowser_ProgressChanged);
           


            tabControl1.TabPages.Add("");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(wb);
            i += 1;

          
        }



        private void sammutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (Form1.ActiveForm.WindowState.ToString() != "Maximized")
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Maximized ;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }

       

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (Form1.ActiveForm.WindowState.ToString() == "Normal")
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Minimized;
            }

            else if (Form1.ActiveForm.WindowState.ToString() == "Maximized")
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
              //  Form1.ActiveForm.Width = .Width;
            }
        }
    }
}
