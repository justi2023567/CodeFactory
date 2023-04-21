using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 10;
    public bool playing = true;

    public Camera playerCamera;
    public float lookSpeed = 50f;
    public float lookXLimit = 45f;
    public float rotationX;
    public float rotationY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

        /*
        
        Jumping For Later
        
        if (Input.GetKeyDown("space"))
        {
            this.transform.position += Vector3.up * Time.deltaTime * 40;
        }

        */
        if (Input.GetKey("w"))
        {
            this.transform.position += Vector3.forward * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey("s"))
        {
            this.transform.position += Vector3.back * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey("a"))
        {
            this.transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey("d"))
        {
            this.transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }

        if (playing == true)
        {
            Cursor.lockState = CursorLockMode.Locked;

            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationY += Input.GetAxis("Mouse X") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            this.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
            this.transform.rotation *= Quaternion.Euler(this.transform.position.x, Input.GetAxis("Mouse X") * lookSpeed, this.transform.position.z);
        }
    }
}
