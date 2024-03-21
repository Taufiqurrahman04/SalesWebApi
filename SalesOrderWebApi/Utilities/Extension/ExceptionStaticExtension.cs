namespace Utilities.Extension
{
    public static class ExceptionStaticExtension
    {
        public static string GetaAllMessages(this Exception exception)
        {
            var messages = new List<string>();
            do
            {
                messages.Add(exception.Message);
                exception = exception.InnerException;
            }
            while (exception != null);

            var message = string.Join(Environment.NewLine, messages);

            return message;
        }
    }

}
