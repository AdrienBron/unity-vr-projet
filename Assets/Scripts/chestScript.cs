using UnityEngine;
using UnityEngine.InputSystem;

public class chestScript : MonoBehaviour
{

    public GameObject uiGet;
    public playerScript player;

    private PlayerInputActions input;
    private InputAction interact;

    private bool isOpen=false;

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
        if (other.CompareTag("Player") && !isOpen)
        {
            uiGet.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            uiGet.SetActive(false);
        }
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (!uiGet.activeSelf || !player.key.activeSelf) return;
        player.paper.SetActive(true);
        uiGet.SetActive(false);
        isOpen = true;
    }
}
