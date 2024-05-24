using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialScraper
{
    public partial class FrmAbout : KryptonForm
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3GLmU7C");
        }

        private void kryptonLinkLabel5_LinkClicked(object sender, EventArgs e)
        {
       
            Process.Start("https://bit.ly/3AgdLkV");
        }

        private void kryptonLinkLabel6_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3fFxFMz");
        }

        private void kryptonLinkLabel7_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3Afgjjc");
        }

        private void kryptonLinkLabel8_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3FJnXU7");
        }

        private void kryptonLinkLabel9_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3InAD4G");
        }

        private void kryptonLinkLabel10_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3fE14qG");
        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://t.me/captainC999");
        }

        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCz2Ti8uKwv0Fh5j5IgUTPww");
        }

        private void kryptonLinkLabel3_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://bit.ly/3FQu35b");
        }
    }
}
