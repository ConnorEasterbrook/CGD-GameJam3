using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBits : MonoBehaviour
{
    [SerializeField] List<string> _textBits = new List<string>();
    [SerializeField] TextMeshProUGUI _text;
    public int currentTextBit = -1;

    private void Update()
    {
        if (currentTextBit < _textBits.Count)
        {
            _text.text = _textBits[currentTextBit];
        }
    }

    public bool DoneChatting()
    {
        if (currentTextBit >= _textBits.Count - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
