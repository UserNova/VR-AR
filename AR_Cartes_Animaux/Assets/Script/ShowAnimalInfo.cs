using UnityEngine;
using Vuforia;

public class ShowAnimalInfo : MonoBehaviour
{
    [Header("Panneaux UI (Canvas enfants)")]
    public GameObject lionPanel;      // Contient LionImage + LionText
    public GameObject catPanel;       // Contient CatImage + CatText
    public GameObject elephantPanel;  // Contient ElephantImage + ElephantText
    public GameObject tigerPanel;     // Contient TiggerImage + TiggerText

    void Start()
    {
        // Masquer tout au démarrage
        HideAll();

        // Activer l’écoute de la détection Vuforia
        if (VuforiaBehaviour.Instance != null)
        {
            VuforiaBehaviour.Instance.World.OnObserverCreated += OnTargetCreated;
        }
    }

    void OnDestroy()
    {
        // Nettoyer les écouteurs quand on quitte la scène
        if (VuforiaBehaviour.Instance != null)
        {
            VuforiaBehaviour.Instance.World.OnObserverCreated -= OnTargetCreated;
        }
    }

    // Quand une nouvelle cible (Image Target) est créée
    void OnTargetCreated(ObserverBehaviour observer)
    {
        observer.OnTargetStatusChanged += OnStatusChanged;
    }

    // Quand la caméra voit ou perd une carte
    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            Debug.Log(" Cible détectée : " + behaviour.TargetName);
            ShowForTarget(behaviour.TargetName);
        }
        else
        {
            HideAll();
        }
    }

    // Affiche le panneau correspondant à la cible détectée
    void ShowForTarget(string targetName)
    {
        HideAll(); // On cache tout d'abord

        string key = targetName.ToLower().Replace(" ", "");

        Debug.Log(" Activation du panneau pour : " + key);

        switch (key)
        {
            case "lion":
            case "lion_card_scaled":
            case "imagetarget_lion":
                if (lionPanel != null) lionPanel.SetActive(true);
                else Debug.LogWarning(" LionPanel non assigné !");
                break;

            case "cat":
            case "cat_card_scaled":
            case "imagetarget_cat":
                if (catPanel != null) catPanel.SetActive(true);
                else Debug.LogWarning(" CatPanel non assigné !");
                break;

            case "elephant":
            case "elephant_card_scaled":
            case "imagetarget_elephant":
                if (elephantPanel != null) elephantPanel.SetActive(true);
                else Debug.LogWarning(" ElephantPanel non assigné !");
                break;

            case "tigger":
            case "tigger_card_scaled":
            case "imagetarget_tigger":
                if (tigerPanel != null) tigerPanel.SetActive(true);
                else Debug.LogWarning(" TigerPanel non assigné !");
                break;

            default:
                Debug.LogWarning(" Cible inconnue : " + targetName);
                break;
        }
    }

    // Cache tous les panneaux
    void HideAll()
    {
        if (lionPanel != null) lionPanel.SetActive(false);
        if (catPanel != null) catPanel.SetActive(false);
        if (elephantPanel != null) elephantPanel.SetActive(false);
        if (tigerPanel != null) tigerPanel.SetActive(false);
    }
}
