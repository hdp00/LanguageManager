﻿//用于翻译动态创建的窗体,使用前记得需要执行InitLanguage
//by hdp 2025.01.17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLanguage
{
    public class DynamicFormManager
    {
        public DynamicFormManager(LanguageManager container, Form form)
        {
            _container = container;
            _form = form;
        }

        #region property
        //管理不需要翻译的控件
        public ExcludeManager Exclude = new ExcludeManager();
        #endregion

        #region field
        private Form _form;
        private LanguageManager _container;
        //<hash, texts> 初始的文本数据
        private Dictionary<int, string[]> _sourceDict = new Dictionary<int, string[]>();
        #endregion

        #region public function
        public void ChangeLanguage()
        {
            _container.CurrentSourceDict = _sourceDict;
            _container.CurrentExclude = Exclude;

            _container.ChangeLanguageFunc(_form);

            _container.CurrentSourceDict = null;
            _container.CurrentExclude = null;
        }
        public void InitLanguage()
        {
            _container.CurrentSourceDict = _sourceDict;
            _container.CurrentExclude = Exclude;

            _container.InitLanguageFunc(_form);

            _container.CurrentSourceDict = null;
            _container.CurrentExclude = null;
        }
        #endregion
    }
}
