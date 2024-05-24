using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialScraper
{
    public partial class FrmMain : KryptonForm
    {
        private string _url = "https://www.google.com";
        private SocialInfoScraper _scraper = new SocialInfoScraper();
        private List<SocialModel> _rList = new List<SocialModel>();
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        public FrmMain()
        {
            InitializeComponent();
            this.BindComBox();
            BindDomain();
        }
        private void BindDomain()
        {
        
        }
        private void BindComBox()
        {
            var list = new List<SocialItem>
            {
                new SocialItem{  Name="LinkedIn", Site="www.LinkedIn.com"},
                new SocialItem{  Name="Facebook", Site="www.facebook.com"},
                new SocialItem{  Name="Instagram", Site="www.instagram.com"},
                new SocialItem{  Name="Youtube", Site="www.youtube.com"},
                new SocialItem{  Name="Pinterest", Site="www.pinterest.com"},
                new SocialItem{  Name="Twitter", Site="www.twitter.com"},

            };
            this.comBoxType.DataSource = list;
            this.comBoxType.DisplayMember = "Name";
            this.comBoxType.ValueMember = "Site";
            this.comBoxType.SelectedIndex = 0;

        }
        private void AddRow(List<SocialModel> list)
        {
            this._rList.AddRange(list);
            foreach (var item in list)
            {
                this.Invoke(new Action(() =>
                {
                    this.dgvList.Rows.Insert(0, new object[]
                    {
                       null,
                       item.Name,
                       item.Tel,
                       item.Email,
                       item.Position,
                       item.Company,
                       item.Address,
                       item.HomePage,
                       item.Description
                    });
                    this.labTotal.Text = this.dgvList.RowCount.ToString();
                }));
            }

        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            var keyword = this.txtKeywrod.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                KryptonMessageBox.Show("Please enter key words！", "Info",
                    MessageBoxButtons.OK, KryptonMessageBoxIcon.WARNING, showCtrlCopy: false);
                return;
            }
            var maxNum = (int)this.numMax.Value;
            var delay = (int)this.nupDelay.Value;
            var social = (SocialItem)this.comBoxType.SelectedItem;


            if (this.btnStart.Text == "Start")
            {
                this.btnStart.Text = "Stop";
                Action<List<SocialModel>> aciton = (list) => this.AddRow(list);
                var token = new CancellationToken();
                token = this._tokenSource.Token;
                Task.Factory.StartNew(() =>
                {
                    this._scraper.ExtractAll(social.Site, aciton, token);


                }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default)
                    .ContinueWith(t =>
                   {
                       
                   });
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.btnStart.Text = "Stopping";
                }));
                this._tokenSource.Cancel();
                this._tokenSource = new CancellationTokenSource();

            }



        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
           

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCz2Ti8uKwv0Fh5j5IgUTPww");
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
        }
 
       
    }
}
