using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mom : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEating;

    [SerializeField] Counter counter;
    // Start is called before the first frame update
    void Start()
    {
        if (counter == null) counter = FindObjectOfType<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Spoon>())
        {
            Spoon spoon = collision.GetComponent<Spoon>();
            if (spoon.IsSpoonFull)
            {
                spoon.EmptySpoon();
            }
            counter.IncreaseProgress();

            OnEating?.Invoke();
        }
    }
}
