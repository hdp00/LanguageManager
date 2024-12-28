//翻译数据定义
//by hdp 2024.12.25
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLanguage.Data
{
    public class TranslateData
    {
        //语言类型
        public string[] Types { get; set; }
        //翻译数据
        public Dictionary<string, string[]> Data { get; set; }
    }

}

