using PlayerControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _tools;
    [SerializeField] private GameObject[] _toolsUISelection;
    [SerializeField] private int _animatorCount = 0;
    [SerializeField] private int _placementToolPosition = 0;
    private Animator[] _animators;
    private WeaponAttack[] _weaponAttackScripts;
    private int _currentToolSelected = 0;
    [SerializeField] AudioSource swingSound;

    // Start is called before the first frame update
    void Start()
    {
        _tools[_currentToolSelected].SetActive(true);
        _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();

        _animators = new Animator[_tools.Length];
        _weaponAttackScripts = new WeaponAttack[_tools.Length];

        for (int i = 0; i < _animatorCount; i++)
        {
            _animators[i] = _tools[i].GetComponent<Animator>();
            _weaponAttackScripts[i] = _tools[i].GetComponent<WeaponAttack>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.GameIsPaused)
        {
            return;
        }

        // If the player presses the left click, swing the tool
        if (Input.GetMouseButton(0) && AnimationComplete() && !PlayerScript.playerDisabled)
        {
            if (_currentToolSelected < _animatorCount)
            {
                swingSound.Play();
                _animators[_currentToolSelected].SetBool("Attack", true);

                if (_weaponAttackScripts[_currentToolSelected].isInContact)
                {
                    _weaponAttackScripts[_currentToolSelected].isAttacking = true;
                }

                // When the animation is done, set the bool back to false
                StartCoroutine(ResetAttackBool());
            }
        }

        if (_tools.Length > 1)
        {
            // If the player presses the 1 key, select the first tool
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _tools[_currentToolSelected].SetActive(false);
                _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
                _currentToolSelected = 0;
                _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
                _tools[_currentToolSelected].SetActive(true);
            }

            // If the player presses the 2 key, select the second tool
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _tools[_currentToolSelected].SetActive(false);
                _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
                _currentToolSelected = 1;
                _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
                _tools[_currentToolSelected].SetActive(true);
            }

            if (_tools.Length >= _placementToolPosition)
            {
                PlacementTools();
            }
        }
    }

    private void PlacementTools()
    {
        // If the player presses the 3 key, select the third tool
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _tools[_currentToolSelected].SetActive(false);
            _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
            _currentToolSelected = 2;
            _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
            _tools[_currentToolSelected].SetActive(true);
        }
        // If the player presses the 4 key, select the fourth tool
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _tools[_currentToolSelected].SetActive(false);
            _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
            _currentToolSelected = 3;
            _toolsUISelection[_currentToolSelected].GetComponent<ButtonHighlight>().SwapColour();
            _tools[_currentToolSelected].SetActive(true);
        }
    }

    private bool AnimationComplete()
    {
        if (_animators[_currentToolSelected] == null)
        {
            return false;
        }

        if (!_animators[_currentToolSelected].GetBool("Attack"))
        {
            return true;
        }

        return false;
    }

    // When the animation is done, set the bool back to false
    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.75f);
        if(_animators[_currentToolSelected] != null)
        {
            _animators[_currentToolSelected].SetBool("Attack", false);
        }
    }
}
