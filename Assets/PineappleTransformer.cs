using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class PineappleTransformer : MonoBehaviour
{
    public UnityEvent onPineappleTransform = new UnityEvent();
    public UnityEvent onCompletePineappleTransformation = new UnityEvent();

    [SerializeField] private Sprite[] pineapplePlayerSprites;

    [SerializeField] private int maxNumberToAsk;
    public int maxNumToAsk => maxNumberToAsk;

    private int                  currentAskedAmount=0;
    private Image                imageComponent;

    // Use this for initialization
    private void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    public void TurnToPineapple()
    {
        if (currentAskedAmount >= maxNumberToAsk) return;

        currentAskedAmount += 1;
        this.imageComponent.sprite = pineapplePlayerSprites[currentAskedAmount-1];
        onPineappleTransform.Invoke();

        if (currentAskedAmount == maxNumberToAsk)
        {

            onCompletePineappleTransformation.Invoke();
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }
}


