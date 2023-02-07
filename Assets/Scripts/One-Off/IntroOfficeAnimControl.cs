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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && allowedToCallPatient)
        {
            ChangePatient();
            patients[patientNumber].SetActive(false);
        }
    }

    public void ChangePatient()
    {
        patientNumber++;
        anim.SetInteger("PatientNumber", patientNumber);
    }

    public void ChangeScene()
    {
        sceneNumber++;
        SceneManager.LoadScene(sceneNumber);
    }
}
