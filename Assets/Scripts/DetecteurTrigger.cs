using UnityEngine;

public class DetecteurTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet entrant a le tag "Crane"
        if (other.CompareTag("Crane"))
        {
            Debug.Log("collider");
        }
    }
}
