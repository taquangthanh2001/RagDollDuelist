using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class JoyStick : MonoBehaviour
{
    [SerializeField] protected GameObject joystick;
    [SerializeField] protected GameObject joystickBG;
    [FormerlySerializedAs("panel")] [SerializeField] protected GameObject bgJoyStickPanel;
    internal Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    internal Vector2 joystickVecDf;
    internal Vector2 joystickVecMove;

    internal bool isMoveByJoystick = false;


    private static JoyStick _instance;
    public static JoyStick Instance
    {
        get => _instance;
        private set { _instance = value; }
    }


    // Start is called before the first frame update
    private void Start()
    {
        if (_instance == null)
            Instance = this;

        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 2.5f;
    }

    public void PointerDown()
    {
        bgJoyStickPanel.SetActive(true);
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
        joystickVecDf = joystick.GetComponent<RectTransform>().anchoredPosition;
        isMoveByJoystick = true;
    }

    public void Drag(BaseEventData baseEventData)
    {
        var pointerEventData = baseEventData as PointerEventData;
        var dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;

        var joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;
        }

        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }

        joystickVecMove = joystick.GetComponent<RectTransform>().anchoredPosition;
    }

    public void PointerUp()
    {
        isMoveByJoystick = false;
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        bgJoyStickPanel.SetActive(false);
    }
}