using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // for lifting up/down
    private float hoverAmount = 1.6f;
    private float hoverSpeed = 5f;
    private Vector3 initialPosition;
    private bool isHovering = false;

    // for highlighting 
    private Material originalMaterial;
    public Material outlineMaterial;
    private Renderer renderer;

    // for selecting object
    private float clickHoverAmount = 2.4f;
    private bool isSelected = false;
    private static EventClick currentlySelectedObject = null;
    public GameObject nextScriptObject;

    void Start()
    {
        initialPosition = transform.position;
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    public void OnPointerClick(PointerEventData eventData) // check is object is clicked
    {
        Debug.Log("Pointer Click " + gameObject.name);
        if (!isSelected) 
        {
            if (currentlySelectedObject != null && currentlySelectedObject != this) // reset any currently selected
            {
                currentlySelectedObject.ResetPosition();
                currentlySelectedObject.isSelected = false;
            }
            currentlySelectedObject = this;

            isSelected = true;
            ClickHover(); // highlight selected
            NavigateToSelected(); // go to choosing place on the board
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // when you hover over object
    {
        if(!isSelected)
        {
            Debug.Log("Pointer Enter " + gameObject.name);
            isHovering = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // when you stop hovering
    {
        if(!isSelected)
        {
            Debug.Log("Pointer Exit " + gameObject.name);
            isHovering = false;
        }
    }

    void Update()
    {
        if(!isSelected) // update object position/color is they are selected/hovering
        {
            if (isHovering)
            {
                Hover();
            }
            else
            {
                ResetPosition();
            }
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // reset selected is clicked outside object
        {
            // Check if mouse is clicked outside of any object
            if (currentlySelectedObject != null)
            {
                currentlySelectedObject.ResetPosition();
                currentlySelectedObject.isSelected = false;
                currentlySelectedObject = null;
            }
        }
    }

    void Hover()
    {
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + hoverAmount, initialPosition.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
    }

    void ResetPosition()
    {
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
        renderer.material = originalMaterial;
        isHovering = false;
    }

    void ClickHover()
    {
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + clickHoverAmount, initialPosition.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
        renderer.material = outlineMaterial; // will NOT work for 'X' until it is one entity (make 3d content later)
    }

    void NavigateToSelected()
    {
        Debug.Log("going to the next script -- selecting where to place X/O");
        if (nextScriptObject != null)
        {
            //nextScriptObject.GetComponent<NextScript>().NextAction(gameObject);
        }
    }
}

