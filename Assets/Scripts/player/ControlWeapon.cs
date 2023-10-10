using UnityEngine;

public class ControlWeapon : MonoBehaviour
{
    int speed = 300;
    [SerializeField] protected Transform weapon;

    void Update()
    {
        if (!JoyStick.Instance.isMoveByJoystick) return;
        
        Vector3 playerPos = JoyStick.Instance.joystickVecMove;
        var difference = playerPos - (Vector3)JoyStick.Instance.joystickVecDf;
        var rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        var rotation = Quaternion.Euler(0, 0, rotationZ + 90f);
        weapon.rotation = rotation;
    }
}