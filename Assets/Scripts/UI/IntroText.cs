using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroText : MonoBehaviour
{
    [SerializeField] List<string> _introTextParts = new List<string>();
    [SerializeField] TextMeshProUGUI _introText;
    [SerializeField] private bool _baseOnTime = false;
    public int currentTextPart = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (_baseOnTime)
        {
            StartCoroutine(ChangeText());
        }
    }

    private void Update()
    {
        if (currentTextPart < _introTextParts.Count)
        {
            _introText.text = _introTextParts[currentTextPart];
        }
    }

    private IEnumerator ChangeText()
    {
        while (currentTextPart < _introTextParts.Count)
        {
            float showTime = _introTextParts[currentTextPart].Length * 0.2f;

            yield return new WaitForSeconds(showTime);
            currentTextPart++;
        }
    }
}
