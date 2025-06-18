using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class KeypadManager : MonoBehaviour
{
    private string currentInput = "";

    public void ReceiveInput(string val)
    {
        currentInput += val;
        Debug.Log("Code actuel : " + currentInput);

        if (currentInput == "354")
        {
            Debug.Log("Code correct !");
            SceneManager.LoadScene("boatRoom");

        }
    }

    public void ResetInput() => currentInput = "";
}