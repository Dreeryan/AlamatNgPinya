using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text       nameText;
    [SerializeField] private Text       dialogueText;
    [SerializeField] private GameObject dialogueBox;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    // Used to start the dialogue UI
    public void StartDialogue(Dialogue dialogue) 
    {
        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // For Continue button to proceed to the next sentence
    public void DisplayNextSentence() 
    {
        // Ends the dialogue if all sentences are finished
        if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        Debug.Log("End Dialogue");
    }
}
