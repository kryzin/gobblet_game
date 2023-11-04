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
        selectedPiece = null;
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
        //Vector3 startingPosition = selectedPiece.transform.position;
        Vector3 targetPosition = selectedSquare.transform.position;
        targetPosition.y += 2f;

        //selectedPiece.transform.position = Vector3.Lerp(startingPosition, targetPosition, Time.deltaTime * speed);
        selectedPiece.transform.position = targetPosition;
        Debug.Log("move made");
    }
}
