using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploPublishWindowsFormFTPSmarter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendEmail(textBox_Destinatario.Text.Trim(), "PRUEBA SEND MAIL", memoEdit_Mensaje.Text.Trim());
        }

        public void SendEmail(string address, string subject, string Mensaje)
        {
            try
            {

           
            string email = "elierickdevelopment@gmail.com";
            string password = "gnyfkdxufcmkufep";

            var loginInfo = new System.Net.NetworkCredential(email, password);
            var msg = new System.Net.Mail.MailMessage();
            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

            msg.From = new System.Net.Mail.MailAddress(email);
            msg.To.Add(new System.Net.Mail.MailAddress(address));
            msg.Subject = subject;
            msg.Body = Mensaje;
            msg.IsBodyHtml = true;

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

            MessageBox.Show("El email se envió correctamente.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString().Trim());
                return;
            }
        }
    }
}
