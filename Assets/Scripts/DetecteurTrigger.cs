using UnityEngine;

public class DetecteurTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant a le tag "Crane"
        if (other.CompareTag("Crane"))
        {
            Debug.Log("collider");
        }
    }
}
