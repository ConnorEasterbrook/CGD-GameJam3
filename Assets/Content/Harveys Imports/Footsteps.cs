using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsound;
    public PlayerScript playerscript;

    // Update is called once per frame
    void Update()
    {
        if ((playerscript.velocity.x >= 1 || playerscript.velocity.z >= 1 || playerscript.velocity.x <= -1 || playerscript.velocity.z <= -1) && playerscript.fallingVelocity <= 0.5)
        {
            footstepsound.enabled = true;
        }
        else
        {
            footstepsound.enabled = false;
        }
    }

}
