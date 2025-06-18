using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public float openY = 15f;       // Position finale en Y
    public float duration = 99999999999999999999999999f;    // Durée en secondes

    private bool isOpening = false;

    public void OpenDoor()
    {
        if (!isOpening)
            StartCoroutine(OpenDoorCoroutine());
    }

    private IEnumerator OpenDoorCoroutine()
    {
        isOpening = true;

        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(startPos.x, openY, startPos.z);

        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration); // easing
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        transform.position = endPos; // Snap to final position
    }
}
