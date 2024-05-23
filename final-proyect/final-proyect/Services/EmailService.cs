using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using final_proyect.Models;
using final_proyect_backend.Models;
namespace final_proyect.Services
{
    

    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        public async Task SendInitialEmailStudent(string toEmail, string name, int StudentNumber)
        {
            var message = $@"
                Hola {name},<br/><br/>
                Gracias por registrarte en la bolsa de trabajo de la UTN FRRO.<br/><br/>
                Tu cuenta ha sido registrada con el legajo: {StudentNumber} y recibirás las noticias a este email.
                Recuerda que para utilizar esta cuenta primero un administrador debe <b>autorizar tu acceso</b>,
                te avisaremos cuando tu cuenta quede habilitada.<br><br>
                <img src='https://utn.edu.ar/images/logo-utn.png' alt='Logo UTN' style='max-width:400px;' />"; 
            var subject = "Su registro en la bolsa de trabajo.";
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendInitialEmailEnterprise(string toEmail, string name, int cuit)
        {
            var message = $@"
                Hola, responsable de {name},<br/><br/>
                Gracias por registrar tu compañia en la bolsa de trabajo de la UTN FRRO.<br/><br/>
                Tu cuenta ha sido registrada con el CUIT: {cuit}  y podras ingresar con este email.
                Recuerda que para utilizar esta cuenta primero un administrador debe <b>autorizar tu acceso</b>,
                te avisaremos cuando tu cuenta quede habilitada, despues de eso podras completar los datos de tu empresa en la plataforma y realizar las propuestas laborales<br><br>
                <br> Recorda cumplir con nuestra <a>normativa para empresas</a>
                <img src='https://utn.edu.ar/images/logo-utn.png' alt='Logo UTN' style='max-width:400px;' />";
            var subject = "Su registro en la bolsa de trabajo.";
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendInfoComplete(string toEmail, string name)
        {
            var message = $@"
                Hola,  {name},<br/><br/>
                Gracias por completar tu informacion, a partir de ahora podras utilizar tu cuenta!<br/><br/>
                
                <img src='https://utn.edu.ar/images/logo-utn.png' alt='Logo UTN' style='max-width:400px;' />";
            var subject = "Gracias por completar tus datos.";
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }


        public async Task SendCorrectPostulation(string toEmail, string name, string OfferPostuled)
        {
            var message = $@"
                Hola,{name},<br/><br/>
                Te postulaste correctamente a {OfferPostuled}.
                En caso de tener novedades sobre tu postulacion, te enviaremos por aqui.<br/><br/>
                ¡Exitos en tu postulacion!.


                <img src='https://utn.edu.ar/images/logo-utn.png' alt='Logo UTN' style='max-width:400px;' />";
            var subject = "Te has postulado correctamente.";
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        public async Task SendNewsPostulation(string toEmail, string name, string OfferPostuled)
        {
            var message = $@"
                Hola,{name},<br/><br/>
                Hay novedades sobre tu postulacion a: {OfferPostuled}.
                Te recomendamos ingresar a la plataforma para verlas.<br/><br/>
                ¡Saludos!.


                <img src='https://utn.edu.ar/images/logo-utn.png' alt='Logo UTN' style='max-width:400px;' />";
            var subject = "Novedades sobre tu postulacion.";
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendClosedPostulation(string toEmail, string name, string OfferPostuled)
        {
            var message = $@"
                Hola,{name},<br/><br/>
                Te escribimos para informarte que la empresa termino la propuesta: {OfferPostuled}.
                En caso de no ser contactado, te recomendamos ingresar a la plataforma para ver las nuevas ofertas.<br/><br/>
                ¡Animos!.


                <img src='https://utn.edu.ar/images/logo-utn.png' alt='Logo UTN' style='max-width:400px;' />";
            var subject = "Novedades sobre tu postulacion.";
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
            email.To.Add(new MailboxAddress(toEmail, toEmail));
            email.Subject = subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = message };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

    }

}
