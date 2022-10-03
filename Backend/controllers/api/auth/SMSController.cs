using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Data;
using Newtonsoft.Json;
using System.Text.Json;
namespace ProjectD_ChengetaWildlife.controllers {

    
    [ApiController]
    public class SMSService : ControllerBase
    {

        
        [Route("api/sms/send")]
        [HttpPost]
         public void SendSMS()
        {
            string message = HttpContext.Request.Form["message"];
            Database db = new();
            string accountSid = Environment.GetEnvironmentVariable("AC6c92e0d7f8b568c6f45d51c56aaf6df9");
            string authToken = Environment.GetEnvironmentVariable("b0b7ebac2bddc9f6fb19a9ed5780e7a8");

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "New event occured!",
                from: new Twilio.Types.PhoneNumber("+19706506540"),
                
                try
                {
                    DataTable notif = db.BuildQuery($"select * from admins WHERE notifSMS = true").Select();
                    foreach (DataRow row in notif.Rows){
                        to: new Twilio.Types.PhoneNumber(row["PhoneNumber"].ToString())
                        //smtp.Send(msg);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
                finally
                {
                    db.Dispose();
                }
                
        );
        				
				}	

        Console.WriteLine(message.Sid);
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
		public void Update() { 
			string Email = HttpContext.Request.Form["Email"];

            Database db = new Database();

            db.BuildQuery("UPDATE admins SET notif = true WHERE email = @Email").AddParameter("email", Email).Select();
            db.BuildQuery("UPDATE admins SET notifSMS = true WHERE email = @Email").AddParameter("email", Email).Select();

	
			db.Close();        
		}
///////////////////////////////////////////////////////////////////////////////////////////////
		[Route("api/mail/del")]
        [HttpPost]
		public void Del() { 
			
			string Email = HttpContext.Request.Form["Email"];

            Database db = new Database();

            db.BuildQuery("UPDATE admins SET notif = false WHERE email = @Email").AddParameter("email", Email).Select();
            db.BuildQuery("UPDATE admins SET notifSMS = false WHERE email = @Email").AddParameter("email", Email).Select();

	
			db.Close();        
		}

         
         [Route("api/mail/return")]
         [HttpGet]
        public string Get()
        {   
            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT email FROM admins WHERE notif = true").Select();
            DataTable data = database.BuildQuery($"SELECT email FROM admins WHERE notifSMS = true").Select();              
            database.Close();
            return JsonConvert.SerializeObject(data);
        }  

    }
}