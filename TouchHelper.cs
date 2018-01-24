using UnityEngine;

public class TouchHelper : MonoBehaviour
{
    private float _touchTime;
    public float tapTimeLimit = 0.05f;

    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string DOWN = "down";
    public const string UP = "up";

    public Signal tapSignal = new Signal();
    public Signal<string, float> swipeSignal = new Signal<string, float>();
    public Signal<float> touchEndedSignal = new Signal<float>();

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _touchTime = 0;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (RaycastTouch(touch.position) == gameObject.name)
                {
                    _touchTime += Time.deltaTime;
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (_touchTime > 0 && _touchTime < tapTimeLimit)
                    tapSignal.Dispatch();

                if (touch.deltaPosition.magnitude > 0)
                {
                    if (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y))
                        swipeSignal.Dispatch(touch.deltaPosition.x < 0 ? LEFT : RIGHT, _touchTime);
                    else
                        swipeSignal.Dispatch(touch.deltaPosition.y < 0 ? DOWN : UP, _touchTime);
                }
                
                touchEndedSignal.Dispatch(_touchTime);
                print("You've been touching " + _touchTime + " seconds.");
            }
        }
    }

    private string RaycastTouch(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
//            print(hitInfo.collider.name);
            return hitInfo.collider.name;
        }
        else
        {
            print("Nothing is touched");
            return "";
        }
    }
}