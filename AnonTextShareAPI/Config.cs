using AnonTextShareStorage;

namespace AnonTextShareAPI
{
    internal static class Config
    {
        internal static DatabaseConnection db = new SimpleDB();
        internal static AppConfig conf = new AppConfig();
    }
}
