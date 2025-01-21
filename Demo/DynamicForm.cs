using MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class DynamicForm : Form
    {
        public DynamicForm()
        {
            InitializeComponent();
        }

        private void DynamicForm_Load(object sender, EventArgs e)
        {
            InitLanguage();
        }

        #region language
        private void InitLanguage()
        {
            var d = LanguageManager.Instance.InitDynamicForm(this);
            d.InitLanguage();
            d.ChangeLanguage();
        }
        #endregion
    }
}
