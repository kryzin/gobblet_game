//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class SelectPlacement : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
//{
//    private bool isHovering = false;

//    // for highlighting 
//    private Material originalMaterial;
//    public Material outlineMaterial;
//    private Renderer renderer;

//    void Start()
//    {
//        renderer = GetComponent<Renderer>();
//        originalMaterial = renderer.material;
//    }

//    void Update()
//    {
//        if (BoardManager.isPieceSelected && !BoardManager.isPlacementSelected)
//        {
//            if (isHovering)
//            {
//                Hover();
//            }
//            else
//            {
//                ResetPosition();
//            }
//        }
//        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
//        {
//            if (BoardManager.selectedPlacement != null)
//            {
//                BoardManager.selectedPlacement.GetComponent<SelectPlacement>().ResetPosition();
//                BoardManager.isPlacementSelected = false;
//                BoardManager.selectedPlacement = null;
//            }
//        }
//    }

//    public void OnPointerClick(PointerEventData eventData)
//    {
//        Debug.Log("PLACEMENT clicked place: " + gameObject.name);

//        int index = Array.IndexOf(BoardManager.placements, gameObject);
//        Debug.Log(index);
//        if (BoardManager.pieces[index] == null) // checking if square is empty ++++++++++ add checking size here
//        {
//            if (!BoardManager.isPlacementSelected)
//            {
//                if (BoardManager.selectedPlacement != null && BoardManager.selectedPlacement != this)
//                {
//                    BoardManager.selectedPlacement.GetComponent<SelectPlacement>().ResetPosition();
//                    BoardManager.isPlacementSelected = false;
//                }
//                BoardManager.selectedPlacement = gameObject;
//                BoardManager.isPlacementSelected = true;
//                Debug.Log("now the object moves to: " + gameObject.name);
//                BoardManager boardManager = FindObjectOfType<BoardManager>();
//                boardManager.MovePiece();
//            }
//        }
//        // add else where maybe placement lights up red, or error message on screen, or reset selection completly
        
//    }
//    public void OnPointerEnter(PointerEventData eventData) // when you hover over object
//    {
//        Debug.Log("PLACEMENT Pointer Enter " + gameObject.name);
//        if(!BoardManager.isPlacementSelected)
//        {
//            isHovering = true;
//        }
//    }

//    public void OnPointerExit(PointerEventData eventData) // when you stop hovering
//    {
//        Debug.Log("PLACEMENT Pointer Exit " + gameObject.name);
//        if (!BoardManager.isPlacementSelected)
//        {
//            isHovering = false;
//        }
//    }

//    void Hover()
//    {
//        renderer.material = outlineMaterial;
//    }

//    void ResetPosition()
//    {
//        renderer.material = originalMaterial;
//        isHovering = false;
//    }
//}
