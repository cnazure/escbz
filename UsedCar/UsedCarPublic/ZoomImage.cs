using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace UsedCarPublic
{
    public class ZoomImage
    {


        public Image ResourceImage;
        public string ErrorMessage;

        public bool ThumbnailCallback()
        {
            return false;
        }
        /// <summary>
        /// 按大小缩放图片
        /// </summary>
        /// <param name="Width">缩放到的宽</param>
        /// <param name="Height">缩放到的高</param>
        /// <param name="targetFilePath">图片的名字</param>
        /// <returns>bool</returns>
        public bool ReducedImage(int Width, int Height, string targetFilePath)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);
                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);
                ReducedImage.Dispose();
                return true;
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return false;
            }
        }




        public void PicSized(string strOldPic, string strNewPic)
        {
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(strOldPic);

            System.Drawing.Imaging.ImageCodecInfo encoder = GetEncoderInfo("image/jpeg");
            if (encoder != null)
            {
                //有我们需要的编码器

                //EncoderParameters 是封装 EncoderParameter 对象的数组。 
                //构造函数中参数值 1 表示 EncoderParameters 含有一个EncoderParameter
                System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters(1);

                //System.Drawing.Imaging.Encoder 对象封装一个全局唯一标识符 (GUID)，它标识图像编码器参数的类别。
                //设置 jpeg 质量为 60，注意应该为 long 类型
                encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)10);

                //使用指定编码器按指定参数保存图片
                img.Save(strNewPic, encoder, encoderParams);

                encoderParams.Dispose();
            }
            img.Dispose();
        }
        //根据 mime 类型，返回编码器
        private System.Drawing.Imaging.ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            System.Drawing.Imaging.ImageCodecInfo result = null;

            //检索已安装的图像编码解码器的相关信息。
            System.Drawing.Imaging.ImageCodecInfo[] encoders =
                System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < encoders.Length; i++)
            {
                if (encoders[i].MimeType == mimeType)
                {
                    result = encoders[i];
                    break;
                }
            }
            return result;
        }
    }
}
