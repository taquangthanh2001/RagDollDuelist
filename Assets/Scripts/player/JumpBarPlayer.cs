using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public sealed class JumpBarPlayer : MonoBehaviour
    {
        [SerializeField] private Transform hip;
        [SerializeField] private Animator fill;
        private RectTransform _rectTransform;
        protected float timeCd = 2f;
        internal bool isJump = false;

        private static JumpBarPlayer _instance;

        public static JumpBarPlayer Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        private void Start()
        {
            if (_instance == null)
            {
                _instance = this;
            }

            gameObject.SetActive(false);
            _rectTransform = transform.GetComponent<RectTransform>();
        }

        private void Update()
        {
            // if (JoyStick.Instance.isMoveByJoystick)
            // {
            //     _rectTransform.position = Camera.main.WorldToScreenPoint(hip.position + (Vector3.right * 3));
            // }
            timeCd -= Time.deltaTime;
            if (!(timeCd < 0)) return;
            isJump = true;
            SetStatusActiveJumpBar(false);
        }

        internal void SetStatusActiveJumpBar(bool isActive)
        {
            gameObject.SetActive(isActive);
            if (true)
                timeCd = 2f;
            else
                isJump = false;
        }
    }
}