using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class CandleExtinguish : MonoBehaviour
{
    MeshRenderer[] flameRenderers;
    Light        flameLight;

    [Header("Swap Body Material")]
    public MeshRenderer candleBodyRenderer;  // drag-drop de votre mesh “candle body”
    public Material    unlitMaterial;        // assignez ici Candle01

    void Start()
    {
        // repère uniquement les quads de la flamme
        var allMR = GetComponentsInChildren<MeshRenderer>();
        var list   = new List<MeshRenderer>();
        foreach (var mr in allMR)
            if (mr.gameObject.name.Contains("Quad"))
                list.Add(mr);
        flameRenderers = list.ToArray();

        flameLight = GetComponentInChildren<Light>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
            Extinguish();
    }

    void Extinguish()
    {
        // 1) éteindre quads + lumière
        foreach (var mr in flameRenderers) mr.enabled = false;
        if (flameLight != null) flameLight.enabled = false;

        // 2) swap du matériau du corps
        if (candleBodyRenderer != null && unlitMaterial != null)
            candleBodyRenderer.material = unlitMaterial;
    }
}
