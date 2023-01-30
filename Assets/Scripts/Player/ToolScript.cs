using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    [SerializeField] private Animator[] _animators;
    [SerializeField] private GameObject[] _tools;
    private int _currentToolSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        _tools[_currentToolSelected].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the left click, swing the tool
        if (Input.GetMouseButtonDown(0))
        {
            _animators[_currentToolSelected].SetBool("Attack", true);

            // When the animation is done, set the bool back to false
            StartCoroutine(ResetAttackBool());
        }

        if (_tools.Length > 1)
        {
            // If the player presses the 1 key, select the first tool
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _tools[_currentToolSelected].SetActive(false);
                _currentToolSelected = 0;
                _tools[_currentToolSelected].SetActive(true);
            }

            // If the player presses the 2 key, select the second tool
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _tools[_currentToolSelected].SetActive(false);
                _currentToolSelected = 1;
                _tools[_currentToolSelected].SetActive(true);
            }
        }
    }

    // When the animation is done, set the bool back to false
    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.75f);
        _animators[_currentToolSelected].SetBool("Attack", false);
    }
}
