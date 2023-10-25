using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace SmsSender
{
    public class EmailToSms
    {
        private SmtpClient _smtpClient;
        private string Sclick = "@sms.clicksend.com";
      
        

        public EmailToSms() 
        {
        
            _smtpClient = new SmtpClient("asmtp.mail.hostpoint.ch")
            {
                Port = 587,
                Credentials = new NetworkCredential("em","pw"),
                EnableSsl = true,
            };
      
        }



        public bool EmailSender(string PlayerNumber, string Message)
        {

            var mailMessage = new MailMessage
            {
                From = new MailAddress("alfredtest@sato-code.com"),
                Subject = "Sato Code Ticket",
                Body = Message

            };

            PlayerNumber = Regex.Replace(PlayerNumber, "[^0-9+]", "");
            if (prefixChecker(PlayerNumber))
            {
                string finalEmail = PlayerNumber + Sclick;
                mailMessage.To.Add(finalEmail);
                _smtpClient.Send(mailMessage);
               return true;
            }
            else return false;
            
        }

        public string TextGeneretor(string PlayerName, string CityName, string NumberOfPlayers, string Code)
        {
            string BaseTxt =
                  $"Hello "+ PlayerName+" \r\n" +
                   "Just two steps to start playing the Escape Game across "+ CityName +"." +
                   "\r\n\r\nDownload the SATO CODE App from the Store." +
                   "\r\nEnter this ticket Code in the App: " + Code +"\v" +
                   "The code is valid for " +NumberOfPlayers+" People" +
                   "\r\n\r\nGood to know:" +
                   "\r\nIt's a multiplayer Game, at least two phones" +
                   "\r\nYou can play anytime 24/7\r\nThe tickets are one year valid" +
                   "\r\n\r\nIf you have more questions, have a look here:" +
                   "\r\nHow to start: https://www.sato-code.com/en/how-to-start" +
                   "\r\nSato Code FAQ: https://www.sato-code.com/en/faq\r\n";

            return BaseTxt;

        }

        public bool prefixChecker(string PlayerNumber)
        {
            if(PlayerNumber.StartsWith("+") || PlayerNumber.StartsWith("00"))
            { 
                return true;

            }
            else  return false; 
        }

    }
}