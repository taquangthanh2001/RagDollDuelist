using UnityEngine;
using UnityEngine.UI;

public class HpBase : MonoBehaviour
{
    [SerializeField] protected Transform hip;
    protected RectTransform rectTransform;
    protected Slider slider;
    protected const float hpMax = 100;
    protected float currentHp = 0f;

    protected virtual void Start()
    {
        gameObject.SetActive(false);
        rectTransform = transform.GetComponent<RectTransform>();
        slider = transform.GetComponent<Slider>();
    }

    void Update()
    {
        if (JoyStick.Instance.isMoveByJoystick)
        {
            rectTransform.position = Camera.main.WorldToScreenPoint(hip.position + (Vector3.up * 5));
        }
    }

    internal void HpBar(float hpLost)
    {
        if (currentHp < 1f)
            currentHp = hpMax - hpLost;
        else
            currentHp -= hpLost;

        var value = currentHp / 100;
        slider.value = value;
    }

    internal void SetStatusActiveHpBar(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}