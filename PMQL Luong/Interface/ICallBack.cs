using PMQL_Luong.Entities;

namespace PMQL_Luong
{
    public interface ICallBack
    {
        void loginSuccess(User user);
        void formClosing();
    }
}