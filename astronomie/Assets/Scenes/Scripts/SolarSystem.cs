using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrbitAroundSun : MonoBehaviour
{
    [Header("Objets")]
    public Transform sun;      // 🌞 Soleil (centre fixe)
    public Transform earth;    // 🌍 Terre
    public Transform moon;     // 🌕 Lune

    [Header("Vitesses d'orbite")]
    public float earthOrbitSpeed = 20f; // vitesse Terre autour du Soleil
    public float moonOrbitSpeed = 40f;  // vitesse Lune autour du Soleil

    private float earthOrbitRadius; // distance entre Terre et Soleil
    private float moonOrbitRadius;  // distance entre Lune et Soleil

    void Start()
    {
        // Calculer les distances initiales (rayons d’orbite)
        if (sun && earth)
            earthOrbitRadius = Vector3.Distance(sun.position, earth.position);
        if (sun && moon)
            moonOrbitRadius = Vector3.Distance(sun.position, moon.position);
    }

    void Update()
    {
        // 🌍 Terre tourne autour du Soleil
        if (sun && earth)
            earth.RotateAround(sun.position, Vector3.up, earthOrbitSpeed * Time.deltaTime);

        // 🌕 Lune tourne aussi autour du Soleil
        if (sun && moon)
            moon.RotateAround(sun.position, Vector3.up, moonOrbitSpeed * Time.deltaTime);
    }

    // 🔵 Dessiner les orbites dans la vue "Scene"
    void OnDrawGizmos()
    {
        if (sun && earth)
        {
            Gizmos.color = Color.blue; // orbite de la Terre
            DrawOrbit(sun.position, Vector3.Distance(sun.position, earth.position));
        }

        if (sun && moon)
        {
            Gizmos.color = Color.gray; // orbite de la Lune
            DrawOrbit(sun.position, Vector3.Distance(sun.position, moon.position));
        }
    }

    // Fonction pour dessiner un cercle
    void DrawOrbit(Vector3 center, float radius)
    {
        int segments = 100;
        Vector3 previousPoint = center + new Vector3(radius, 0, 0);
        for (int i = 1; i <= segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;
            Vector3 nextPoint = center + new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            Gizmos.DrawLine(previousPoint, nextPoint);
            previousPoint = nextPoint;
        }
    }
}
