//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BoardManager : MonoBehaviour
//{
//    public static bool isPieceSelected = false;
//    public static bool isPlacementSelected = false;
//    public static GameObject selectedPiece = null;
//    public static GameObject selectedPlacement = null;

//    public static bool turn = false; // false for X, true for O
//    public static GameObject[] placements = new GameObject[9];
//    public static GameObject[] pieces = new GameObject[9];

//    private float speed = 30f;

//    void Start()
//    {
//        for (int i = 0; i < 9; i++)
//        {
//            placements[i] = GameObject.Find("Plane (" + (i + 1) + ")");
//        }
//    }

//    public void MovePiece() // moves selected Piece to center of selected Placement
//    {
//        selectedPiece.GetComponent<SelectPiece>().SetMoved(true);
//        int index = Array.IndexOf(placements, selectedPlacement);
//        pieces[index] = selectedPiece;
//        StartCoroutine(MovePieceCoroutine());
//    }
//    private IEnumerator MovePieceCoroutine()
//    {
//        Vector3 startPosition = selectedPiece.transform.position;
//        Vector3 targetPosition = selectedPlacement.transform.position;
//        targetPosition.y += 2f;

//        float journeyLength = Vector3.Distance(startPosition, targetPosition);
//        float startTime = Time.time;

//        while (Time.time < startTime + (journeyLength / speed))
//        {
//            float fractionOfJourney = (Time.time - startTime) / (journeyLength / speed);
//            selectedPiece.transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
//            yield return null;
//        }

//        selectedPiece.transform.position = targetPosition;

//        // whyyyyy does this break the game?? find another way to reset material? 
//        //selectedPiece = null;
//        //selectedPlacement = null;
//        //isPieceSelected = false;
//        //isPlacementSelected = false;
//    }
//}
