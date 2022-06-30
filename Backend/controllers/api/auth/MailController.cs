using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ProjectD_ChengetaWildlife.controllers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ProjectD_ChengetaWildlife.controllers {

    [Route("api/mail/send")]
    [ApiController]
    public class MailService : ControllerBase
    {

        [HttpPost]
         public void SendEmail(string message)
        {
            string email = "go73191@outlook.com";
            string password = "welkom123!?";

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("noreply", email));
            msg.To.Add(MailboxAddress.Parse("arjan_t@live.nl"));
            msg.Subject = "New event occured";
            msg.Body = new TextPart("plain")
            {
                Text = $"{message}"
            };

            SmtpClient smtp = new SmtpClient();

            try
            {

                smtp.Connect("smtp-mail.outlook.com", 587, false);
                smtp.Authenticate(email, password);
                smtp.Send(msg);
                Console.WriteLine("lol");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                smtp.Disconnect(true);
                smtp.Dispose();
            }
        }
    }
}