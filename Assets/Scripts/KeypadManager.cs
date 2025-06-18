using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeypadManager : MonoBehaviour
{
    private string currentInput = "";
    public Animator anim;

    public void ReceiveInput(string val)
    {
        currentInput += val;
        Debug.Log("Code actuel : " + currentInput);

        if (currentInput == "354")
        {
            Debug.Log("Code correct !");
            anim.SetTrigger("open");
            StartCoroutine("IEnumerator");

        }
    }

    public IEnumerator loadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("boatRoom");

    }

    public void ResetInput() => currentInput = "";
}