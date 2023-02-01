using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _tools;
    private Animator[] _animators;
    private WeaponAttack[] _weaponAttackScripts;
    private int _currentToolSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        _tools[_currentToolSelected].SetActive(true);

        _animators = new Animator[_tools.Length];
        _weaponAttackScripts = new WeaponAttack[_tools.Length];

        for (int i = 0; i < _tools.Length; i--)
        {
            _animators[i] = _tools[i].GetComponent<Animator>();
            _weaponAttackScripts[i] = _tools[i].GetComponent<WeaponAttack>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the left click, swing the tool
        if (Input.GetMouseButtonDown(0))
        {
            _animators[_currentToolSelected].SetBool("Attack", true);
            _weaponAttackScripts[_currentToolSelected].isAttacking = true;

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
