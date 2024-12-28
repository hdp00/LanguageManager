using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiLanguage;

namespace Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            cmb_Language.SelectedIndex = 0;
        }

        #region field
        private LanguageManager _language = LanguageManager.Instance;
        #endregion

        #region event
        private void btn_CollectText_Click(object sender, EventArgs e)
        {
            _language.CollectText(this);
            _language.SaveTranslateData();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            _language.InitLanguage(this);
        }
        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            _language.CurrentLanguage = cmb_Language.SelectedIndex == 0 ? "zh-CN" : "en-US";
            _language.ChangeLanguage(this);
        }
        #endregion


    }
}
