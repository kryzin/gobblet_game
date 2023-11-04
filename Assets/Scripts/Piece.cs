using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static GameManager;

public class Piece : MonoBehaviour
{
    public enum Size { Small, Medium, Large };
    public GameManager gameManager;

    public Size size;
    public GameManager.PlayerColor color;

    // for lifting up/down
    private float hoverAmount = 2.6f;
    private float hoverSpeed = 3f;
    private Vector3 initialPosition;
    private bool isHovering = false;
    private bool isSelected = false;
    private float clickHoverAmount = 2.4f;

    // for highlighting 
    private Material originalMaterial;
    public Material outlineMaterial;
    private Renderer renderer;

    // for selecting
    public bool IsUsed {  get; private set; }


    void Start()
    {
        initialPosition = transform.position;
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
    }

    void Update()
    {
        if (gameManager.currentPlayer == PlayerColor.Red && color == PlayerColor.Red && !IsUsed ||
        gameManager.currentPlayer == PlayerColor.Blue && color == PlayerColor.Blue && !IsUsed)
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
    }

    public void PlacePiece()
    {
        IsUsed = true;
    }

    public void OnMouseDown()
    {
        if (!IsUsed)
        {
            Debug.Log("Click " + gameObject.name);
            isSelected = true;
            gameManager.SelectPiece(this);
            ClickHover();
        }    
    }

    public void OnMouseEnter()
    {
        if (!IsUsed)
        {
            isHovering = true;
        }
    }

    public void OnMouseExit()
    {
        if (!isSelected)
        {
            isHovering = false;
        }
        else if (!IsUsed)
        {
            ClickHover();
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

        renderer.material = outlineMaterial;
    }

    public void ResetSelection()
    {
        renderer.material = originalMaterial;
    }
}
