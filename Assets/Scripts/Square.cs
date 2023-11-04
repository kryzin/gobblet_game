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
    private Renderer renderer;

    // for saving board placement
    public int row;
    public int col;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
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
        Debug.Log("PLACEMENT Click: " + gameObject.name);
        gameManager.SelectSquare(this);
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
        renderer.material = outlineMaterial;
    }

    public void ResetSelection()
    {
        renderer.material = originalMaterial;
        isHovering = false;
    }
}
