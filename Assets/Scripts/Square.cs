using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Square : MonoBehaviour
{
    public bool IsOccupied {  get; private set; }
    public Piece OccupyingPiece { get; private set; }
    private bool isHovering = false;
    public GameManager gameManager;

    // for highlighting 
    private Material originalMaterial;
    public Material outlineMaterial;
    private Renderer squareRenderer;

    // for saving board placement
    public int row;
    public int col;

    void Start()
    {
        squareRenderer = GetComponent<Renderer>();
        originalMaterial = squareRenderer.material;
    }

    void Update()
    {
        if (gameManager.selectedPiece != null)
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
        IsOccupied = true;
        OccupyingPiece = piece;
    }

    public void RemovePiece()
    {
        IsOccupied = false;
        OccupyingPiece = null;
    }

    public void OnMouseDown()
    {
        if (!gameManager.isEnd)
        {
            Debug.Log("PLACEMENT Click: " + gameObject.name);
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

    public void OnMouseExit() // when you stop hovering
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
