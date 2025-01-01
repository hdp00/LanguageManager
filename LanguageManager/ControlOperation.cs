﻿//控件操作类
//by hdp 2025.01.01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLanguage
{
    #region basic

    public class ControlOperationManager
    {
        public ControlOperationManager(LanguageManager container)
        {
            _container = container;
        }

        #region property
        public ToolStripOperation ToolStrip => new ToolStripOperation(_container);
        public ComboBoxOperation ComboBox => new ComboBoxOperation(_container);
        #endregion

        #region field
        private readonly LanguageManager _container;
        #endregion
    }
    public class ControlOperation
    {
        public ControlOperation(LanguageManager container)
        {
            Container = container;
        }

        public readonly LanguageManager Container;
    }
    #endregion

    #region control
    public class ToolStripOperation : ControlOperation
    {
        public ToolStripOperation(LanguageManager container) : base(container) { }

        #region collect text
        public void CollectText(ToolStrip value)
        {
            foreach (ToolStripItem item in value.Items)
            {
                CollectTextToolStripItem(item);
            }
        }
        private void CollectTextToolStripItem(ToolStripItem value)
        {
            Container.FillTranslateDict(value.Text, value.ToolTipText);

            if (value is ToolStripDropDownItem)
            {
                foreach (ToolStripItem item in (value as ToolStripDropDownItem).DropDownItems)
                    CollectTextToolStripItem(item);
            }
        }
        #endregion

        #region init language
        public void InitLanguage(ToolStrip value)
        {
            foreach (ToolStripItem item in value.Items)
            {
                InitLanguageToolStripItem(item);
            }
        }
        private void InitLanguageToolStripItem(ToolStripItem value)
        {
            Container.FillSourceDict(value.GetHashCode(), value.Text, value.ToolTipText);

            if (value is ToolStripDropDownItem)
            {
                foreach (ToolStripItem item in (value as ToolStripDropDownItem).DropDownItems)
                    InitLanguageToolStripItem(item);
            }
        }
        #endregion

        #region change language
        public void ChangeLanguage(ToolStrip value)
        {
            foreach (ToolStripItem item in value.Items)
            {
                ChangeLanguageToolStripItem(item);
            }
        }
        private void ChangeLanguageToolStripItem(ToolStripItem valule)
        {
            if (Container.GetSourceText(valule.GetHashCode(), out string[] texts))
            {
                valule.Text = Container.TranslateText(texts[0]);
                valule.ToolTipText = Container.TranslateText(texts[1]);
            }

            if (valule is ToolStripDropDownItem)
            {
                foreach (ToolStripItem item in (valule as ToolStripDropDownItem).DropDownItems)
                    ChangeLanguageToolStripItem(item);
            }
        }
        #endregion
    }
    public class ComboBoxOperation : ControlOperation
    {
        public ComboBoxOperation(LanguageManager container) : base(container) { }

        public void CollectText(ComboBox value)
        {
            foreach (object item in value.Items)
            {
                if (item is string)
                    Container.FillTranslateDict(item.ToString());
            }
        }
        public void InitLanguage(ComboBox value)
        {
            List<string> texts = new List<string>();
            foreach (object item in value.Items)
            {
                if (item is string)
                    texts.Add(item.ToString());
                else
                    texts.Add(null);
            }

            if (texts.Exists(t => !string.IsNullOrEmpty(t)))
                Container.FillSourceDict(value.GetHashCode(), texts.ToArray());
        }
        public void ChangeLanguage(ComboBox value)
        {
            //combox修改Items时，会触发SelectedIndexChanged事件
            if (Container.GetSourceText(value.GetHashCode(), out string[] texts))
            {
                int count = Math.Min(value.Items.Count, texts.Length);
                for (int i = 0; i < count; i++)
                {
                    if (value.Items[i] is string)
                        value.Items[i] = Container.TranslateText(texts[i]);
                }
            }
        }
    }
    #endregion
}