using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum PlayerColor { Red, Blue };
    public Board board;

    public PlayerColor currentPlayer;
    public Piece selectedPiece;
    public Square selectedSquare;
    private float speed = 3f;

    void Start()
    {
        Debug.Log("Player Red starts");
        board.InitializeBoard();
        currentPlayer = PlayerColor.Red; // red starts the game
    }

    void Update()
    {
        if (selectedPiece != null)
        {
            if (selectedSquare != null)
            {
                if (IsValidMove(selectedPiece, selectedSquare)) // you can make the move
                {
                    board.PlacePiece(selectedPiece, selectedSquare);
                    selectedSquare.PlacePiece(selectedPiece);
                    selectedPiece.PlacePiece();
                    MovePiece();
                    SwitchTurn();
                }
            }
        }
    }

    public void SelectPiece(Piece piece)
    {
        selectedPiece = piece;
    }

    public void DeselectPiece()
    {
        selectedPiece = null;
    }

    public void SelectSquare(Square square)
    {
        selectedSquare = square;
    }

    public void SwitchTurn()
    {
        if (currentPlayer == PlayerColor.Red)
        {
            currentPlayer = PlayerColor.Blue;
        }
        else
        {
            currentPlayer = PlayerColor.Red;
        }

        
        // resetting all selections
        selectedSquare.ResetSelection();
        selectedPiece.ResetSelection();
        DeselectPiece();
        selectedSquare = null;
    }

    public bool IsValidMove(Piece piece, Square square)
    {
        if (!square.IsOccupied)
        {
            return true;
        }
        else if (piece.size > square.OccupyingPiece.size)
        {
            return true;
        }
        return false;
    }

    public void MovePiece() // moves selected Piece to center of selected Square
    {
        StartCoroutine(MovePieceCoroutine(selectedPiece, selectedSquare));
        //Vector3 startingPosition = selectedPiece.transform.position;
        //Vector3 targetPosition = selectedSquare.transform.position;
        //targetPosition.y += 2f;

        //selectedPiece.transform.position = Vector3.Lerp(startingPosition, targetPosition, Time.deltaTime * speed);
        //selectedPiece.transform.position = targetPosition;
        //Debug.Log("move made");
    }

    public IEnumerator MovePieceCoroutine(Piece piece, Square square)
    {
        Vector3 startingPosition = piece.transform.position;
        Vector3 targetPosition = new Vector3(square.transform.position.x, square.transform.position.y + 2f, square.transform.position.z);
        targetPosition.y += 2f;
        float elapsedTime = 0f;
        float duration = 1f;

        while (elapsedTime < duration)
        {
            piece.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        piece.transform.position = targetPosition;
        
        //selectedPiece.transform.position = targetPosition;
        Debug.Log("move made");
    }
}
