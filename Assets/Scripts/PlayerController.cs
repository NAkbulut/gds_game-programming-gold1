using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static IStates state; // doesnt work
    public string currState;

    // Initialize States
    internal static IStates sDriving = new driving();
    internal static IStates sJumping = new jumping();
    internal static IStates sDoubleJumping = new doubleJumping();
    internal static IStates sSpeedBoost = new spasm();

    // Start is called before the first frame update
    void Start()
    {
        sDriving.Entry(this.gameObject);
        sJumping.Entry(this.gameObject);
        sDoubleJumping.Entry(this.gameObject);
        sSpeedBoost.Entry(this.gameObject);

        state = sDriving;
    }

    // Update is called once per frame
    void Update()
    {
        currState = state.GetType().Name;
        state.Action();
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping.isJumping = false;
        doubleJumping.isDoubleJumping = false;
        
        IStates new_state = PlayerController.sDriving;
        new_state.Entry(this.gameObject);
        PlayerController.state = new_state;
        sJumping.Exit();
    }
}
