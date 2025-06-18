using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public GameObject door;
    public float newYPosition = 25f;
    private bool hasActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasActivated) return;

        if (door != null)
        {
            Debug.Log("Door détectée : " + door.name);

            Door doorController = door.GetComponent<Door>();
            if (doorController != null)
            {
                doorController.OpenDoor();
            }
            else
            {
                Debug.LogWarning("⚠️ Le script DoorController est manquant sur la porte !");
            }

            hasActivated = true;
        }
        else
        {
            Debug.LogWarning("⚠️ Aucune porte assignée dans l’inspecteur !");
        }

    }
}
