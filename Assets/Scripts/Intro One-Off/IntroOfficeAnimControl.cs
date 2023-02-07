using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroOfficeAnimControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] patients;
    private static int patientNumber = -1;
    private static int sceneNumber = 0;
    public bool allowedToCallPatient = false;

    [SerializeField] private int _DEBUGPATIENTCHOICE = -1;

    // Update is called once per frame
    void Update()
    {
        if (patientNumber != _DEBUGPATIENTCHOICE)
        {
            patientNumber = _DEBUGPATIENTCHOICE;
            sceneNumber = _DEBUGPATIENTCHOICE + 1;
        }
    }

    public void ChangePatient()
    {
        patientNumber++;
        anim.SetInteger("PatientNumber", patientNumber);
        patients[patientNumber].SetActive(false);
        allowedToCallPatient = false;
    }

    public void ChangeScene()
    {
        sceneNumber++;
        SceneManager.LoadScene(sceneNumber);
    }

    public int GetPatientNumber()
    {
        return patientNumber;
    }
}
