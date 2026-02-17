using MatrixUtils.Attributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
/// <summary>
/// On-screen joystick for mobile devices. Passes the results out via <see cref="UnityEvent{T0}"/>
/// </summary>
[RequireComponent(typeof(RectTransform)), DisallowMultipleComponent]
public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IJoystick
{
    [HideInInspector] public RectTransform JoystickRect;
    [RequiredField] public RectTransform KnobRect;
    [field:SerializeField] public UnityEvent<Vector2> OnJoystickPositionUpdated { get; private set; } = new();
    float JoystickCircleRadius => Mathf.Min(JoystickRect.rect.width, JoystickRect.rect.height) / 2f;
    float KnobRadius => Mathf.Min(KnobRect.rect.width, KnobRect.rect.height) / 2f;
    void Awake()
    {
        JoystickRect = GetComponent<RectTransform>();
        KnobRect.anchoredPosition = Vector2.zero;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateJoystickPosition(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        UpdateJoystickPosition(eventData);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        KnobRect.anchoredPosition = Vector2.zero;
        OnJoystickPositionUpdated.Invoke(Vector2.zero);
    }
    void UpdateJoystickPosition(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            JoystickRect, 
            eventData.position, 
            eventData.pressEventCamera, 
            out Vector2 localPoint
        );
        float maxKnobDistance = JoystickCircleRadius - KnobRadius;
        Vector2 clampedPosition = Vector2.ClampMagnitude(localPoint, maxKnobDistance);
        KnobRect.anchoredPosition = clampedPosition;
        OnJoystickPositionUpdated.Invoke(clampedPosition / maxKnobDistance);
    }
}