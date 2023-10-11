using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SODataWeapon/WeaponSo", fileName = "WeaponSo", order = 0)]
    public class WeaponSo : ScriptableObject
    {
        public List<WeaponData> weaponDatas = new();

        [Serializable]
        public struct WeaponData
        {
            public int id;
            public Sprite bgWeapon;
        }

        public List<WeaponData> GetAllData()
        {
            return weaponDatas;
        }

        public WeaponData GetWeaponById(int id)
        {
            return weaponDatas.FirstOrDefault(x => x.id == id);
        }
    }
}
