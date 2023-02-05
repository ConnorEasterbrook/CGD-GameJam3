using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headbob : MonoBehaviour
{
    public float bobingamount = 0.05f;
    public PlayerScript controller;

    float timer = 0;
    float defulty = 0;
    private float walkingBobbingSpeed = 5.0f;

    [SerializeField] float smooth;
    [SerializeField] float swaymulti;

    // Start is called before the first frame update
    void Start()
    {
        defulty = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(controller.velocity.x) > 0.1f || Mathf.Abs(controller.velocity.z) > 0.1f)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defulty + Mathf.Sin(timer) * bobingamount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defulty, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }

        //float mouseX = Input.GetAxisRaw("Mouse X") * swaymulti;
        //float mouseY = Input.GetAxisRaw("Mouse Y") * swaymulti;

        //Quaternion rotationX = Quaternion.AngleAxis(-mouseX, Vector3.right);
        //Quaternion rotationY = Quaternion.AngleAxis(mouseY, Vector3.up);

        //Quaternion targetRotation = rotationX * rotationY;

        //transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

}
