using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPiece : MonoBehaviour
{
    public Material[] materials;
    private static readonly Type[] piecesClasses = new Type[]
    {
        typeof(Rose),
        typeof(Chrysanthemum),
        typeof(Rhododendron),
        typeof(Jasmine),
        typeof(Lily),
        typeof(WhiteJade),
        typeof(Wheel),
        typeof(Knotweed),
        typeof(Boat),
        typeof(Rock),
        typeof(Orchid),
        typeof(WhiteLotus),
    };
    private static readonly Dictionary<string, int> keyToIndex = new Dictionary<string, int>() 
    {
        {"Rose", 0},
        {"Chrysanthemum", 1},
        {"Rhododendron", 2},
        {"Jasmine", 3},
        {"Lily", 4},
        {"White Jade", 5},
        {"Wheel", 6},
        {"Knotweed", 7},
        {"Boat", 8},
        {"Rock", 9},
        {"Orchid", 10},
        {"White Lotus", 11}
    };

    public GameObject blackOutline;
    public GameObject whiteOutline;
    public GameController gameController;
    private Piece modelPiece;

    public void SetupPiece(string nm, GameController gc, Colour colour)
    {
        name = nm;
        gameController = gc;
        Colour = colour;

        Type pieceType = piecesClasses[keyToIndex[name]];
        modelPiece = gameController.game.PlacePiece(pieceType, Colour, new Vector2Int());
        SetBackground(materials[keyToIndex[name]]);
    }

    private void SetBackground(Material mat)
    {
        GetComponentInChildren<MeshRenderer>().material = mat;
    }

    public Colour Colour
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
}
