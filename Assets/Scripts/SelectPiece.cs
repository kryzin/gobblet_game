using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPiece : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // for lifting up/down
    private float hoverAmount = 2.6f;
    private float hoverSpeed = 3f;
    private Vector3 initialPosition;
    private bool isHovering = false;

    // for highlighting 
    private Material originalMaterial;
    public Material outlineMaterial;
    private Renderer renderer;

    // for selecting object
    private float clickHoverAmount = 2.4f;
    public bool hasMoved = false;

    void Start()
    {
        initialPosition = transform.position;
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    public void OnPointerClick(PointerEventData eventData) // check is object is clicked
    {
        Debug.Log("Pointer Click " + gameObject.name);
        if (!BoardManager.isPieceSelected && !hasMoved) 
        {
            if (BoardManager.selectedPiece != null && BoardManager.selectedPiece != this) // reset any currently selected
            {
                BoardManager.selectedPiece.GetComponent<SelectPiece>().ResetPosition();
                BoardManager.isPieceSelected = false;
            }
            BoardManager.selectedPiece = gameObject;
            BoardManager.isPieceSelected = true;
            ClickHover(); // highlight selected
        }
    }

    public void OnPointerEnter(PointerEventData eventData) // when you hover over object
    {
        if(!BoardManager.isPieceSelected && !hasMoved)
        {
            Debug.Log("Pointer Enter " + gameObject.name);
            isHovering = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // when you stop hovering
    {
        if(!BoardManager.isPieceSelected)
        {
            Debug.Log("Pointer Exit " + gameObject.name);
            isHovering = false;
        }
    }

    void Update()
    {
        if(!BoardManager.isPieceSelected) // update object position/color is they are selected/hovering
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
            if (BoardManager.selectedPiece != null)
            {
                BoardManager.selectedPiece.GetComponent<SelectPiece>().ResetPosition();
                BoardManager.isPieceSelected = false;
                BoardManager.selectedPiece = null;
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
        if (!hasMoved)
        {
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
        }
        
        renderer.material = originalMaterial;
        isHovering = false;
    }

    void ClickHover()
    {
        if (!hasMoved)
        {
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + clickHoverAmount, initialPosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
        }
        
        renderer.material = outlineMaterial; 
    }

    public void SetMoved(bool moved)
    {
        hasMoved = moved;
    }
}

