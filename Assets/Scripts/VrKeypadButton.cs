using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRKeypadButton : MonoBehaviour
{
    public string buttonValue = "1";
    public KeypadManager manager;

    public void OnPress()
    {
        Debug.Log("Adrichou a appuyé sur le bouton : " + buttonValue);
        manager.ReceiveInput(buttonValue);
    }
}