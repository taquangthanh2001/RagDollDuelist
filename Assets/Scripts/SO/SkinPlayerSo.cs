using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace SO
{
    [CreateAssetMenu(menuName = "SODataPlayer/SkinPlayerData", fileName = "SkinPlayerData", order = 0)]
    public class SkinPlayerSo : ScriptableObject
    {
        public List<SkinData> skinDatas = new();

        [Serializable]
        public struct SkinData
        {
            public int id;
            public Sprite bgSkin;
            public Sprite bgHead;
            public Sprite bgBody;
            public Sprite bgHip;
            public Sprite bgAsm1;
            public Sprite bgAsm2;
            public Sprite bgLeg1;
            public Sprite bgLeg2;
        }

        public List<SkinData> GetAllData()
        {
            return skinDatas;
        }

        public SkinData GetSkinById(int id)
        {
            return skinDatas.FirstOrDefault(x => x.id == id);
        }
    }
}