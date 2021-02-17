using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.Events;

public class PineappleTransformer : MonoBehaviour
{
    public UnityEvent onPineappleTransform = new UnityEvent();

    [SerializeField] private int MaxNumberToAsk;

    private int    currentAskedAmount=0;
    public string  spriteSheetName;
    private string loadedSpriteSheetName;

    private Dictionary<string, Sprite> spriteSheet;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        spriteRenderer.sprite = spriteSheet[this.spriteRenderer.sprite.name];
    }

    private void ChangeSpriteSheet()
    {
        //Change resources to something else later
        var sprites = Resources.LoadAll<Sprite>(this.spriteSheetName);
       // var sprites = (Sprite[])AssetDatabase.LoadAllAssetsAtPath("Assets/Sprites/Player/Character_Pina_PinaRunning.png");
        this.spriteSheet = sprites.ToDictionary(x => x.name, x => x);
        this.loadedSpriteSheetName = this.spriteSheetName;
    }

    public void TurnToPineapple()
    {
        Debug.Log("GAME OVER");
        if (currentAskedAmount < MaxNumberToAsk)
        {
            currentAskedAmount += 1;
            return;
        }
        else
        {
            this.ChangeSpriteSheet();
            onPineappleTransform.Invoke();
        }
    }
}


