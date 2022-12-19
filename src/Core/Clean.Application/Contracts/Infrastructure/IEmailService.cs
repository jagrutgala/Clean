using Clean.Application.Models.Mail;
using System.Threading.Tasks;

namespace Clean.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
