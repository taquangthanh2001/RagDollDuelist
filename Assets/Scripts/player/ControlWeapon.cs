using System;
using UnityEngine;

namespace Player
{
    public class ControlWeapon : MonoBehaviour
    {
        [SerializeField] protected Transform weapon;

        [SerializeField] protected Transform posTarget, posStart;

        private Vector3 _playerPos = Vector3.zero;
        private Vector3 _direction = Vector3.zero;


        public static ControlWeapon Instance { get; protected set; }

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        void Update()
        {
            if (!JoyStick.Instance.isMoveByJoystick)
            {
                _playerPos = posTarget.position;
                _direction = _playerPos - posStart.position;
                RotaionWeaponByDir(_direction);
                return;
            }
            _playerPos = JoyStick.Instance.joystickVecMove;
            _direction = _playerPos - (Vector3)JoyStick.Instance.joystickVecDf;
            RotaionWeaponByDir(_direction);
        }

        private void RotaionWeaponByDir(Vector3 direction)
        {
            var rotationZ = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(0, 0, rotationZ + 90f);
            weapon.rotation = rotation;
        }
        public void LoadWeapon(string nameWeapon)
        {
            for (var i = 0; i < weapon.childCount; i++)
            {
                weapon.GetChild(i).gameObject.SetActive(weapon.GetChild(i).name == nameWeapon);
            }
        }
    }
}