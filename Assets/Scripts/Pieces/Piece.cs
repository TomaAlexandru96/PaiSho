using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public enum Colour
    {
        Black, White
    }

    public GameObject blackOutline;
    public GameObject whiteOutline;

    public Colour PieceColour
    {
        get
        {
            return blackOutline.activeSelf ? Colour.Black : Colour.White;
        }

        set
        {
            blackOutline.SetActive(value == Colour.Black);
            whiteOutline.SetActive(value == Colour.White);
        }
    }

    public virtual List<Vector2Int> GetPossibleMoves()
    {
        return new List<Vector2Int>();
    }
}
