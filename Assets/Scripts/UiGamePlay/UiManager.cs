using Base;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UiGamePlay
{
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private Button btnSkinButton;

        private void Start()
        {
            btnSkinButton.onClick.AddListener(OnClickSkinBtn);
        }

        private void OnClickSkinBtn()
        {
            UiBase.Instance.ShowPrefab(GameConst.SkinPlayer);
        }
    }
}