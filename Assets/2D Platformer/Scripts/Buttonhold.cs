using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHoldHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onHoldStart;
    public UnityEvent onHoldEnd;

    private bool isHolding = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        onHoldStart.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isHolding)
        {
            isHolding = false;
            onHoldEnd.Invoke();
        }
    }
}