using System;
using UnityEngine;

namespace Player
{
    public sealed class JumpBarPlayer : MonoBehaviour
    {
        public enum StatusJump
        {
            ToJump,
            Jumping,
            Cancel,
        }

        [SerializeField] private Transform hip;
        [SerializeField] private Animator fill;
        private RectTransform _rectTransform;
        private float _timeCd = 2f;

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
            if (JoyStick.Instance.isMoveByJoystick)
            {
                _rectTransform.position = Camera.main.WorldToScreenPoint(hip.position + (Vector3.right * 3));
            }
            else
            {
                gameObject.SetActive(false);
            }

            _timeCd -= Time.deltaTime;
            if (!(_timeCd < 0)) return;
            SetStatusActiveJumpBar(StatusJump.Jumping);
        }

        internal void SetStatusActiveJumpBar(StatusJump statusJump)
        {
            gameObject.SetActive(true);
            switch (statusJump)
            {
                case StatusJump.ToJump:
                    fill.Play("JumpBar");
                    _timeCd = 2f;
                    PlayerMovement.Instance.isJumpBar = false;
                    break;
                case StatusJump.Jumping:
                    PlayerMovement.Instance.Jumping();
                    PlayerMovement.Instance.timeCdJump = 2f;
                    gameObject.SetActive(false);
                    break;
                case StatusJump.Cancel:
                    PlayerMovement.Instance.isJumpBar = true;
                    gameObject.SetActive(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statusJump), statusJump, null);
            }
        }
    }
}