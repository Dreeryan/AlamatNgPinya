using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class PineappleLifeUIManager : MonoBehaviour
{
    public UnityEvent onPineappleTransform = new UnityEvent();
    public UnityEvent onCompletePineappleTransformation = new UnityEvent();
    private PineappleLifeManager pineappleLifeManagerRef;
    [SerializeField] private Sprite[] pineapplePlayerSprites;

        

    [SerializeField]private Image imageComponent;

    // Use this for initialization
    private void Start()
    {
        pineappleLifeManagerRef = PineappleLifeManager.Instance;
    }

    private void OnEnable()
    {
        pineappleLifeManagerRef = PineappleLifeManager.Instance;
        if (pineappleLifeManagerRef.currentAskAmount <= 0) return;
        this.imageComponent.sprite = pineapplePlayerSprites[pineappleLifeManagerRef.currentAskAmount - 1];
    }

    //game over
    public void TurnToPineapple()
    {
        if (pineappleLifeManagerRef.currentAskAmount >= pineappleLifeManagerRef.maxAskAmount) return;
        pineappleLifeManagerRef.IncreaseAskAmount();
        //UI Logic
        this.imageComponent.sprite = pineapplePlayerSprites[pineappleLifeManagerRef.currentAskAmount - 1];
        onPineappleTransform.Invoke();

        //gameplay logic
        if (pineappleLifeManagerRef.currentAskAmount == pineappleLifeManagerRef.maxAskAmount)
        {

            onCompletePineappleTransformation.Invoke();
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
            pineappleLifeManagerRef.ResetAmount();
        }
    }
}


