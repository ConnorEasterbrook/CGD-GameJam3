using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlight : MonoBehaviour
{
    private Color _originalColor;
    [SerializeField] private Color _highlightColor;

    // Start is called before the first frame update
    void Start()
    {
        _originalColor = GetComponentInChildren<Image>().color;
    }

    public void SwapColour()
    {
        if (GetComponent<Image>().color == _originalColor)
        {
            GetComponent<Image>().color = _highlightColor;
        }
        else
        {
            GetComponent<Image>().color = _originalColor;
        }
    }
}
