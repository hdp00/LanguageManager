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
        #region collect text

        #endregion

        #region init language
        private void InitObjectLanguage(object obj)
        {
            int hash = obj.GetHashCode();

            if (obj is ToolStrip)
            {
                foreach (ToolStripItem item in (obj as ToolStrip).Items)
                {
                    InitToolStripItemLanguage(item);
                }
            }
            else if (obj is ComboBox)
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
        private void InitToolStripItemLanguage(ToolStripItem item)
        {
            if (item is ToolStripControlHost)
            {
                InitObjectLanguage((item as ToolStripControlHost).Control);
            }
            else
            {
                FillSourceDict(item.GetHashCode(), item.Text, item.ToolTipText);

                if (item is ToolStripDropDownItem)
                {
                    foreach (ToolStripItem i in (item as ToolStripDropDownItem).DropDownItems)
                        InitToolStripItemLanguage(i);
                }
            }
        }
        #endregion

        #region change language
        private void ChangeObjectLanguage(object obj)
        {
            int hash = obj.GetHashCode();

            if (obj is ToolStrip)
            {
                foreach (ToolStripItem item in (obj as ToolStrip).Items)
                {
                    ChangeToolStripItemLanguage(item);
                }
            }
            else if (obj is ComboBox)
            {
                //combox修改Items时，会触发SelectedIndexChanged事件，导致多次调用ChangeObjectLanguage
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
        private void ChangeToolStripItemLanguage(ToolStripItem item)
        {
            if (item is ToolStripControlHost)
            {
                ChangeObjectLanguage((item as ToolStripControlHost).Control);
            }
            else
            {
                if (_sourceDict.TryGetValue(item.GetHashCode(), out string[] texts))
                { 
                    item.Text = TranslateText(texts[0]);
                    item.ToolTipText = TranslateText(texts[1]);
                }

                if (item is ToolStripDropDownItem)
                {
                    foreach (ToolStripItem i in (item as ToolStripDropDownItem).DropDownItems)
                        ChangeToolStripItemLanguage(i);
                }
            }
        }
        #endregion
    }
}
