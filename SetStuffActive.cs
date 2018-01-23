using System.Collections.Generic;
using UnityEngine;

public class SetStuffActive : MonoBehaviour
{
    public List<GameObject> stuffToActivate;
    public List<GameObject> stuffToDeactivate;

    public void Execute()
    {
        stuffToActivate.ForEach(go => go.SetActive(true));
        stuffToDeactivate.ForEach(go => go.SetActive(false));
    }
}