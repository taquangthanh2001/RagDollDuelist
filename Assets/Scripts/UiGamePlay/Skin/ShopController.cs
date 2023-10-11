using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using SO;
using UnityEngine;
using UnityEngine.Serialization;

namespace UiGamePlay.Skin
{
    public class ShopController : MonoBehaviour, IEnhancedScrollerDelegate
    {
        [SerializeField] protected EnhancedScroller enhancedScroller;
        [SerializeField] protected ShopCellView cellView;

        [SerializeField] protected SkinPlayerSo skinPlayerSo;

        protected List<ShopData> datas = new();

        // Start is called before the first frame update
        void Start()
        {
            enhancedScroller.Delegate = this;
            LoadData();
        }

        private void LoadData()
        {
            var data = skinPlayerSo.GetAllData();
            datas.Add(new ShopData { id = 0 });
            foreach (var i in data)
            {
                datas.Add(new ShopData { id = i.id });
            }

            enhancedScroller.ReloadData();
        }

        public int GetNumberOfCells(EnhancedScroller scroller)
        {
            return datas.Count;
        }

        public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
        {
            return 100f;;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int dataIndex, int cellIndex)
        {
            var shopCellView = scroller.GetCellView(cellView) as ShopCellView;
            var data = skinPlayerSo.GetSkinById(datas[dataIndex].id);
            if (shopCellView != null)
                shopCellView.SetData(data);
            return shopCellView;
        }
    }
}