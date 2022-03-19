using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driving : IStates
{
    private GameObject vehicle;
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float verticalInput;

    public void Entry(GameObject vehicle)
    {
        this.vehicle = vehicle;
    }

    public void Action()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        vehicle.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        vehicle.transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    
        if (Input.GetButtonDown("Jump"))
        {
            IStates new_state = PlayerController.sJumping;
            new_state.Entry(this.vehicle);
            PlayerController.state = new_state;
            this.Exit();
        }

        else if (Input.GetButtonDown("Fire3"))
        {
            IStates new_state = PlayerController.sSpeedBoost;
            new_state.Entry(this.vehicle);
            PlayerController.state = new_state;
            this.Exit();
        }
    }

    public void Exit()
    {
        ;
    }
}

public class spasm : IStates
{
    private GameObject vehicle;
    private float boost = 1000000.0f;
    internal static bool isSpasming;

    public void Entry(GameObject vehicle)
    {
        this.vehicle = vehicle;
    }

    public void Action()
    {
        if (!isSpasming)
        {
            vehicle.GetComponent<Rigidbody>().AddForce(0, 0, boost);
            isSpasming = true;
        }
    
        if (Input.GetButtonDown("Fire3"))
        {
            IStates new_state = PlayerController.sDriving;
            new_state.Entry(this.vehicle);
            PlayerController.state = new_state;
            this.Exit();
        }
    }

    public void Exit()
    {
        isSpasming = false;
    }
}

public class jumping : IStates
{
    private GameObject vehicle;
    private float jumpHeight = 500000.0f;
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    internal static bool isJumping;
    private float horizontalInput;
    private float verticalInput;

    public void Entry(GameObject vehicle)
    {
        this.vehicle = vehicle;
    }

    public void Action()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        vehicle.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        vehicle.transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        if (!isJumping)
        {
            vehicle.GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0);
            isJumping = true;
        }

        
        if (Input.GetButtonDown("Jump"))
        {
            IStates new_state = PlayerController.sDoubleJumping;
            new_state.Entry(this.vehicle);
            PlayerController.state = new_state;
            this.Exit();
        }
        
    }

    public void Exit()
    {
        ;
    }
}

public class doubleJumping : IStates
{
    private GameObject vehicle;
    private float jumpHeight = 500000.0f;
    private float speed = 15.0f;
    private float turnSpeed = 40.0f;
    internal static bool isDoubleJumping;
    private float horizontalInput;
    private float verticalInput;

    public void Entry(GameObject vehicle)
    {
        this.vehicle = vehicle;
    }

    public void Action()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        vehicle.transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        vehicle.transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        if (!isDoubleJumping)
        {
            vehicle.GetComponent<Rigidbody>().AddForce(0, jumpHeight, 0);
            isDoubleJumping = true;
        }
    }

    public void Exit()
    {
        ;
    }
}
