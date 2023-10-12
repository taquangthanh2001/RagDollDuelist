using System;
using SO;
using UnityEngine;

namespace Utils
{
    public class LoadDataSo : MonoBehaviour
    {
        [SerializeField] private SkinPlayerSo _skinPlayerSo;
        [SerializeField] private WeaponSo _weapon;

        public static LoadDataSo Instance { get; set; }

        private void Reset()
        {
            LoadDataSkinPlayer();
        }

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        private void LoadDataSkinPlayer()
        {
            _skinPlayerSo = Resources.Load(GameConst.SkinPlayerSO) as SkinPlayerSo;
            _weapon = Resources.Load(GameConst.WeaponSo) as WeaponSo;
        }

        public SkinPlayerSo GetSkinPlayer()
        {
            if (_skinPlayerSo == null)
            {
                Debug.Log("SkinPlayerSo In LoadDataSO missing");
            }
            return _skinPlayerSo;
        }

        public WeaponSo GetWeaponSo()
        {
            if (_weapon == null)
            {
                Debug.Log("WeaponSo In LoadDataSO missing");
            }
            return _weapon;
        }
    }
}