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
            Init();
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
            _language.ChangeLanguage(this, true);
        }

        #endregion

        #region init
        private void Init()
        {
            InitExcludeControl();
            InitLanguageSelectCombo();
        }
        private void InitExcludeControl()
        {
            _language.Exlude.AddExcludeName("cmb_Language", "group_Exclude");
        }
        private void InitLanguageSelectCombo()
        {
            ComboBox c = cmb_Language.ComboBox;
            
            c.DataSource = _language.TranslateTypes;
            c.DisplayMember = "Text";
            c.ValueMember = "Value";
            c.SelectedIndex = 0;
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Test(params int[] values)
        {
        }

    }
}
