using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatScript : MonoBehaviour
{
    [SerializeField] private IntroOfficeAnimControl _introOfficeAnimControl;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private List<GameObject> _chatters = new List<GameObject>();
    private bool _isChatting = false;
    private int _currentChatter = 0;
    private ChatBits currentChatter;

    // Update is called once per frame
    void Update()
    {
        _currentChatter = _introOfficeAnimControl.GetPatientNumber() + 1;
        currentChatter = _chatters[_currentChatter].GetComponent<ChatBits>();

        if (_canvas.activeSelf == false)
        {
            _canvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_isChatting)
            {
                _introOfficeAnimControl.ChangePatient();
                _isChatting = true;
            }
            else
            {
                CheckChatState();
            }
        }
    }

    private void CheckChatState()
    {
        if (currentChatter.DoneChatting())
        {
            _isChatting = false;
            _introOfficeAnimControl.ChangeScene();
            _currentChatter++;
        }
        else
        {
            currentChatter.currentTextBit++;
        }
    }
}
