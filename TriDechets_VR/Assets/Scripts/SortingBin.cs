using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

public class SortingBin : MonoBehaviour
{
    public WasteItem.WasteType acceptedType;
    public GameObject correctSymbol;
    public GameObject wrongSymbol;
    public TextMeshPro label;

    private void Start()
    {
        if (correctSymbol == null)
        {
            var found = GameObject.Find("CorrectSymbol");
            if (found != null) correctSymbol = found;
        }
        if (wrongSymbol == null)
        {
            var found = GameObject.Find("WrongSymbol");
            if (found != null) wrongSymbol = found;
        }

        if (label != null)
        {
            label.text = GetLabelText();
            label.alignment = TextAlignmentOptions.Center;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Evaluate(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Evaluate(collision.collider);
    }

    public void Evaluate(Collider itemCollider)
    {
        WasteItem item = itemCollider.GetComponent<WasteItem>();

        if (item != null)
        {
            if (item.wasteType == acceptedType)
            {
                Debug.Log("✅ Correct!");
                if (wrongSymbol != null) wrongSymbol.SetActive(false);
                if (correctSymbol != null) correctSymbol.SetActive(true);
                GameManager.instance.AddScore(1);
                Destroy(itemCollider.gameObject);
            }
            else
            {
                Debug.Log("❌ Incorrect!");
                if (correctSymbol != null) correctSymbol.SetActive(false);
                if (wrongSymbol != null) wrongSymbol.SetActive(true);
                GameManager.instance.SubtractScore(1);
                // Do NOT destroy item on incorrect drop; allow player to try again
            }
        }
    }

    private string GetLabelText()
    {
        switch (acceptedType)
        {
            case WasteItem.WasteType.Papier:
                return "Papiers";
            case WasteItem.WasteType.Bouteille:
                return "Bouteilles";
            case WasteItem.WasteType.Cannette:
                return "Canettes";
            case WasteItem.WasteType.Alimentation:
                return "Déchets alimentaires";
            default:
                return acceptedType.ToString();
        }
    }
}
