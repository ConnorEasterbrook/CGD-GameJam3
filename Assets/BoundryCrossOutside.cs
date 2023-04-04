using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoundryCrossOutside : MonoBehaviour
{
    public GameObject Textobject;
    public GameObject StartPoint;
    public GameObject nexttextobj = null;
    public TextChangeNoDisable textChangeNoDisable;
    public float time = 6f;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Textobject)
        {
            nexttextobj.SetActive(true);
            Textobject.gameObject.transform.position = StartPoint.transform.position;
            //textChangeNoDisable.GetComponent<TextMeshProUGUI>().color.a 256; 
            StartCoroutine(FadeFull(time, textChangeNoDisable.GetComponent<TextMeshProUGUI>(), gameObject));
        }
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
