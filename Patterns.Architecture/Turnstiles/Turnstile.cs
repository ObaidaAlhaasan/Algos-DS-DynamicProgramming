namespace Patterns.Architecture.Turnstiles
{
    public class Turnstile
    {
        public string AlarmMsg => "Alarm, someone passed turnstile without passing a coin";
        public string ThankYouMsg => "Thank you, you already inserted a coin";

        public void UnlockAction()
        {
            Console.WriteLine("UnlockAction turnstile ...");
        }

        public void LockAction()
        {
            Console.WriteLine("LockAction turnstile ...");
        }

        public string Alarm() => AlarmMsg;
        public string ThankYou() => ThankYouMsg;
    }
}