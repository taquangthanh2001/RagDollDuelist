using UnityEngine;

namespace Base
{
    public class Weapon : MonoBehaviour
    {
        protected float dameByWeapon = 5f;

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
        
        }
    }
}