using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private Animator gateAnimator;
    [SerializeField] private string openTrigger = "Open";
    [SerializeField] private string closeTrigger = "Close";

    private int objectsOnPlate = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("CubeGrabbable"))
            return;

        objectsOnPlate++;
        Debug.Log($"[PressurePlate] OnTriggerEnter: {other.name} count = {objectsOnPlate}");

        if (objectsOnPlate == 1)
        {
            Debug.Log("[PressurePlate] First object placed → Open gate");
            gateAnimator.SetTrigger(openTrigger);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("CubeGrabbable"))
            return;

        objectsOnPlate = Mathf.Max(0, objectsOnPlate - 1);
        Debug.Log($"[PressurePlate] OnTriggerExit: {other.name} count = {objectsOnPlate}");

        if (objectsOnPlate == 0)
        {
            Debug.Log("[PressurePlate] Last object removed → Close gate");
            gateAnimator.SetTrigger(closeTrigger);
        }
    }
}
