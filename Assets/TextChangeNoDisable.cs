using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChangeNoDisable : MonoBehaviour
{
    public bool isnext = false;
    public float time = 10f;
    public bool replay;
    // Start is called before the first frame update
    void Start()
    {
        //Text = GetComponent<TextMeshPro>();
        StartCoroutine(FadeFull(time, GetComponent<TextMeshProUGUI>(), gameObject));
    }

    public IEnumerator FadeFull(float t, TextMeshProUGUI text, GameObject Text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }

    }
}
