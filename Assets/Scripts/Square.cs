using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Square : MonoBehaviour
{
    public bool isOccupied = false;
    public Piece occupyingPiece = null;
    private bool isHovering = false;
    public GameManager gameManager;

    // for highlighting 
    private Material originalMaterial;
    public Material outlineMaterial;
    private Renderer squareRenderer;

    // for saving board placement - set in inspector
    public int row;
    public int col;

    void Start()
    {
        squareRenderer = GetComponent<Renderer>();
        originalMaterial = squareRenderer.material; // save for resetting after highlighting
    }

    void Update()
    {
        if (gameManager.selectedPiece != null) // only able to select Square after selecting a Piece
        {
            if (isHovering)
            {
                Hover();
            }
            else
            {
                ResetSelection();
            }
        }
    }

    public void PlacePiece(Piece piece)
    {
        isOccupied = true;
        occupyingPiece = piece;
    }

    public void RemovePiece()
    {
        isOccupied = false;
        occupyingPiece = null;
    }

    public void OnMouseDown()
    {
        if (!gameManager.isEnd) // block after end of game
        {
            gameManager.SelectSquare(this);
        }
    }
    public void OnMouseEnter()
    {
        if (gameManager.selectedSquare == null)
        {
            isHovering = true;
        }
    }

    public void OnMouseExit()
    {
        if (gameManager.selectedSquare == null)
        {
            isHovering = false;
        }
    }

    void Hover()
    {
        squareRenderer.material = outlineMaterial;
    }

    public void ResetSelection()
    {
        squareRenderer.material = originalMaterial;
        isHovering = false;
    }
}
