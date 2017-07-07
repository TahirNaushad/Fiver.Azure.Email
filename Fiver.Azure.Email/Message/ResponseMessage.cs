namespace Fiver.Azure.Email.Message
{
    public class ResponseMessage
    {
        public ResponseMessage(string statusCode)
        {
            this.StatusCode = statusCode;
        }

        public string StatusCode { get; }
    }
}
