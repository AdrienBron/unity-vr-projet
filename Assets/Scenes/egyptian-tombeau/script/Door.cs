using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public float openY = 15f;
    public float duration = 50000f;

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
            float t = Mathf.SmoothStep(0f, 1f, elapsed / duration);
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        transform.position = endPos;
    }
}
