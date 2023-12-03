using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public enum PlayerColor { Red, Blue };
    public Board board;

    public PlayerColor currentPlayer;
    public Piece selectedPiece;
    public Square selectedSquare;

    public int scoreRed = 0;
    public int scoreBlue = 0;
    private bool checkOnce = false;
    public bool isEnd = false;

    void Start()
    {
        checkOnce = false;
        Debug.Log("Player Red starts");
        LoadScores();
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
        float sizeAdd;
        if (selectedPiece.size == Piece.Size.Small) sizeAdd = 6f;
        else if (selectedPiece.size == Piece.Size.Medium) sizeAdd = 9f;
        else sizeAdd = 15.5f;
        StartCoroutine(MovePieceCoroutine(selectedPiece, selectedSquare, sizeAdd));
        //Vector3 startingPosition = selectedPiece.transform.position;
        //Vector3 targetPosition = selectedSquare.transform.position;
        //targetPosition.y += 2f;

        //selectedPiece.transform.position = Vector3.Lerp(startingPosition, targetPosition, Time.deltaTime * speed);
        //selectedPiece.transform.position = targetPosition;
        //Debug.Log("move made");
        Rigidbody pieceRigidbody = selectedPiece.GetComponent<Rigidbody>();
        pieceRigidbody.isKinematic = true;
    }

    public IEnumerator MovePieceCoroutine(Piece piece, Square square, float sizeAdd)
    {
        Vector3 startingPosition = piece.transform.position;
        Vector3 targetPosition = new Vector3(square.transform.position.x, square.transform.position.y + sizeAdd, square.transform.position.z);
        float elapsedTime = 0f;
        float duration = 1f;

        Rigidbody pieceRigidbody = piece.GetComponent<Rigidbody>();
        pieceRigidbody.useGravity = false;

        while (elapsedTime < duration)
        {
            piece.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        pieceRigidbody.useGravity = true;
        pieceRigidbody.isKinematic = false;
        pieceRigidbody.MovePosition(targetPosition);

        
        
        //selectedPiece.transform.position = targetPosition;
        Debug.Log("move made");
    }

    public void GameOver()
    {
        isEnd = true;
        if (!checkOnce)
        {
            if (board.winner == PlayerColor.Red) scoreRed += 1;
            else scoreBlue += 1;
        }
        checkOnce = true;

        PlayerPrefs.SetInt("ScoreRed", scoreRed);
        PlayerPrefs.SetInt("ScoreBlue", scoreBlue);
        PlayerPrefs.Save();
        uiManager.StopTimer();
        uiManager.ShowPopUp();
    }

    void LoadScores()
    {
        scoreRed = PlayerPrefs.GetInt("ScoreRed", 0);
        scoreBlue = PlayerPrefs.GetInt("ScoreBlue", 0);
        PlayerPrefs.Save();
    }
}
