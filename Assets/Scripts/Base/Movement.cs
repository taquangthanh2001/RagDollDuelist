using UnityEngine;

namespace Base
{
    public class Movement : MonoBehaviour
    {
        // Start is called before the first frame update
        protected virtual void Start()
        {
        
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            MoveByTarget();
        }

        protected virtual void MoveByTarget()
        {
            Jump();
        }
        protected virtual void Jump()
        {
        
        }
    }
}
