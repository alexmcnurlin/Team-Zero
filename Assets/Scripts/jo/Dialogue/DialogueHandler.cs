using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler:MonoBehaviour {

    private InGameUI ui;
    public Canvas dialogueBox;
    public Text dialogueText;

    private void Start()
    {
        ui = GameObject.FindGameObjectWithTag("InGameUIController").GetComponent<InGameUI>();
    }
    
    IEnumerator WaitForKeyDown()
    {
        while(true) 
        {
            Debug.Log("Checking");
            if(Input.GetKeyDown(KeyCode.Space)) {
                dialogueBox.gameObject.SetActive(false);
                ui.Unpause();
            } else {
                yield return null;
            }
            yield return null;
        }
    }

    /*
    IEnumerator WaitForKeyDown()
    {
        
        yield return new WaitForSeconds(3);
        dialogueBox.gameObject.SetActive(false);
    }
    */

    public void Say(string dialogue)
    {
        ui.PauseGame();
        dialogueBox.gameObject.SetActive(true);
        //dialogueText.text = dialogue;
        StartCoroutine(WaitForKeyDown());
    }
}