using UnityEngine;

public class getItem : MonoBehaviour
{
    public GameObject uiGet;
    public playerScript player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiGet.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiGet.SetActive(false);
        }
    }
    private void Update()
    {
        if(uiGet.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            player.key.SetActive(true);
            Destroy(gameObject);
        }
    }
}
