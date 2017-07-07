using Fiver.Azure.Email.Message;
using System.Threading.Tasks;

namespace Fiver.Azure.Email
{
    public interface IAzureEmailSender
    {
        Task<ResponseMessage> SendAsync(EmailMessage message);
    }
}