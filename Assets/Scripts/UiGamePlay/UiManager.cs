using UnityEngine;
using UnityEngine.UI;

namespace Resources.Scripts.UiGamePlay
{
    public class ActionButton : MonoBehaviour
    {
        [SerializeField] private Button btnSkinButton;
        GameObject _go;

        private void Start()
        {
            btnSkinButton.onClick.AddListener(OnClickSkinBtn);
        }

        private void OnClickSkinBtn()
        {
            _go = UnityEngine.Resources.Load("MyPrefab") as GameObject;
            Instantiate(_go, transform.position + Vector3.up, Quaternion.identity);
        }
    }
}