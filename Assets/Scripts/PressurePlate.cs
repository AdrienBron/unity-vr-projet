using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator gateAnimator;
    [SerializeField] private string openTrigger = "Open";
    [SerializeField] private string closeTrigger = "Close";

    private int objectsOnPlate = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CubeGrabbable"))
        {
            objectsOnPlate++;
            if (objectsOnPlate == 1)
                gateAnimator.SetTrigger(openTrigger);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CubeGrabbable"))
        {
            objectsOnPlate = Mathf.Max(0, objectsOnPlate - 1);
            if (objectsOnPlate == 0)
                gateAnimator.SetTrigger(closeTrigger);
        }
    }
}
// Ce script gère une plaque de pression qui ouvre et ferme une porte lorsque des objets sont placés ou retirés.
// Il utilise un Animator pour contrôler les états d'animation de la porte en fonction du nombre d'objets sur la plaque.