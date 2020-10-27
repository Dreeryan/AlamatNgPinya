using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Button itemButton;
    private bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        if (itemButton != null) itemButton.gameObject.SetActive(false);
    }

    // Loads the minigame scene
    public void LoadMinigame()
    {
        SceneManager.LoadScene("CleanUp");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with the Item, the button will appear
        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemButton != null) itemButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // If the player collides with the Item and stay, the button will appear
        if (collision.gameObject.CompareTag("Player"))
        {
            itemButton.gameObject.SetActive(true);
            isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // If the player is already far from the Item, the button will disappear
        if (collision.gameObject.CompareTag("Player"))
        {
            itemButton.gameObject.SetActive(false);
            isNear = false;
        }
    }
}
