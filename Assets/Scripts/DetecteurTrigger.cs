using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DetecteurTrigger : MonoBehaviour
{
    public Animator prisonDoorAnimator;
    public Light indicatorLight;
    public AudioSource doorAudioSource;
    public float delay = 1.0f;

    private bool hasPlayedSound = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Crane"))
        {
            StartCoroutine(TriggerSequence());
        }
    }

    private IEnumerator TriggerSequence()
    {
        yield return new WaitForSeconds(delay);

        if (prisonDoorAnimator != null)
        {
            prisonDoorAnimator.SetTrigger("Open");
        }

        if (indicatorLight != null)
        {
            indicatorLight.color = Color.green;
        }

        if (doorAudioSource != null && !hasPlayedSound)
        {
            doorAudioSource.Play();
            hasPlayedSound = true;
        }
        yield return new WaitForSeconds(4.0f);

        SceneManager.LoadScene(3);
    }
}
