//多语言管理类
//by hdp 2024.12.22
using MultiLanguage.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
using Newtonsoft.Json.Linq;

namespace MultiLanguage
{
    public partial class LanguageManager
    {
        public LanguageManager()
        {
            Init();
        }

        #region property
        private static LanguageManager _instance = new LanguageManager();
        //实例
        public static LanguageManager Instance => _instance;

        #region language index
        //当前语言索引
        private int _currentLanguageIndex = 0;
        //当前语言
        public string CurrentLanguage
        {
            get => _translateData.Types[_currentLanguageIndex].Value;
            set
            {
                int index = Array.FindIndex(_translateData.Types, x => x.Value == value);
                if (index >= 0)
                    _currentLanguageIndex = index;
            }
        }
        public TranslateTypeData[] TranslateTypes => _translateData.Types;
        #endregion
        //标记是否正在切换语言
        private bool _isChangingLanguage = false;
        public bool IsChangingLanguage => _isChangingLanguage;
        //管理不需要翻译的控件
        public ExcludeManager Exlude = new ExcludeManager();
        #endregion

        #region field
        //翻译数据
        private TranslateData _translateData;
        //翻译字典
        private Dictionary<string, string[]> TranslateDict => _translateData.Data;
        //<hash, texts> 初始的文本数据
        private Dictionary<int, string[]> _sourceDict = new Dictionary<int, string[]>();
        //控件操作
        private ControlOperationManager _oper => new ControlOperationManager(this);
        #endregion

        #region public function
        //翻译文本
        public string TranslateText(string text)
        {
            if (!string.IsNullOrEmpty(text) && TranslateDict.TryGetValue(text, out string[] texts))
            {
                if (texts != null && texts.Length > _currentLanguageIndex && !string.IsNullOrWhiteSpace(texts[_currentLanguageIndex]))
                    return texts[_currentLanguageIndex];
            }

            return text;
        }
        #endregion

        #region private function
        private void Init()
        {
            LoadTranslateData();
        }
        #endregion

        #region translate data. 翻译数据的读取/保存
        private string TranslateFileName => Path.Combine(Application.StartupPath, "Translate.json");
        private void LoadTranslateData()
        {
            try
            {
                string text = File.ReadAllText(TranslateFileName);
                _translateData = JsonConvert.DeserializeObject<TranslateData>(text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void SaveTranslateData()
        {
            try
            {
                string text = JsonConvert.SerializeObject(_translateData, Formatting.Indented);
                File.WriteAllText(TranslateFileName, text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region collect text. 收集需要翻译的信息
        public void CollectText(Control value)
        {
            if (!Exlude.IsValid(value))
                return;
            
            CollectTextControl(value);

            if (value is ToolStrip)
                return;
            foreach (Control item in value.Controls)
            {
                CollectText(item);
            }
        }
        private void CollectTextControl(Control value)
        {
            if (value is ToolStrip)
            {
                _oper.ToolStrip.CollectText((ToolStrip)value);
            }
            else if (value is ComboBox)
            {
                _oper.ComboBox.CollectText((ComboBox)value);
            }
            else
            {
                FillTranslateDict(value.Text);
            }
        }

        internal void FillTranslateDict(params string[] texts)
        {
            foreach (string text in texts)
            {
                if (string.IsNullOrWhiteSpace(text) || TranslateDict.ContainsKey(text))
                    continue;

                TranslateDict[text] = null;
            }
        }
        #endregion

        #region  init language 获取所有控件的初始文本
        public void InitLanguage(Control value)
        {
            if (!Exlude.IsValid(value))
                return;

            InitLanguageControl(value);

            if (value is ToolStrip)
                return;
            foreach (Control item in value.Controls)
            {
                InitLanguage(item);
            }
        }
        private void InitLanguageControl(Control value)
        {
            if (value is ToolStrip)
            {
                _oper.ToolStrip.InitLanguage((ToolStrip)value);
            }
            else if (value is ComboBox)
            {
                _oper.ComboBox.InitLanguage((ComboBox)value);
            }
            else
            {
                FillSourceDict(value.GetHashCode(), value.Text);
            }
        }
        internal void FillSourceDict(int hash, params string[] texts)
        {
            if (Array.Exists(texts, text => !string.IsNullOrWhiteSpace(text)))
            {
                _sourceDict[hash] = texts;
            }
        }
        #endregion

        #region change language 切换语言
        public void ChangeLanguage(Control value, bool needChangeSign)
        {
            if (needChangeSign)
                _isChangingLanguage = true;

            ChangeLanguage(value);

            if (needChangeSign)
                _isChangingLanguage = false;
        }

        internal void ChangeLanguage(Control value)
        {
            if (!Exlude.IsValid(value))
                return;

            ChangeLanguageControl(value);

            if (value is ToolStrip)
                return;
            foreach (Control item in value.Controls)
            {
                ChangeLanguage(item);
            }
        }
        private void ChangeLanguageControl(Control value)
        {
            if (value is ToolStrip)
            {
                _oper.ToolStrip.ChangeLanguage((ToolStrip)value);
            }
            else if (value is ComboBox)
            {
                _oper.ComboBox.ChangeLanguage((ComboBox)value);
            }
            else
            {
                if (GetSourceText(value.GetHashCode(), out string[] texts))
                    value.Text = TranslateText(texts[0]);
            }
        }
        internal bool GetSourceText(int hash, out string[] texts)
        {
            return _sourceDict.TryGetValue(hash, out texts);
        }
        #endregion
    }

}
