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
        //当前语言索引
        private int _currentLanguageIndex = 0;
        //当前语言
        public string CurrentLanguage
        {
            get => _translateData.Types[_currentLanguageIndex];
            set
            {
                int index = Array.IndexOf(_translateData.Types, value);
                if (index >= 0)
                    _currentLanguageIndex = index;
            }
        }
        //是否正在切换语言
        private bool _isChangingLanguage = false;
        public bool IsChangingLanguage => _isChangingLanguage;
        #endregion

        #region field
        //翻译数据
        private TranslateData _translateData;
        //翻译字典
        private Dictionary<string, string[]> TranslateDict => _translateData.Data;
        //<hash, texts> 初始的文本数据
        private Dictionary<int, string[]> _sourceDict = new Dictionary<int, string[]>();
        //是否已经初始化
        private bool _hasInited = false;
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
        public void CollectText(Control control)
        {
            CollectObjectText(control);

            foreach (Control item in control.Controls)
            {
                if (item is Control)
                    CollectText(item as Control);
                else
                    CollectObjectText(item);
            }
        }
        private void FillTranslateDict(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || TranslateDict.ContainsKey(text))
                return;

            TranslateDict[text] = null;
        }
        #endregion

        #region  init language 获取所有控件的初始文本
        public void InitLanguage(Control control)
        {
            _hasInited = true;

            InitObjectLanguage(control);

            foreach (object item in control.Controls)
            {
                if (item is Control)
                    InitLanguage(item as Control);
                else
                    InitObjectLanguage(item);
            }
        }
        private void FillSourceDict(int hash, params string[] texts)
        {
            if (Array.Exists(texts, text => !string.IsNullOrWhiteSpace(text)))
            {
                _sourceDict[hash] = texts;
            }
        }
        #endregion

        #region change language 切换语言
        public void ChangeLanguage(Control control)
        {
            if (!_hasInited)
                return;
            _isChangingLanguage = true;

            ChangeObjectLanguage(control);

            foreach (object item in control.Controls)
            {
                if (item is Control)
                    ChangeLanguage(item as Control);
                else
                    ChangeObjectLanguage(item);
            }

            _isChangingLanguage = false;
        }
        #endregion






    }
}
