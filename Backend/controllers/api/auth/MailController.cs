using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;
namespace ProjectD_ChengetaWildlife.controllers {

    
    [ApiController]
    public class MailService : ControllerBase
    {

        
        [Route("api/mail/send/")]
        [HttpPost]
         public void SendEmail()
        {
            string message = HttpContext.Request.Form["message"];
             var queryVar = ""; 
            Console.WriteLine(message);
            Database db = new();
            string email = "go73191@outlook.com";
            string password = "welkom123!?";

            var msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("noreply", email));

            string str = message.Substring(0,5).ToLower();
            if (str != "last"){
               msg.Subject = "New event occured!";
               queryVar = "notif";                
            } 
            else{
                msg.Subject = "Weekly report!";
                queryVar = "superuser"; 
            } 

            msg.Body = new TextPart("plain")
            {
                Text = $"{message}"
            };

            SmtpClient smtp = new SmtpClient();

            try
            {
                smtp.Connect("smtp-mail.outlook.com", 587, false);
                smtp.Authenticate(email, password);

                DataTable notif = db.BuildQuery($"select * from admins WHERE {queryVar} = true").Select();
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
/////////////////////////////////////////////////////////////////////////////////////////////
        [Route("api/mail/update")]
        [HttpPost]
		public void Update() { //void maken na test
			string Email = HttpContext.Request.Form["Email"];

            Database db = new Database();

            db.BuildQuery("UPDATE admins SET notif = true WHERE email = @Email").AddParameter("email", Email).Select();

	
			db.Close();        
		}
/////////////////////////////////////////////////////////////////////////////////////////////
		[Route("api/mail/del")]
        [HttpPost]
		public void Del() { //void maken na test
			
			string Email = HttpContext.Request.Form["Email"];

            Database db = new Database();

            db.BuildQuery("UPDATE admins SET notif = false WHERE email = @Email").AddParameter("email", Email).Select();

	
			db.Close();        
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