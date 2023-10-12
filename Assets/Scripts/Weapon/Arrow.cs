using UnityEngine;

namespace Weapon
{
    public class Arrow : Base.Weapon
    {
        private Rigidbody2D _rb;
        Vector3 fwd;
        public float power = 1500f;
        public float moveSpeed = 2f;

        protected bool isCheckCollision = true;

        // Start is called before the first frame update
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (!isCheckCollision) return;
            isCheckCollision = false;
            base.OnCollisionEnter2D(other);
        }

        // Update is called once per frame
        void Update()
        {
            // var velocity = _rb.velocity;
            // var angle = Mathf.Atan2(velocity.y,
            //     velocity.x) * Mathf.Rad2Deg;
            // // transform.rotation = Quaternion.Euler(0f, 0f, angle);
            // // transform.eulerAngles = new Vector3(0f, 0f, angle);
        }
    }
}