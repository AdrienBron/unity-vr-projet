using UnityEngine;
using System.Linq;


[RequireComponent(typeof(Collider))]
public class CandleExtinguish : MonoBehaviour
{
    MeshRenderer[] flameRenderers;
    Light        flameLight;

    void Start()
    {
        flameRenderers = GetComponentsInChildren<MeshRenderer>()
            .Where(mr => mr.gameObject.name.Contains("Quad"))
            .ToArray();

        flameLight = GetComponentInChildren<Light>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
            Extinguish();
    }

    void Extinguish()
    {
        // Désactive l’affichage des quads
        foreach (var mr in flameRenderers)
            mr.enabled = false;
        // Désactive la lumière
        if (flameLight != null)
            flameLight.enabled = false;
    }
}
