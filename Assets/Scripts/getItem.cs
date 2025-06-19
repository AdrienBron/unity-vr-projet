using UnityEngine;
using UnityEngine.InputSystem;

public class getItem : MonoBehaviour
{
    public GameObject uiGet;
    public playerScript player;

    private PlayerInputActions input;
    private InputAction interact;

    void Awake()
    {
        input = new PlayerInputActions();
        interact = input.Player.Interact;
    }

    void OnEnable()
    {
        interact.Enable();
        interact.performed += OnInteract;
    }

    void OnDisable()
    {
        interact.performed -= OnInteract;
        interact.Disable();
    }

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

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!uiGet.activeSelf) return;

        player.key.SetActive(true);
        Destroy(gameObject);
    }
}