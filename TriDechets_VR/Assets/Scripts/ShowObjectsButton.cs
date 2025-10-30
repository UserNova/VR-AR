using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ShowObjectsButton : MonoBehaviour
{
    public GameObject[] objectsToShow;

    public void ShowAll()
    {
        foreach(GameObject obj in objectsToShow)
        {
            obj.SetActive(true);
        }
    }
}
