using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoDisplayPiece : MonoBehaviour
{
    public UIInfoDisplay infoDisplay;
    public GameObject whiteOutline;
    public GameObject blackOutline;

    public void SetColour(Colour colour)
    {
        whiteOutline.SetActive(colour == Colour.White);
        blackOutline.SetActive(colour != Colour.White);
    }

    public void HandleToggle(bool value)
    {
        if (!infoDisplay)
        {
            return;
        }
        infoDisplay.HandleToggle(value, this);
    }
}
