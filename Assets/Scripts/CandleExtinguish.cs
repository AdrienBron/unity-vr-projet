using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class CandleExtinguish : MonoBehaviour
{
    MeshRenderer[] flameRenderers;
    Light          flameLight;
    bool           isLit = true;

    [Header("Swap Body Material")]
    public MeshRenderer candleBodyRenderer;
    public Material    unlitMaterial;

    void Start()
    {
        // Récupère les "quads" de flamme
        var allMR = GetComponentsInChildren<MeshRenderer>();
        var list  = new List<MeshRenderer>();
        foreach (var mr in allMR)
            if (mr.gameObject.name.Contains("Quad"))
                list.Add(mr);
        flameRenderers = list.ToArray();

        // Récupère la light de la flamme
        flameLight = GetComponentInChildren<Light>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && isLit)
            Extinguish();
    }

    void Extinguish()
    {
        isLit = false;  // marque la bougie comme éteinte

        // désactive les quads et la lumière
        foreach (var mr in flameRenderers) mr.enabled = false;
        if (flameLight != null) flameLight.enabled = false;

        // swap du matériau du corps
        if (candleBodyRenderer != null && unlitMaterial != null)
            candleBodyRenderer.material = unlitMaterial;
    }

    // Expose l’état pour le manager
    public bool IsLit => isLit;
}
