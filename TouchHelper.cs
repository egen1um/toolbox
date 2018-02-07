using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHelper : MonoBehaviour
{
    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string DOWN = "down";
    public const string UP = "up";

    private readonly TouchData _currentTouchData = new TouchData();
    public Signal<TouchData> holdSignal = new Signal<TouchData>();
    public Signal<string, TouchData> swipeSignal = new Signal<string, TouchData>();

    public Signal<TouchData> tapSignal = new Signal<TouchData>();

    public float tapTimeLimit = 0.06f;
    public Signal<TouchData> touchEndedSignal = new Signal<TouchData>();

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.currentSelectedGameObject != null)
                return;


            var touch = Input.GetTouch(0);
            _currentTouchData.SetTouchData(touch);

            if (touch.phase == TouchPhase.Began)
                ResetTouchTimes();

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                var lastTouchedGO = _currentTouchData.LastTouchedGO;
                if (lastTouchedGO != null)
                {
                    if (!_currentTouchData.touchedGOTimes.ContainsKey(_currentTouchData.LastTouchedGO))
                        _currentTouchData.touchedGOTimes[_currentTouchData.LastTouchedGO] = 0;

                    _currentTouchData.touchedGOTimes[_currentTouchData.LastTouchedGO] += Time.deltaTime;
                }

                _currentTouchData.touchDuration += Time.deltaTime;
                holdSignal.Dispatch(_currentTouchData);
            }

//            print("Time: " + _currentTouchData.touchDuration);

            if (touch.phase == TouchPhase.Ended)
            {
                // Tap
                if (_currentTouchData.touchDuration > 0 && _currentTouchData.touchDuration < tapTimeLimit)
                    tapSignal.Dispatch(_currentTouchData);

                // Swipe
                if (touch.deltaPosition.magnitude > 0)
                    if (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y))
                        swipeSignal.Dispatch(touch.deltaPosition.x < 0 ? LEFT : RIGHT, _currentTouchData);
                    else
                        swipeSignal.Dispatch(touch.deltaPosition.y < 0 ? DOWN : UP, _currentTouchData);

                touchEndedSignal.Dispatch(_currentTouchData);
            }
        }
    }

    private void ResetTouchTimes()
    {
        _currentTouchData.touchDuration = 0;
        _currentTouchData.touchedGOTimes.Clear();
    }


    public class TouchData
    {
        public readonly Dictionary<GameObject, float> touchedGOTimes = new Dictionary<GameObject, float>();
        private RaycastHit _raycastHitInfo;

        public float touchDuration;

        public RaycastHit RaycastHitInfo
        {
            get { return _raycastHitInfo; }
        }

        public GameObject LastTouchedGO
        {
            get { return _raycastHitInfo.collider != null ? _raycastHitInfo.collider.gameObject : null; }
        }

        public Touch Touch { get; private set; }

        public void SetTouchData(Touch touch)
        {
            Touch = touch;
            var ray = Camera.main.ScreenPointToRay(touch.position);
            Physics.Raycast(ray, out _raycastHitInfo);
        }

        public bool HasTouchedGO(GameObject go)
        {
            return touchedGOTimes.ContainsKey(go);
        }

        public float LastTouchedGOTime()
        {
            return touchedGOTimes[LastTouchedGO];
        }
    }
}