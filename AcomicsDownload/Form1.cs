using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcomicsDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                var i = 1;
                driver.Navigate().GoToUrl(@$"{textBox1.Text}/{i}");
                var pagesCount = int.Parse(driver
                    .FindElement(By.XPath(@"//*[@id='content']/div[1]/h3/span[2]"))
                    .Text.Split("/")[1]);

                using (WebClient client = new WebClient())
                {
                    while (i <= pagesCount)
                    {
                        driver.Navigate().GoToUrl(@$"{textBox1.Text}/{i}");
                        var url = driver
                            .FindElement(By.XPath(@"//*[@id='mainImage']"))
                            .GetAttribute("src");
                        client
                            .DownloadFile(url, $"{i}.{Path.GetFileName(url).Split(".")[1]}");
                        i++;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0

                while (i++ < 179)
                {
                    Bitmap image = (Bitmap)Bitmap.FromFile(System.IO.Directory.GetCurrentDirectory() + @"\1.jpg");

                    // Sets canvas with new dpi but same dimensions and color depth
                    Bitmap canvas = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);
                    canvas.SetResolution(2480, 3508);

                    // Draw image on canvas through graphics

                    // Saved Image
                    image.Save(System.IO.Directory.GetCurrentDirectory() + "\\{i_forWord}.png");
                }
            }
            catch (Exception ex)
            {

            }
            // Reads Image

        }
    }
}
