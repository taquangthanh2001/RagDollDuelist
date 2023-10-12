using Data;
using Enemy;
using Newtonsoft.Json;
using Player;
using UnityEngine;

namespace Utils
{
    public static class Commons
    {
        public static void SetSatus(bool isActive)
        {
            HpPlayer.Instance.SetStatusActiveHpBar(isActive);
            HpEnemy.Instance.SetStatusActiveHpBar(isActive);
        }

        public static void SetUserData(UserData userData)
        {
            SessionPref.SetUserData(userData);
            PlayerPrefs.SetString(GameConst.UserData, JsonConvert.SerializeObject(userData));
        }

        public static UserData GetUserData()
        {
            return SessionPref.GetUserData()
                   ?? JsonConvert.DeserializeObject<UserData>(PlayerPrefs.GetString(GameConst.UserData));
        }
    }
}