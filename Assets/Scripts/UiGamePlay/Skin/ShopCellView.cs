using EnhancedUI.EnhancedScroller;
using SO;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

namespace UiGamePlay.Skin
{
    public class ShopCellView : EnhancedScrollerCellView
    {
        [SerializeField] protected SkinPlayerSo skinPlayerSo;
        [SerializeField] protected WeaponSo weaponSo;

        [SerializeField] protected Sprite randomSpr;
        private Image _bgImg;

        private void SetImageSprite(Sprite sprite)
        {
            _bgImg = GetComponent<Image>();
            if (sprite == null)
            {
                _bgImg.sprite = randomSpr;
            }
            else
            {
                _bgImg.sprite = sprite;
            }
        }

        public void SetData(ShopData dataInShop, bool isSwitch)
        {
            if (isSwitch)
            {
                var _data = skinPlayerSo.GetSkinById(dataInShop.id);
                SetImageSprite(_data.bgSkin);
            }
            else
            {
                var _data = weaponSo.GetWeaponById(dataInShop.id);
                SetImageSprite(_data.bgWeapon);
            }
        }
    }
}