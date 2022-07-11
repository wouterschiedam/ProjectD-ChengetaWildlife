using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Data;
using Newtonsoft.Json;
namespace ProjectD_ChengetaWildlife.controllers {

    
    [ApiController]
    public class MailService : ControllerBase
    {

        
        [Route("api/mail/send")]
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

        [Route("api/mail/add")]
        [HttpPut]
		public string Add(string mail) { //void maken na test
			
            Database db = new Database();
				
			if(mail != null)
			{
				DataTable data1 = db.BuildQuery("select * FROM admins WHERE email = @email").Select();
				foreach (DataRow row in data1.Rows){
					row["notif"] = true;
				}					
			}
            DataTable data = db.BuildQuery($"SELECT email FROM admins WHERE notif = true").Select();		
			db.Close();
            return JsonConvert.SerializeObject(data);         
		}

		[Route("api/mail/del")]
        [HttpPut]
		public string Del(string mail) { //void maken na test
			
            Database db = new Database();
				
			if(mail != null)
			{
				DataTable data1 = db.BuildQuery("select * FROM admins WHERE email = @mail").Select();
				foreach (DataRow row in data1.Rows){
					row["notif"] = false;
				}					
			}				
			db.Close();
            DataTable data = db.BuildQuery($"SELECT email FROM admins WHERE notif = false").Select();
            return JsonConvert.SerializeObject(data);         
		}

         
         [Route("api/mail/return")]
         [HttpGet]
        public string Get()
        {   
            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT email FROM admins WHERE notif = true").Select();              
            database.Close();
            return JsonConvert.SerializeObject(data);
        }
    }
}