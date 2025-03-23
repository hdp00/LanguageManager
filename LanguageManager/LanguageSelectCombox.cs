using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLanguage
{
    internal class LanguageSelectCombox
    {
        public LanguageSelectCombox(LanguageManager language, Form main, ComboBox comboBox)
        {
            InitLanguageSelectComboBox(language, main, comboBox);
        }

        private void InitLanguageSelectComboBox(LanguageManager language, Form main, ComboBox comboBox)
        {
            ComboBox c = comboBox;

            c.DataSource = language.TranslateTypes;
            c.DisplayMember = "Text";
            c.ValueMember = "Value";
            c.SelectedIndex = 0;
            c.SelectedValueChanged += (sender, e) => 
            {
                if (language.IsChangingLanguage)
                    return;

                language.CurrentLanguage = comboBox.SelectedItem.ToString();
                language.ChangeLanguage(main);
            };
        }
    }
}