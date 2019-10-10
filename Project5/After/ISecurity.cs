namespace TestableCodeDemos.Module5.After
{
    public interface ISecurity
    {
        string GetUserName();
        bool IsAdmin();
        void SetUser(string userName, bool isAdmin);
    }
}