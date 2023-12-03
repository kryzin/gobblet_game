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
    private Renderer pieceRenderer;

    // cant move if its already been moved
    public bool isUsed = false;


    void Start()
    {
        initialPosition = transform.position;
        pieceRenderer = GetComponent<Renderer>();
        originalMaterial = pieceRenderer.material;
    }

    void Update()
    {
        if (gameManager.currentPlayer == PlayerColor.Red && color == PlayerColor.Red && !isUsed ||
        gameManager.currentPlayer == PlayerColor.Blue && color == PlayerColor.Blue && !isUsed) // apply lifting/highlighting only if its currentTurn color
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

    public void OnMouseDown()
    {
        //if (!gameManager.isEnd && gameManager.canSelect) // canSelect just to minimize objects running into each other
        if (!gameManager.isEnd)
        {
            if (!isUsed && color == gameManager.currentPlayer) // only interact with currentTurn color
            {
                if (gameManager.selectedPiece != null && gameManager.selectedPiece != this)
                {
                    gameManager.selectedPiece.isSelected = false;
                    gameManager.selectedPiece.ResetSelection();
                    gameManager.DeselectPiece();
                }
                // Debug.Log("Click " + gameObject.name);
                isSelected = true;
                gameManager.SelectPiece(this);
                ClickHover();
            }
        }
    }

    public void OnMouseEnter()
    {
        //if (!isUsed && !gameManager.isEnd && gameManager.canSelect)
        if (!isUsed && !gameManager.isEnd)
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
        //else if (!isUsed && !gameManager.isEnd && gameManager.canSelect)
        else if (!isUsed && !gameManager.isEnd)
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
        pieceRenderer.material = originalMaterial;
        isHovering = false;
    }

    void ClickHover()
    {
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + clickHoverAmount, initialPosition.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * hoverSpeed);
        pieceRenderer.material = outlineMaterial;
    }

    public void ResetSelection()
    {
        pieceRenderer.material = originalMaterial;
        ResetPosition();
    }
}
