using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager _dialogueManager;

    public string[] dialogueLines;

    // Use this for initialization
    private void Start ()
    {
        _dialogueManager = FindObjectOfType<DialogueManager> ();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") 
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                //dMan.ShowBox(dialogue);
                if (!_dialogueManager.active) 
                {
                    _dialogueManager.dialogueLines = dialogueLines;
                    _dialogueManager.currentLine = 0;
                    _dialogueManager.ShowDialogue();
                }
            }
        }
    }
}