using UnityEngine;

public class ControlWeaponEnemy : MonoBehaviour
{
    int speed = 300;
    [SerializeField] protected Transform weapon;
    [SerializeField] protected Transform hipEnemy;

    void Update()
    {
        Vector3 playerPos = PlayerMovement.Instance.GetPlayerPos();
        var difference = playerPos - hipEnemy.transform.position;
        var rotationZ = Mathf.Atan2(difference.x, -difference.y) * Mathf.Rad2Deg;
        var rotation = Quaternion.Euler(0, 0, rotationZ + 90f);
        weapon.rotation = rotation;
    }
}