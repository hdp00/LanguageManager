//此文件实现对于不同控件的处理
//by hdp 2024.12.26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLanguage
{
    public partial class LanguageManager
    {
        private void CollectObjectText(object obj)
        {
            if (obj is Control)
            {
                FillTranslateDict((obj as Control).Text);
            }
        }
        private void InitObjectLanguage(object obj)
        {
            int hash = obj.GetHashCode();

            if (obj is Control)
            {
                FillSourceDict(hash, new string[] { (obj as Control).Text });
            }
        }
        private void ChangeObjectLanguage(object obj)
        {
            if (obj is ComboBox)
            {
                //ComboBox c = obj as ComboBox;
                //if (_sourceDict.TryGetValue(c.GetHashCode(), out string[] texts))
                //{
                //    c.Items.Clear();
                //    c.Items.AddRange(TranslateText(texts[0]).Split(','));
                //}
            }
            else if (obj is Control)
            {
                Control c = obj as Control;
                if (_sourceDict.TryGetValue(c.GetHashCode(), out string[] texts))
                    c.Text = TranslateText(texts[0]);
            }
        }
    }
}
