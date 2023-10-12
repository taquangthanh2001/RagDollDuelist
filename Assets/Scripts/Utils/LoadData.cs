using UnityEngine;
using Utils;

public class LoadData : MonoBehaviour
{
    private UserData _userData;

    private void Start()
    {
        if (PlayerPrefs.HasKey(GameConst.UserData)) return;
        var dataUser = new UserData()
        {
            IdSkin = 1,
            IdWeapon = 1
        };
        Commons.SetUserData(dataUser);
    }
}
