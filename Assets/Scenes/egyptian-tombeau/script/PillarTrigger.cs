using UnityEngine;
using System.Collections;

public class PillarTrigger : MonoBehaviour
{
    public GameObject door;
    public float openYPosition = 25f;
    public float transitionDuration = 50f;

    private Vector3 closedPosition;
    private Coroutine moveCoroutine;

    private void Start()
    {
        if (door != null)
        {
            closedPosition = door.transform.position;
        }
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Totem") && door != null)
    {
        Debug.Log("Totem posé - ouverture en douceur");

        Vector3 openPosition = new Vector3(
            closedPosition.x,
            openYPosition,
            closedPosition.z
        );

        AudioSource audio = door.GetComponent<AudioSource>();
        if (audio != null && !audio.isPlaying)
        {
            audio.Play();
        }

        StartMovingDoor(openPosition);
    }
}


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Totem") && door != null)
        {
            Debug.Log("Totem retiré - fermeture en douceur");
            StartMovingDoor(closedPosition);
        }
    }

    private void StartMovingDoor(Vector3 targetPosition)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveDoor(targetPosition));
    }

    private IEnumerator MoveDoor(Vector3 target)
    {
        Vector3 start = door.transform.position;
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            door.transform.position = Vector3.Lerp(start, target, elapsed / transitionDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        door.transform.position = target;
    }
}
