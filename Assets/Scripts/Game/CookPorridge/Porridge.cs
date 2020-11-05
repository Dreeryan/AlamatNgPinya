using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porridge : MonoBehaviour
{
    public enum CookState
    {
        Uncooked, Undercooked, Cooked, Burned
    }

    public CookState CurrentState;

    [SerializeField] Pot pot;
    [SerializeField] public float porridgeTemp;

    private Renderer rd;
    private bool isCooking;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Renderer>();
        CurrentState = CookState.Uncooked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking)
        {
            if (porridgeTemp < pot.uncookedTemp)
            {
                CurrentState = CookState.Uncooked;
                rd.material.color = Color.white;
            }
            else if (porridgeTemp < pot.undercookedTemp)
            {
                CurrentState = CookState.Undercooked;
                rd.material.color = new Color32(229, 229, 229, 255);
            }
            else if (porridgeTemp < pot.cookedTemp)
            {
                CurrentState = CookState.Cooked;
                rd.material.color = new Color32(234, 222, 201, 255);
            }
            else if (porridgeTemp < pot.burnedTemp)
            {
                CurrentState = CookState.Burned;
                rd.material.color = new Color32(246, 206, 131, 255);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            isCooking = true;
            pot = collision.gameObject.GetComponent<Pot>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {
            isCooking = false;
        }
    }
}
