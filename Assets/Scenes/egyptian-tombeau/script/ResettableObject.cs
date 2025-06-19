using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        Debug.Log($"{gameObject.name} - Position initiale enregistrée : {startPosition}");
    }

    public void ResetPosition()
    {
        Debug.Log($"{gameObject.name} - Réinitialisation de la position.");
        transform.position = startPosition;
        transform.rotation = startRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log($"{gameObject.name} - Vitesse remise à zéro.");
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} - Aucun Rigidbody trouvé !");
        }
    }
}
