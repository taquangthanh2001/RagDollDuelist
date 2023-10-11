using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using SO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UiGamePlay.Skin
{
    public class ShopController : MonoBehaviour, IEnhancedScrollerDelegate
    {
        [SerializeField] protected EnhancedScroller enhancedScroller;
        [SerializeField] protected ShopCellView cellView;
        [SerializeField] protected Button btnClose;
        [SerializeField] protected SkinPlayerSo skinPlayerSo;
        [SerializeField] protected WeaponSo weaponSo;

        [SerializeField] protected Button btnWeapon;
        [SerializeField] protected Button btnChar;

        protected bool isSwitchData = false;

        protected List<ShopData> datas = new();

        // Start is called before the first frame update
        void Start()
        {
            btnClose.onClick.AddListener(OnClickClose);
            btnWeapon.onClick.AddListener(OnClickSwitch);
            btnChar.onClick.AddListener(OnClickSwitch);
            enhancedScroller.Delegate = this;
            LoadData();
        }

        private void LoadData()
        {
            datas = new List<ShopData>();
            if (isSwitchData)
            {
                var data = skinPlayerSo.GetAllData();
                datas.Add(new ShopData { id = 0 });
                foreach (var i in data)
                {
                    datas.Add(new ShopData { id = i.id });
                }
            }
            else
            {
                var data = weaponSo.GetAllData();
                datas.Add(new ShopData { id = 0 });
                foreach (var i in data)
                {
                    datas.Add(new ShopData { id = i.id });
                }
            }

            enhancedScroller.ReloadData();
        }

        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return datas.Count;
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 200f;
            ;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var shopCellView = scroller.GetCellView(cellView) as ShopCellView;

            if (shopCellView == null) return shopCellView;
            if (isSwitchData)
            {
                shopCellView.SetData(datas[dataIndex], isSwitchData);
            }
            else
            {
                shopCellView.SetData(datas[dataIndex], isSwitchData);
            }
            return shopCellView;
        }

        private void OnClickClose()
        {
            Destroy(gameObject);
        }

        private void OnClickSwitch()
        {
            isSwitchData = !isSwitchData;
            LoadData();
        }
    }
}