using UnityEngine;

public class ResetZone : MonoBehaviour
{
    public ResettableObject totem;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[ResetZone] {other.gameObject.name} est entré dans la zone.");

        if (other.CompareTag("Player"))
        {
            if (totem != null)
            {
                Debug.Log("[ResetZone] Réinitialisation du Totem !");
                totem.ResetPosition();
            }
            else
            {
                Debug.LogWarning("[ResetZone] Le Totem n'est pas assigné dans l'inspecteur !");
            }
        }
    }
}
