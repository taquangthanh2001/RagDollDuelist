using System;
using EnhancedUI.EnhancedScroller;
using Player;
using SO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Utils;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

namespace UiGamePlay.Skin
{
    public class ShopCellView : EnhancedScrollerCellView
    {
        // [SerializeField] protected SkinPlayerSo skinPlayerSo;
        // [SerializeField] protected WeaponSo weaponSo;

        [SerializeField] protected Button btnCellView;
        [SerializeField] protected Sprite randomSpr;
        private Image _bgImg;

        private UserData _userData;

        private int _idCellView;
        private bool _isSkin;

        private void Start()
        {
            _userData = Commons.GetUserData();
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
                var _data = LoadDataSo.Instance.GetSkinPlayer().GetSkinById(_idCellView);
                SetImageSprite(_data.bgSkin);
            }
            else
            {
                var _data = LoadDataSo.Instance.GetWeaponSo().GetWeaponById(_idCellView);
                SetImageSprite(_data.bgWeapon);
            }
        }

        private void OnClickBtnCellView(int id)
        {
            if (_isSkin)
            {
                LoadUiPlayer.Instance.LoadDisplayPlayer(id);
            }
            else
            {
                var idWeapon = id;
                if (idWeapon == 0)
                {
                    idWeapon = Random.Range(1, LoadDataSo.Instance.GetWeaponSo().GetAllData().Count + 1);
                }

                _userData.IdWeapon = idWeapon;
                ControlWeapon.Instance.LoadWeapon(LoadDataSo.Instance.GetWeaponSo().GetWeaponById(idWeapon).nameWeapon);
            }

            Commons.SetUserData(_userData);
        }
    }
}