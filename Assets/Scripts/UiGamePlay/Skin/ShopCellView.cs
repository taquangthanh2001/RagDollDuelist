using System;
using EnhancedUI.EnhancedScroller;
using Player;
using SO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

namespace UiGamePlay.Skin
{
    public class ShopCellView : EnhancedScrollerCellView
    {
        [SerializeField] protected SkinPlayerSo skinPlayerSo;
        [SerializeField] protected WeaponSo weaponSo;

        [SerializeField] protected Button btnCellView;
        [SerializeField] protected Sprite randomSpr;
        private Image _bgImg;

        private int _idCellView;
        private bool _isSkin;

        private void Start()
        {
            btnCellView.onClick.AddListener(() => { OnClickBtnCellView(_idCellView); });
        }

        private void SetImageSprite(Sprite sprite)
        {
            _bgImg = GetComponent<Image>();
            _bgImg.sprite = sprite == null ? randomSpr : sprite;
        }

        public void SetData(ShopData dataInShop, bool isSwitch)
        {
            _idCellView = dataInShop.id;
            _isSkin = isSwitch;
            if (_isSkin)
            {
                var _data = skinPlayerSo.GetSkinById(_idCellView);
                SetImageSprite(_data.bgSkin);
            }
            else
            {
                var _data = weaponSo.GetWeaponById(_idCellView);
                SetImageSprite(_data.bgWeapon);
            }
        }
        private void OnClickBtnCellView(int id)
        {
            if (_isSkin)
                LoadUiPlayer.Instance.LoadDisplayPlayer(id);
            else
            {
                var idWeapon = id;
                if (idWeapon == 0)
                {
                    idWeapon = Random.Range(1,weaponSo.GetAllData().Count +1);
                }
                ControlWeapon.Instance.LoadWeapon(weaponSo.GetWeaponById(idWeapon).nameWeapon);
            }
        }
    }
}