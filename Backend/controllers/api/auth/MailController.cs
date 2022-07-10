using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
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
            Database db = new();
            string email = "go73191@outlook.com";
            string password = "welkom123!?";

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("noreply", email));



            
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

                DataTable notif = db.BuildQuery("select * from admins WHERE notif = true").Select();
				foreach (DataRow row in notif.Rows){
					msg.To.Add(MailboxAddress.Parse(row["email"].ToString()));
                    smtp.Send(msg);
				}					
                
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

        [Route("api/mail/add/{mail}")]
		public int Add(string mail) {
			// Get a value called email & password from the Request 

            Database db = new Database();
			//Query to check if the logged in user is authorithized to create new accounts			
			if(mail != null)
			{
				DataTable data1 = db.BuildQuery("select * from admins WHERE email = @mail").Select();
				foreach (DataRow row in data1.Rows){
					row["notif"] = true;
				}					
			}
				
			db.Close();
            return 1;
		}

		[Route("api/mail/del/{mail}")]
		public int Del(string mail) {
			// Get a value called email & password from the Request 

            Database db = new Database();
			//Query to check if the logged in user is authorithized to create new accounts			
			if(mail != null)
			{
				DataTable data1 = db.BuildQuery("select * from admins WHERE email = @mail").Select();
				foreach (DataRow row in data1.Rows){
					row["notif"] = false;
				}					
			}				
			db.Close();
            return 1;
		}
    }
}