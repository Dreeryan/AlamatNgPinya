using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private GameObject dialogueBox;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue) // Used to start the dialogue UI
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

    public void DisplayNextSentence() // For Continue button to proceed to the next sentence
    {
        if (sentences.Count == 0) // Ends the dialogue if all sentences are finished
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
