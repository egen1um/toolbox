using UnityEngine;
using UnityEngine.UI;

public class SwapSpriteToggle : Toggle
{
    private Sprite _isOffSprite;
    [SerializeField] private Sprite _isOnSprite;

    protected override void Start()
    {
        base.Start();

        _isOffSprite = image.sprite;

        onValueChanged.AddListener(OnValueChanged);
    }

    protected virtual void OnValueChanged(bool value)
    {
        image.sprite = value ? _isOnSprite : _isOffSprite;
    }
}