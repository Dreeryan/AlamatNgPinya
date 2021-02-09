using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarryController : MonoBehaviour
{
    [SerializeField] private UnityEvent onToyPickedUp;
    [SerializeField] private UnityEvent onToyDropped;

    private Toy overlappedToy;
    private Toy carriedToy;
    
    [SerializeField] private ToyBin toyBin;

    [Header("Item Carrier")]
    [SerializeField] private Transform  itemCarrier;
    public Transform                    ItemCarrier => itemCarrier;

    [Header("UI")]
    [SerializeField] GameObject         itemText;

    private bool    isCarrying = false;
    public bool     IsCarrying => isCarrying;

    void Start()
    {
        if (itemText != null) itemText.gameObject.SetActive(false);
        if (toyBin == null) toyBin = FindObjectOfType<ToyBin>();
        if (toyBin != null) toyBin.onMinigameCompleted.AddListener(OnMinigameComplete);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isCarrying && collision.GetComponent<Toy>())
        {
            if (overlappedToy == null) overlappedToy = collision.GetComponent<Toy>();
            if (overlappedToy.WillBePickedUp) PickupToy();
            if (!itemText.activeSelf) itemText.SetActive(true);
        }

        if (isCarrying && collision.GetComponent<ToyBin>())
        {
            if (toyBin != null && toyBin.IsSelected) DropToy(toyBin);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Toy>() == overlappedToy)
        {
            itemText.gameObject.SetActive(false);
            overlappedToy = null;
        }
    }

    public void PickupToy()
    {
        isCarrying = true;
        carriedToy = overlappedToy;

        carriedToy.gameObject.transform.parent = itemCarrier;
        carriedToy.gameObject.transform.position = itemCarrier.position;

        itemText.gameObject.SetActive(false);

        onToyPickedUp?.Invoke();
    }

    void DropToy(ToyBin bin)
    {
        bin.PlaceToy(carriedToy);

        isCarrying = false;
        carriedToy = null;
        itemText.gameObject.SetActive(false);

        onToyDropped?.Invoke();
    }

    void OnMinigameComplete()
    {
        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null) controller.CanMove = false;
    }
}
