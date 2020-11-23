using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackHolder : MonoBehaviour
{
    [SerializeField] private CleanDish cleanDish;
    public BoxCollider2D bc;
    private bool isOccupied = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CleanDish"))
        {
            isOccupied = true;
            bc.enabled = false;
        }
    }
}
