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
    public partial class MainForm : Form, ILanguageForm
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
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitLanguage();
        }
        private void btn_NewForm_Click(object sender, EventArgs e)
        {
            DynamicForm f = new DynamicForm();
            f.ShowDialog();
        }
        #endregion

        #region init
        private void InitLanguage()
        {
            InitExcludeControl();
            _language.InitLanguageSelectComboBox(this, cmb_Language.ComboBox);

            //_language.CollectText(this);
            //_language.SaveTranslateData();

            _language.InitLanguage(this);
            _language.ChangeLanguage(this);
        }
        private void InitExcludeControl()
        {
            _language.Exclude.ExcludeClass.TextBox = true;
            _language.Exclude.AddExcludeName("cmb_Language", "group_Exclude");
        }
        #endregion

        #region ILanguageForm
        public void ChangeLanguage()
        {
            lable_Additional.Text = _language.TranslateText("页面A");
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
