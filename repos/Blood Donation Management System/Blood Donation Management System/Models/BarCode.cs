using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Blood_Donation_Management_System.Models
{
    public class BarCode
    {
        public string Generator(string id)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (Bitmap bitMap = new Bitmap(id.Length * 40, 80))
                {
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                        SolidBrush blackBrush = new SolidBrush(Color.DarkBlue);
                        graphics.DrawString("*" + id + "*", oFont, blackBrush, point);
                    }

                    bitMap.Save(memoryStream, ImageFormat.Jpeg);

                    return  "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    //BarcodeImage =
                }
            }
            //return "";
        }
    }
}