using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroOfficeAnimControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] patients;
    [SerializeField] private int patientNumber = -1;
    private int sceneNumber = 0;
    public bool allowedToCallPatient = false;
    public GameObject menuUI;
    public bool isIntro = true;

    [SerializeField] private int _DEBUGPATIENTCHOICE = -1;

    // Update is called once per frame
    void Update()
    {
       // if (patientNumber != _DEBUGPATIENTCHOICE)
    //    {
      //      patientNumber = _DEBUGPATIENTCHOICE;
      //      sceneNumber = _DEBUGPATIENTCHOICE + 1;
      //  }
    }

    public void ChangePatient(int patient)
    {
        patientNumber = patient;
        anim.SetInteger("PatientNumber", patientNumber);
        patients[patientNumber].SetActive(true);
        allowedToCallPatient = false;
    }

    public void ChangeScene(int scene)
    {
        isIntro = false;
        sceneNumber = scene;
        SceneManager.LoadScene(sceneNumber + 1);
    }

    public int GetPatientNumber()
    {
        return patientNumber;
    }

    public bool GetIsIntro()
    {
        return isIntro;
    }
}
