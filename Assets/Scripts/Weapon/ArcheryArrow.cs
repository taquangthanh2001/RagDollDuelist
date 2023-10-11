using System;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon
{
    public class ArcheryArrow : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] protected GameObject arrowObj;
        [SerializeField] protected Button btnShoot;


        [SerializeField] protected Transform posBottom;
        [SerializeField] protected Transform posHead;
        
        public float launchSpeed = 10f; 
        private void Start()
        {
            btnShoot.onClick.AddListener(OnClickShootArrow);
        }

        private void OnClickShootArrow()
        {
            var obj = Instantiate(arrowObj,posBottom);
            obj.transform.SetParent(null);
            var direction = (posHead.position - posBottom.position).normalized;
            obj.GetComponent<Rigidbody2D>().velocity = direction * launchSpeed;
            // _rb = obj.GetComponent<Rigidbody2D>();
            // var difference = (posHead.position - posBottom.position).normalized;
            // _rb.AddForce(difference * (100f * Time.deltaTime));
        }
    }
}