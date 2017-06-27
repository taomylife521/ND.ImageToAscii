using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//**********************************************************************
//
// 文件名称(File Name)：ImageOptions.CS        
// 功能描述(Description)：     
// 作者(Author)：Aministrator               
// 日期(Create Date)： 2017-06-26 15:20:52         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2017-06-26 15:20:52          
//             修改理由：         
//**********************************************************************
namespace ND.ImageToAsciiTxt
{
    public class ImageOptions
    {
        private Image _imageInstance;
        private bool _isUseAsscii = true;
        public Image ImageInstance { get { return _imageInstance; } set { _imageInstance = value; } }

        /// <summary>
        /// Image路径
        /// </summary>
        public string ImageFilePath { get; set; }


        /// <summary>
        /// 是否用Ascii生成
        /// </summary>
        public bool IsUseAsscii {
            get { return _isUseAsscii; }
            set { _isUseAsscii = value; }
        }

        /// <summary>
        /// 是否用Ascii生成
        /// </summary>
        public bool IsGenerateGif
        {
            get { return _isUseAsscii; }
            set { _isUseAsscii = value; }
        }
    }
}
