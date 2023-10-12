using UnityEngine;
using UnityEngine.UI;
using Utils;

public class HpBase : MonoBehaviour
{
    [SerializeField] protected Transform hip;
    protected RectTransform rectTransform;
    protected Slider slider;
    protected const float hpMax = 100f;
    protected float currentHp = 100f;

    private bool _isLostHp = false;

    protected virtual void Start()
    {
        gameObject.SetActive(false);
        rectTransform = transform.GetComponent<RectTransform>();
        slider = transform.GetComponent<Slider>();
    }

   protected virtual void Update()
    {
        if (JoyStick.Instance.isMoveByJoystick)
        {
            rectTransform.position = Camera.main.WorldToScreenPoint(hip.position + (Vector3.up * 5));
        }
    }

    internal virtual void HpBar(float hpLost)
    {
        if (StatusInGame.Status == StatusGame.Pause) return;
        currentHp = _isLostHp ? currentHp -= hpLost : hpMax - hpLost;
        _isLostHp = true;
        var value = currentHp / 100;
        slider.value = value;
    }

    internal void SetStatusActiveHpBar(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}