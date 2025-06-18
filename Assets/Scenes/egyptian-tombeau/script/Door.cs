using UnityEngine;

public class Door: MonoBehaviour
{
    public Vector3 openOffset = new Vector3(0, 3, 0);
    public float openDuration = 1.5f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + openOffset;
    }

    public void OpenDoor()
    {
        if (!isOpening)
        {
            StartCoroutine(OpenRoutine());
        }
    }

    private System.Collections.IEnumerator OpenRoutine()
    {
        isOpening = true;
        float elapsed = 0f;

        while (elapsed < openDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / openDuration);
            transform.position = Vector3.Lerp(closedPosition, openPosition, t);
            yield return null;
        }

        transform.position = openPosition;
    }
}
