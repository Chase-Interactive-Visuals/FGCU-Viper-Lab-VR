/*
 * Notice:
 * This script was prepared by Chase Interactive Visuals, LLC, 
 * and is provided to FGCU for educational purposes only!
 * 
 * Class Summary:
 * Controls the VRPhysicalButton actions and events 
 */
using UnityEngine;
using UnityEngine.Events;

public class PhysicalButtonVR : MonoBehaviour
{
    [SerializeField] float _threshold = 0.1f;
    [SerializeField] float _paddingSpace = 0.025f;
    [SerializeField] Vector3 _buttonDistance;

    Vector3 _startPos;
    ConfigurableJoint _joint;
    bool _isPressed = false;

    public UnityEvent _onVRButtonPress;
    public UnityEvent<int> _onVRButtonRelease;
    [SerializeField] int _buttinFunctionalityIndex;

    //Boolean to activate/deactivate debugging for understanding code events
    [SerializeField] bool debuggingIsActive;

    private void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }
    private void Update()
    {
        if (!_isPressed && GetValue() + _threshold >= 1)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - _threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;
        if (Mathf.Abs(value) < _paddingSpace)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        _onVRButtonPress.Invoke();
        if (debuggingIsActive) 
        {
            LoggingManager.LogToConsole("Pressed");
        }
    }
    private void Released()
    {
        _isPressed = false;
        _onVRButtonRelease.Invoke(_buttinFunctionalityIndex);
        if (debuggingIsActive)
        {
            LoggingManager.LogToConsole("Released");
        }
    }
}
