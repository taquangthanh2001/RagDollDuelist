using Base;
using Player;
using UnityEngine;

namespace Enemy
{
    public class WeaponEnemy : Weapon
    {
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            HpPlayer.Instance.SetStatusActiveHpBar(true);
            HpPlayer.Instance.HpBar(dameByWeapon);
        }
    }
}