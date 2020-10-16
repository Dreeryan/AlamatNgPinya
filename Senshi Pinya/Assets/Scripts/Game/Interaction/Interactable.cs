using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    [SerializeField] Button itemButton;
    private bool isNear;

    // Start is called before the first frame update
    void Start()
    {
        itemButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    // Load the minigame
    public void LoadMinigame()
    {
        SceneManager.LoadScene("CleanUp");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemButton.gameObject.SetActive(true);
            isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemButton.gameObject.SetActive(false);
            isNear = false;
        }
    }
}
