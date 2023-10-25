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

        public string TextGeneretor(string PlayerName, string CityName, string NumberOfPlayers, string Code ,string lan)
        {
            string BaseTxt;

            switch (lan)
            {
                case "it": //Temporary italian
                  return  BaseTxt = $"Ciao " + PlayerName + " \r\n" +
                      "Gli ultimi due Step prima di giocare all'Escape Game attraverso: " + CityName + "." +
                      "\r\n\r\nScarica L'app di SATO CODE dallo store." +
                      "\r\nInserisci il seguente Ticket Code nella App: " + Code + "\v" +
                      "Il codice è valito per " + NumberOfPlayers + " giocatori" +
                      "\r\n\r\nBuono a sapersi:" +
                      "\r\nÈ un gioco di squadra,minimo 2 persone per squadra" +
                      "\r\nPuoi giocare sempre 24/7\r\n" +
                      "Il ticket è valido un anno" +
                      "\r\n\r\nSe hai altre domande:" +
                      "\r\nHow to start: https://www.sato-code.com/en/how-to-start" +
                      "\r\nSato Code FAQ: https://www.sato-code.com/en/faq\r\n";
                  
                case "de": //to change in german
                   return BaseTxt = $"Hello " + PlayerName + " \r\n" +
                      "Just two steps to start playing the Escape Game across " + CityName + "." +
                      "\r\n\r\nDownload the SATO CODE App from the Store." +
                      "\r\nEnter this ticket Code in the App: " + Code + "\v" +
                      "The code is valid for " + NumberOfPlayers + " People" +
                      "\r\n\r\nGood to know:" +
                      "\r\nIt's a multiplayer Game, at least two phones" +
                      "\r\nYou can play anytime 24/7\r\nThe tickets are one year valid" +
                      "\r\n\r\nIf you have more questions, have a look here:" +
                      "\r\nHow to start: https://www.sato-code.com/en/how-to-start" +
                      "\r\nSato Code FAQ: https://www.sato-code.com/en/faq\r\n";
              
                default :
                  return  BaseTxt = $"Hello " + PlayerName + " \r\n" +
                     "Just two steps to start playing the Escape Game across " + CityName + "." +
                     "\r\n\r\nDownload the SATO CODE App from the Store." +
                     "\r\nEnter this ticket Code in the App: " + Code + "\v" +
                     "The code is valid for " + NumberOfPlayers + " People" +
                     "\r\n\r\nGood to know:" +
                     "\r\nIt's a multiplayer Game, at least two phones" +
                     "\r\nYou can play anytime 24/7\r\nThe tickets are one year valid" +
                     "\r\n\r\nIf you have more questions, have a look here:" +
                     "\r\nHow to start: https://www.sato-code.com/en/how-to-start" +
                     "\r\nSato Code FAQ: https://www.sato-code.com/en/faq\r\n";
            }
          

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