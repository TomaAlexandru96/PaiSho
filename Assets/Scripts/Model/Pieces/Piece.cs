using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public readonly Colour colour;
    private readonly Game game;
    private Vector2Int position;

    public Vector2Int Position
    {
        get
        {
            return position;
        }
    }

    public Piece(Game game, Colour colour, Vector2Int position)
    {
        this.colour = colour;
        this.game = game;
        this.position = position;
    }

    public virtual List<Vector2Int> GetPossibleMoves()
    {
        return new List<Vector2Int>();
    }

    public bool Move(Vector2Int to)
    {
        Vector2Int oldPosition = position;
        position = to;
        game.HandleMove(this, oldPosition);
        return true;
    }

    public bool Capture(Piece piece)
    {
        Vector2Int oldPosition = position;
        position = piece.position;
        game.HandleCapture(this, piece, oldPosition);
        return false;
    }
}
