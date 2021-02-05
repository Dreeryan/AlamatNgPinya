using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WateringButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] 
    private UnityEvent onLeftPointerDown;
    [SerializeField]
    private UnityEvent onLeftPointerUp;
    [SerializeField]
    private UnityEvent onPointerEnter;
    [SerializeField]
    private UnityEvent onPointerExit;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) onLeftPointerDown.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) onLeftPointerUp.Invoke();
    }

    public void OnPointerEnter(PointerEventData eventData) { onPointerEnter.Invoke(); }

    public void OnPointerExit(PointerEventData eventData) { onPointerExit.Invoke(); }
}
