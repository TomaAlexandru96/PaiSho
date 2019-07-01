using System;
using System.Collections.Generic;
using UnityEngine;

// this should be model class
public class Game
{
    public Piece[,] cachedPositions;
    private readonly List<Piece> pieces;

    public Colour PlayerColour
    {
        get; private set;
    }

    public Colour OpponentColour
    {
        get
        {
            return PlayerColour == Colour.White ? Colour.Black : Colour.White;
        }
    }

    public Game(Colour playerColour)
    {
        PlayerColour = playerColour;
        pieces = new List<Piece>();
        cachedPositions = new Piece[18, 18];
    }

    public Piece PlacePiece(Type pieceType, Colour playerColour, Vector2Int position)
    {
        Piece piece = Activator.CreateInstance(pieceType, new object[] { this, playerColour, position }) as Piece;
        pieces.Add(piece);
        cachedPositions[position.y, position.x] = piece;
        return piece;
    }

    public void HandleMove(Piece piece, Vector2Int oldPos)
    {
        cachedPositions[oldPos.y, oldPos.x] = null;
        cachedPositions[piece.Position.y, piece.Position.x] = piece;
    }

    public void HandleCapture(Piece capturingPiece, Piece capturedPiece, Vector2Int oldPos)
    {
        RemovePiece(capturedPiece);
        HandleMove(capturedPiece, oldPos);
    }

    private void RemovePiece(Piece piece)
    {
        pieces.Remove(piece);
    }
}
