using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
            cmb_Language.SelectedIndex = 0;
        }
        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_language.IsChangingLanguage)
                return;

            _language.CurrentLanguage = cmb_Language.SelectedIndex == 0 ? "zh-CN" : "en-US";
            _language.ChangeLanguage(this);
        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //comboBox1.Items.AddRange(new object[] { "a", "b" });
            Test(1, 2);
            Test(new int[] { 1, 2 });
            Test();
        }

        private void Test(params int[] values)
        {
            int i = 5;
        }

    }
}
