using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Piece[,] board = new Piece[3, 3];
    public GameManager gameManager;

    void Update()
    {
        if (IsGameOver())
        {
            Debug.Log("GAME OVER");
        }
    }

    public void InitializeBoard()
    {
        Debug.Log("starting game");
        for (int i = 0; i < 3; i++) // resetting board state
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = null;
            }
        }
    }

    public void PlacePiece(Piece piece, Square square)
    {
        int row = square.row;
        int col = square.col;

        board[row, col] = piece;
    }

    public bool IsGameOver()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != null && board[i, 1] != null && board[i, 2] != null &&
                board[i, 0].color == board[i, 1].color && board[i, 1].color == board[i, 2].color)
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] != null && board[1, i] != null && board[2, i] != null &&
                board[0, i].color == board[1, i].color && board[1, i].color == board[2, i].color)
            {
                return true;
            }
        }

        // Check main diagonal
        if (board[0, 0] != null && board[1, 1] != null && board[2, 2] != null &&
            board[0, 0].color == board[1, 1].color && board[1, 1].color == board[2, 2].color)
        {
            return true;
        }

        // Check anti-diagonal
        if (board[0, 2] != null && board[1, 1] != null && board[2, 0] != null &&
            board[0, 2].color == board[1, 1].color && board[1, 1].color == board[2, 0].color)
        {
            return true;
        }

        return false;
    }
}
