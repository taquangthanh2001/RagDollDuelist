using System;
using SO;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Player
{
    public class LoadUiPlayer : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer imgFace;
        [SerializeField] protected SpriteRenderer imgBody;
        [SerializeField] protected SpriteRenderer imgHip;
        [SerializeField] protected SpriteRenderer imgHandR1;
        [SerializeField] protected SpriteRenderer imgHandR2;
        [SerializeField] protected SpriteRenderer imgHandL1;
        [SerializeField] protected SpriteRenderer imgHandL2;
        [SerializeField] protected SpriteRenderer imgLegR1;
        [SerializeField] protected SpriteRenderer imgLegR2;
        [SerializeField] protected SpriteRenderer imgLegL1;
        [SerializeField] protected SpriteRenderer imgLegL2;


        [SerializeField] private SkinPlayerSo _skinPlayerSo;

        private static LoadUiPlayer _instance;

        public static LoadUiPlayer Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        private void Start()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void LoadDisplayPlayer(int idSkin)
        {
            var id = idSkin;
            if (id == 0)
            {
                id = Random.Range(1,_skinPlayerSo.GetAllData().Count +1);
            }
            var _data = _skinPlayerSo.GetSkinById(id);
            imgFace.sprite = _data.bgHead;
            imgBody.sprite = _data.bgBody;
            imgHip.sprite = _data.bgHip;
            imgHandR1.sprite = imgHandL1.sprite = _data.bgAsm1;
            imgHandR2.sprite = imgHandL2.sprite = _data.bgAsm2;
            imgLegR1.sprite = imgLegL1.sprite = _data.bgLeg1;
            imgLegR2.sprite = imgLegL2.sprite = _data.bgLeg2;
        }
    }
}