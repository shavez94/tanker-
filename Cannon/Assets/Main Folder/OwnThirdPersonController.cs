using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class OwnThirdPersonController : MonoBehaviour {


    public Joystick joystick;
    protected Rigidbody Rigidbody;

    public float speed;
    // Use this for initialization
    void Start ()
    {
        Rigidbody = GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update () {

        Rigidbody.velocity = new Vector3(joystick.Horizontal * speed, Rigidbody.velocity.y, joystick.Vertical * speed);
        float dirX = joystick.Horizontal;
        float dirY = joystick.Vertical;
        if (dirX == 0 && dirY == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (dirX == 1 && dirY == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));
        }

        if (dirX == 1 && dirY == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
        }

        if (dirX == 1 && dirY == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
        }

        if (dirX == 0 && dirY == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -180));
        }

        if (dirX == -1 && dirY == -1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -225));
        }

        if (dirX == -1 && dirY == 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -270));
        }

        if (dirX == -1 && dirY == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -315));
        }

        /*        var input = new Vector3(LeftJoystick.inputVector.x, 0, LeftJoystick.inputVector.y);

        var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up) * input * speed;
        transform.rotation = Quaternion.AngleAxis(CameraAngleY + Vector3.SignedAngle(Vector3.forward, input.normalized + Vector3.forward * 0.0001f, Vector3.up) + 180, Vector3.up);
        Rigidbody.velocity = new Vector3(vel.x, Rigidbody.velocity.y, vel.z);
        */

    }

  
}
