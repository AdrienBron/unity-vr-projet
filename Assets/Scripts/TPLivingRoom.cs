using UnityEngine;
using UnityEngine.SceneManagement;

public class TPLivingRoom : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone, changing scene...");
            SceneManager.LoadScene(5);
        }
    }
}
