using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
	//A: Explicitly private
    [SerializeField] Button itemButton;
    private bool isNear;

    // Start is called before the first frame update
    void Start()
    {
		//A: Nullcheck
        itemButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    // Loads the minigame scene
    public void LoadMinigame()
    {
        SceneManager.LoadScene("CleanUp");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
		//A: Nullcheck
        // If the player collides with the Item, the button will appear
        if (collision.gameObject.CompareTag("Player"))
        {
            itemButton.gameObject.SetActive(true);
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
