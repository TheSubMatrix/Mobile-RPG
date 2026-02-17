using UnityEngine;
using UnityEngine.Events;
public interface IJoystick
{
    UnityEvent<Vector2> OnJoystickPositionUpdated { get; }
}
