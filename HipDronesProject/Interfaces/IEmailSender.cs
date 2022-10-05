using System.Threading.Tasks;

namespace HipDronesProject.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
