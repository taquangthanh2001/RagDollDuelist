using EnhancedUI.EnhancedScroller;
using SO;
using Image = UnityEngine.UI.Image;

namespace UiGamePlay.Skin
{
    public class ShopCellView : EnhancedScrollerCellView
    {
        private Image _bgImg;
        private SkinPlayerSo.SkinData _data;

        public void SetData(SkinPlayerSo.SkinData skinPlayerSo)
        {
            _data = skinPlayerSo;

            _bgImg = GetComponent<Image>();
            _bgImg.sprite = _data.bgSkin;
        }
    }
}