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
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitLanguage();
        }
        private void cmb_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_language.IsChangingLanguage)
                return;

            _language.CurrentLanguage = cmb_Language.SelectedItem.ToString();
            _language.ChangeLanguage(this);
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
            InitLanguageSelectComboBox();

            //_language.CollectText(this);
            //_language.SaveTranslateData();

            _language.InitLanguage(this);
            cmb_Language_SelectedIndexChanged(null, null);
        }
        private void InitExcludeControl()
        {
            _language.Exclude.ExcludeClass.TextBox = true;
            _language.Exclude.AddExcludeName("cmb_Language", "group_Exclude");
        }
        private void InitLanguageSelectComboBox()
        {
            ComboBox c = cmb_Language.ComboBox;
            
            c.DataSource = _language.TranslateTypes;
            c.DisplayMember = "Text";
            c.ValueMember = "Value";
            c.SelectedIndex = 0;
            c.SelectedValueChanged += cmb_Language_SelectedIndexChanged;
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
