using Enemy;
using UnityEngine;

namespace Base
{
    public class Weapon : MonoBehaviour
    {
        protected float dameByWeapon = 5f;

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Enemy")) return;
            HpEnemy.Instance.SetStatusActiveHpBar(true);
            HpEnemy.Instance.HpBar(dameByWeapon);
        }
    }
}