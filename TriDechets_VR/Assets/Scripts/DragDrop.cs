using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        offset = transform.position - Camera.main.ScreenToWorldPoint(mousePoint);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = zCoord;
            transform.position = Camera.main.ScreenToWorldPoint(mousePoint) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        Collider selfCol = GetComponent<Collider>();
        if (selfCol == null)
        {
            return;
        }

        Collider[] hits = Physics.OverlapSphere(transform.position, 0.5f);
        foreach (var hit in hits)
        {
            SortingBin bin = hit.GetComponent<SortingBin>();
            if (bin == null)
            {
                bin = hit.GetComponentInParent<SortingBin>();
            }
            if (bin != null)
            {
                bin.Evaluate(selfCol);
                return;
            }
        }
    }
}
