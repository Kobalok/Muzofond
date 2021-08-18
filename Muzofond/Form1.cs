using System;
using System.Net;
using System.Collections.Specialized;
using System.Windows.Forms;
using CsQuery;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Muzofond
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new();
            string HTML=wc.DownloadString("https://mp3-fm.site/music/%D0%BF%D0%BE%D1%88%D0%BB%D0%B0%20%D0%B6%D0%B0%D1%80%D0%B0");
                                   
            List<string> Title = new();
            string href; 

            CQ cq = CQ.Create(HTML);
            foreach ( IDomElement obj in cq["div.chkd"].Find("h2").Find("b"))
            {
                Title.Add(obj.InnerText);



                  //  hrefTags.Add(obj.GetAttribute("href"));
                
            }
            foreach (IDomElement obj in cq["a.link"])
            { int i = 0;


                href=@"http://320kbps.ru"+obj.GetAttribute("href");
                try
                {
                    wc.DownloadFile(href, "1.mp3");
                }
                catch (Exception ex)
                {
                    
                }

            }

            }
    }
}
