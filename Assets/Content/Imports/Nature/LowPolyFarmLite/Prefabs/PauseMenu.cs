using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace PlayerControllers
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool GameIsPaused = false;
        //bool for if the game is paused
        public bool _MainGameIsPaused;
        //insert options menu scene here
        [SerializeField] GameObject _Resumebutton, _Backbutton;

        [SerializeField] private PlayerScript _inputs;

        //pause menu getter so it can be activated and deactivated
        public GameObject _PauseMenuUI;
        [SerializeField] private GameObject _GUIMenuUI;
        [SerializeField] private GameObject _optionsUI;

        //[SerializeField] GameObject playerInteraction;

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //button to open or close pause menu
            if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 9")) && _optionsUI.activeSelf == false)
            {
                _inputs = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerScript>();
                if (_MainGameIsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }

            GameIsPaused = _MainGameIsPaused;
        }
        //pauses time and sets the pause menu to be deactive
        public void ResumeGame()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Game Resume");
            _PauseMenuUI.SetActive(false);
            _GUIMenuUI.SetActive(true);
            Time.timeScale = 1f;
            _MainGameIsPaused = false;
            if (_inputs != null)
            {
                _inputs.enabled = true;
            }
            //playerInteraction.SetActive(true);
        }
        //pauses time and sets the pause menu to be active
        private void PauseGame()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_Resumebutton);
            _PauseMenuUI.SetActive(true);
            _GUIMenuUI.SetActive(false);
            Time.timeScale = 0f;
            _MainGameIsPaused = true;
            if (_inputs != null)
            {
                _inputs.enabled = false;
            }
            //playerInteraction.SetActive(false);
        }

        //sets the options menu to active
        public void OpenOptionsMenu()
        {
            Debug.Log("Options Open");
            _optionsUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(_Backbutton);
            _PauseMenuUI.SetActive(false);
        }

        //loads the main menu scene
        public void GoToMainMenu()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1f;
            SceneManager.LoadScene("Core Screen");
        }

        //exits the applicaton
        public void ExitGame()
        {
            Debug.Log("Game Exit");
            Application.Quit();
        }
    }
}
