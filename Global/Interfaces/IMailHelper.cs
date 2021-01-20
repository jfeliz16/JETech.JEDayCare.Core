namespace JETech.JEDayCare.Core.Global.Interfaces
{
    public interface IMailHelper
    {
        void SendMail(string to, string subject, string body);
    }
}