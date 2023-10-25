namespace SmsSender
{
    public class SmsConfigurator
    {
        static void Main(string[] args)
        {
            var MyMain = new EmailToSms();

           if( MyMain.EmailSender("+393245888274", MyMain.TextGeneretor("davide", "como", "3", "ASJVR")))
            {
                Console.WriteLine("truw");
            }
            else { Console.WriteLine("false"); }
        

        }
    }
}
