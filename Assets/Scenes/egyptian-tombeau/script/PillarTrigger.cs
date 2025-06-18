using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public GameObject door;
    public float newYPosition = 25f;
    private bool hasActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasActivated) return;

        if (other.CompareTag("Totem"))
        {
            Debug.Log("Totem détecté sur le trigger !");

            if (door != null)
            {
                Debug.Log("Door détectée : " + door.name);

                Door doorController = door.GetComponent<Door>();
                if (doorController != null)
                {
                    doorController.StopAllCoroutines();
                }

                Vector3 newPos = door.transform.position;
                newPos.y = newYPosition;
                door.transform.position = newPos;

                Debug.Log("Nouvelle position : " + door.transform.position);

                hasActivated = true;
            }
            else
            {
                Debug.LogWarning("⚠️ Aucune porte assignée dans l’inspecteur !");
            }
        }
    }
}
