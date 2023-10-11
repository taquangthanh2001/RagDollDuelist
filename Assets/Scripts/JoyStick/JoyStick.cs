using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class JoyStick : MonoBehaviour
{
    [SerializeField] protected GameObject joystick;
    [FormerlySerializedAs("joystickBG")] [SerializeField] protected GameObject joystickBg;
    [FormerlySerializedAs("panel")] [SerializeField] protected GameObject bgJoyStickPanel;
    internal Vector2 joystickVec;
    private Vector2 _joystickTouchPos;
    private Vector2 _joystickOriginalPos;
    private float _joystickRadius;
    internal Vector2 joystickVecDf;
    internal Vector2 joystickVecMove;

    internal bool isMoveByJoystick = false;


    private static JoyStick _instance;
    public static JoyStick Instance
    {
        get => _instance;
        private set => _instance = value;
    }


    // Start is called before the first frame update
    private void Start()
    {
        if (_instance == null)
            Instance = this;

        _joystickOriginalPos = joystickBg.transform.position;
        _joystickRadius = joystickBg.GetComponent<RectTransform>().sizeDelta.y / 2.5f;
    }

    public void PointerDown()
    {
        bgJoyStickPanel.SetActive(true);
        joystick.transform.position = Input.mousePosition;
        joystickBg.transform.position = Input.mousePosition;
        _joystickTouchPos = Input.mousePosition;
        joystickVecDf = joystick.GetComponent<RectTransform>().anchoredPosition;
        isMoveByJoystick = true;
    }

    public void Drag(BaseEventData baseEventData)
    {
        var pointerEventData = baseEventData as PointerEventData;
        if (pointerEventData != null)
        {
            var dragPos = pointerEventData.position;
            joystickVec = (dragPos - _joystickTouchPos).normalized;

            var joystickDist = Vector2.Distance(dragPos, _joystickTouchPos);

            if (joystickDist < _joystickRadius)
            {
                joystick.transform.position = _joystickTouchPos + joystickVec * joystickDist;
            }

            else
            {
                joystick.transform.position = _joystickTouchPos + joystickVec * _joystickRadius;
            }
        }

        joystickVecMove = joystick.GetComponent<RectTransform>().anchoredPosition;
    }

    public void PointerUp()
    {
        isMoveByJoystick = false;
        joystickVec = Vector2.zero;
        joystick.transform.position = _joystickOriginalPos;
        joystickBg.transform.position = _joystickOriginalPos;
        bgJoyStickPanel.SetActive(false);
    }
}