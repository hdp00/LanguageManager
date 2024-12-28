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
            if (obj is ComboBox)
            {
                foreach (object item in (obj as ComboBox).Items)
                { 
                    if (item is string)
                        FillTranslateDict(item.ToString());
                }
            }
            else if (obj is Control)
            {
                FillTranslateDict((obj as Control).Text);
            }
        }
        private void InitObjectLanguage(object obj)
        {
            int hash = obj.GetHashCode();

            if (obj is ComboBox)
            {
                ComboBox c = obj as ComboBox;
                List<string> texts = new List<string>();
                foreach (object item in c.Items)
                {
                    if (item is string)
                        texts.Add(item.ToString());
                    else
                        texts.Add(null);
                }

                if (texts.Exists(t => !string.IsNullOrEmpty(t)))
                    FillSourceDict(hash, texts.ToArray());
            }
            else if (obj is Control)
            {
                FillSourceDict(hash, new string[] { (obj as Control).Text });
            }
        }
        private void ChangeObjectLanguage(object obj)
        {
            int hash = obj.GetHashCode();
            
            if (obj is ComboBox)
            {
                ComboBox c = obj as ComboBox;
                if (_sourceDict.TryGetValue(hash, out string[] texts))
                {
                    int count = Math.Min(c.Items.Count, texts.Length);
                    for (int i = 0; i < count; i++)
                    {
                        if (c.Items[i] is string)
                            c.Items[i] = TranslateText(texts[i]);
                    }
                }
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
