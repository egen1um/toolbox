using UnityEngine;
using UnityEngine.UI;

public class ChangeColorToggle : Toggle
{
    [SerializeField] private Color _isOnColor;
    [SerializeField] private Color _isOffColor;
    

    protected override void Start()
    {
        base.Start();
        OnValueChanged(isOn);
        onValueChanged.AddListener(OnValueChanged);
    }

    protected virtual void OnValueChanged(bool value)
    {
        image.color = value ? _isOnColor : _isOffColor;
    }
}