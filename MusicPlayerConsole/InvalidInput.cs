namespace MusicPlayerConsole
{
    public class InvalidInput : Exception
    {


        public override string Message => "Invalid Input!";

        public InvalidInput(string message)
        : base(message) { }

        public InvalidInput(string message, Exception inner)
        : base(message, inner) { }

    }
}
