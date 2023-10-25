using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    // maybe block the script after click, if you clicked = go to PlacingScript

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down " + gameObject.name);
        // highlight or raise O/X when clicked
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up " + gameObject.name);
        // go back to original material
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Pointer Click " + gameObject.name);
        // it's selected
        // go to Selecting Placement in Box from here
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer Enter " + gameObject.name);
        // slight highlight when "browsing" objects
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer Exit " + gameObject.name);
        // release highlight when not hovering over
    }
}
