using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if (target)
            transform.LookAt(target);
    }
}