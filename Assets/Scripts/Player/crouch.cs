using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouch : MonoBehaviour
{
    public Camera playerCam;
    public bool crouching = false;
    private void Update()
    {
        if (Input.GetKeyUp("c"))
        {
            if (crouching)
            {
                playerCam.transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y + 0.8f, playerCam.transform.position.z);
                crouching = false;
            }
            else
            {
                playerCam.transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y - 0.8f, playerCam.transform.position.z);
                crouching = true;
            }
        }

        Debug.Log(crouching);
    }
}
