using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    private string currentInput = "";
    public Animator anim;
    public TMP_Text screen;

    public void ReceiveInput(string val)
    {
        currentInput += val;
        screen.text = currentInput;
        Debug.Log("Code actuel : " + currentInput);
    }

    public IEnumerator loadScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("boatRoom");

    }

    public void EnterInput()
    {
        if (currentInput == "354")
        {
            Debug.Log("Code correct !");
            anim.SetTrigger("open");
            StartCoroutine("IEnumerator");

        }
        currentInput = "";
        screen.text = currentInput;
    }
}