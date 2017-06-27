using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//**********************************************************************
//
// 文件名称(File Name)：ImageController.CS        
// 功能描述(Description)：     
// 作者(Author)：Aministrator               
// 日期(Create Date)： 2017-06-26 15:19:27         
//
// 修改记录(Revision History)： 
//       R1:
//             修改作者:          
//             修改日期:2017-06-26 15:19:27          
//             修改理由：         
//**********************************************************************
namespace ND.ImageToAsciiTxt
{
    public class ImageController
    {
        private static ImageOptions _option;
        public ImageController(ImageOptions option)
        {
            _option = option;
        }

        public void ProcessImage(Action<Image> action,Action<string> action2)
        {
           // LoadAndResize();//载入并修改大小
            if (_option.IsUseAsscii)
            {
                //用ascii码生成
                string asciiStr = GenerateAscii2(action, action2);
               // action(asciiStr);
            }
            else
            {
                
                //生成html图片
            }
            //_option.ImageInstance.PixelFormat;
        }

        #region 载入图片并更新大小
        //public void LoadAndResize()
        //{
        //    int srcWidth = 0, srcHeight = 0, newWidth = 0, newHeight = 0;

        //    if (_option.AspectRatio <= 0)
        //    {
        //        _option.AspectRatio = 1;
        //    }
        //    if (_option.MaxLength > 0 || _option.AspectRatio != 1.0)
        //    {
        //        srcWidth = _option.ImageInstance.Width;
        //        srcHeight = _option.ImageInstance.Height;
        //        newWidth = srcWidth;
        //        newHeight = srcHeight;
        //        if (_option.AspectRatio != 1)
        //        {
        //            newHeight = int.Parse((_option.AspectRatio * newHeight).ToString());
        //        }
        //    }
        //    if (_option.MaxLength > 0)
        //    {
        //        float rate = _option.MaxLength / Math.Max(newWidth, newHeight);
        //        newWidth = int.Parse((rate * newWidth).ToString());
        //        newHeight = int.Parse((rate * newHeight).ToString());
        //    }
        //    if (srcWidth != newWidth || srcHeight != newHeight)
        //    {
        //        //内存中更新大小并重新赋值
        //        Size s = new Size(newWidth, newHeight);
        //        Bitmap newBit = new Bitmap(_option.ImageInstance, s);
        //        Stream stream = new MemoryStream();
        //        newBit.Save(stream, null, null);
        //        _option.ImageInstance = Image.FromStream(stream);
        //    }
           
        //} 
        #endregion

      


        #region 生成Asccii码字符串

        public string GenerateAscii2(Action<Image> action,Action<string> action2)
        {
            Bitmap image = new Bitmap(_option.ImageInstance);

            int[,] GrayImage = new int[image.Width, image.Height];
            #region 1.计算灰度值
            for (int x = 0; x < image.Width; x++)
            {

                for (int y = 0; y < image.Height; y++)
                {
                    try
                    {
                        Color pixelColor = image.GetPixel(x, y);

                        GrayImage[x, y] = (int)(pixelColor.R * 0.2126 + pixelColor.G * 0.7152 + pixelColor.B * 0.0722);//计算灰度值 
                        byte rgb = (byte)((pixelColor.R + pixelColor.G + pixelColor.B) / 3);
                        //image.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));//把图片变成黑白
                    }
                    catch (Exception e)
                    {
                    }

                }
            }
            //Stream stream = new MemoryStream();
           // image.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
           // image=;
            action(image);
            #endregion
            #region 2.用指定的字符替换
            string strRes = "";
            for (int i = 0; i < image.Height; i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < image.Width; j++)
                {
                    int grayVal = GrayImage[j, i];
                    str.Append(GetPixelValue(grayVal));
                }
                strRes = strRes + str + "\r\n";
                str.Clear();
            } 
            #endregion
           // File.WriteAllText("e://1.txt", strRes);
            action2(strRes);//渲染
          
            return "";
        }
        #endregion

        #region GetPixelValue
        private char GetPixelValue(int rgb)
        {
            if (rgb >= 0 && rgb < 50)
                return '.';
            else if (rgb >= 50 && rgb < 100)
                return 'M';
            else if (rgb >= 100 && rgb < 150)
                return '-';
            else if (rgb >= 150 && rgb < 180)
                return '#';
            else if (rgb >= 180 && rgb < 200)
                return 'O';
            else // (rgb >= 200 && rgb <= 255)
                return '@';
        }
        #endregion

       
    }
}
