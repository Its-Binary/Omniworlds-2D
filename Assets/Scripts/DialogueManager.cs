using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text text;

    public bool active;

    //Add ability to store multi-line dialogue
    public string[] dialogueLines;
    public int currentLine;
    
	
    // Update is called once per frame
    private void Update ()
    {
        if(active && Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }

        if (currentLine >= dialogueLines.Length) {
            dialogueBox.SetActive(false);
            active = false;
            currentLine = 0;
        }

        text.text = dialogueLines [currentLine];
    }

    public void ShowBox(string dialogue)
    {
        active = true;
        dialogueBox.SetActive(true);
        text.text = dialogue;
    }

    public void ShowDialogue()
    {
        active = true;
        dialogueBox.SetActive (true);
    }
}