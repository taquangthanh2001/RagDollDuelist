using Utils;

namespace Data
{
    public static class SessionPref
    {
        private static UserData _userData;
    
        public static UserData GetUserData()
        {
            return _userData;
        }

        public static void SetUserData(UserData userData)
        {
            _userData = userData;
        }
    }
}
