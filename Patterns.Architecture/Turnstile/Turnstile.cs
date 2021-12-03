namespace Patterns.Architecture.Turnstile
{
    public class Turnstile
    {
        public string Alarm => "Alarm, someone passed turnstile without passing a coin";
        public string ThankYou => "Thank you, you already inserted a coin";

        public void UnlockAction()
        {
            Console.WriteLine("UnlockAction turnstile ...");
        }

        public void LockAction()
        {
            Console.WriteLine("LockAction turnstile ...");
        }
    }
}