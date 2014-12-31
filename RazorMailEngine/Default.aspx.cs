using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RazorMailEngine
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string template = File.ReadAllText(Server.MapPath("template.html"));
            var model = new List<csData>(){
            new csData(){Ad="Mahmut", OkulAdi="Okul A"},
            new csData(){Ad="Ender", OkulAdi="Okul B"},
            new csData(){Ad="Fatih", OkulAdi="Okul C"},
            };

            string sonuc = RazorEngine.Razor.Parse(template, model);

            MailMessage mail = new MailMessage("gonderici@gmail", "alici@mail.com");
            mail.Body = sonuc;
            mail.IsBodyHtml = true;
            mail.Subject = "Mail Konusu";
            SmtpClient client = new SmtpClient();
            client.Send(mail);
            this.ltr.Text = "Mail Gönderildi";
        }
    }
    /// <summary>
    /// bu bizim Mail Templateti doldurmak için kullandığımız veya kullanacağımız class i temsil ediyor.
    /// </summary>
    public class csData
    {
        public string Ad { get; set; }
        public string OkulAdi { get; set; }
    }
}