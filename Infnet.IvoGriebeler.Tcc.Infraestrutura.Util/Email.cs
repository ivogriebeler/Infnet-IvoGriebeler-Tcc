using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.IvoGriebeler.Tcc.Infraestrutura.Util
{
    public static class Email
    {
        public static RetornoEmail Enviar(string emailDestino, string assuntoEmail, string corpoEmail)
        {
            var userName = "ivogriebeler.infnet@gmail.com";
            var senha = "qweQwe123@#$";

            // Link para habilitar no Gmail
            // https://www.google.com/settings/security/lesssecureapps

            try
            {
                using (SmtpClient cliente = new SmtpClient())
                {
                    cliente.Host = "smtp.gmail.com";
                    cliente.EnableSsl = true;
                    cliente.Port = 587; // se não der, testar 465
                    cliente.UseDefaultCredentials = false;
                    cliente.Credentials = new NetworkCredential(userName, senha);

                    using (MailMessage mensagem = new MailMessage())
                    {
                        mensagem.From = new MailAddress(userName, "Definir");
                        mensagem.To.Add(emailDestino);
                        mensagem.Subject = assuntoEmail;
                        mensagem.Body = corpoEmail;
                        mensagem.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                        mensagem.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                        cliente.Send(mensagem);
                    }
                }
            }
            catch (Exception ex)
            {
                return new RetornoEmail(ex);
            }

            return new RetornoEmail();
        }
    }

    public class RetornoEmail
    {
        public bool Sucesso { get; private set; }

        public Exception Excecao { get; private set; }

        public RetornoEmail()
        {
            Sucesso = true;
        }

        public RetornoEmail(Exception excpetion)
        {
            Sucesso = false;
            Excecao = excpetion;
        }
    }
}
