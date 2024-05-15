using Core.Models.Identity;

namespace MediTech.Helper
{
    public interface IMailSetting
    {
        public void SendEmail(Email email);
    }
}
