using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porridge : MonoBehaviour
{
	//A: Please follow the enum format in the code standards. This is dangerous
    public enum CookState
    {
        Uncooked, Undercooked, Cooked
    }

    public CookState CurrentState;

    [SerializeField] private Pot pot;
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
			//A: Null check the rd
            if (porridgeTemp < pot.uncookedTemp)
            {
                CurrentState = CookState.Uncooked;
                rd.material.color = Color.white;
            }
            else if (porridgeTemp < pot.undercookedTemp)
            {
                CurrentState = CookState.Undercooked;
				//A: Make this a variable design can adjust
                rd.material.color = new Color32(229, 229, 229, 255);
            }
            else if (porridgeTemp < pot.cookedTemp)
            {
                CurrentState = CookState.Cooked;
				//A: Make this a variable design can adjust
                rd.material.color = new Color32(234, 222, 201, 255);
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
