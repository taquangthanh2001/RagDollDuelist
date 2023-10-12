using Base;
using Enemy;
using UnityEngine;

namespace Player
{
    public class WeaponPlayer : Base.Weapon
    {
        // protected override void OnCollisionEnter2D(Collision2D other)
        // {
        //     if (other.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;
        //     HpEnemy.Instance.SetStatusActiveHpBar(true);
        //     HpEnemy.Instance.HpBar(dameByWeapon);
        // }
    }
}