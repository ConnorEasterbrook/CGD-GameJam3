using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextNext : MonoBehaviour
{
    private TextChange Text;
    public GameObject nexttextobj = null;
    public GameObject Textobject;

    private void Start()
    {
        Text = GetComponent<TextChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nexttextobj != null)
        {
            if (Text.enabled == false)
            {
                nexttextobj.SetActive(true);
                enabled = false;
                Textobject.SetActive(false);
            }
        }
        else
        {
            enabled = false;
        }
    }
}
