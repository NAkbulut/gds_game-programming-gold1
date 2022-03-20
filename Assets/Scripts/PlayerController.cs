using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ConcreteState;

public class PlayerController : MonoBehaviour
{
    public static IState state;
    public Text currentState;

    // Initialize States
    internal static IState sDriving = new Driving();
    internal static IState sSpeedBoost = new Spasming();
    internal static IState sJumping = new Jumping();
    internal static IState sDoubleJumping = new DoubleJumping();

    // Private Variables
    internal static float speed = 15.0f;
    internal static float turnSpeed = 40.0f;
    internal static float boost = 1000000.0f;
    internal static float jumpHeight = 500000.0f;
    internal static bool isSpasming;
    internal static bool isJumping;
    internal static bool isDoubleJumping;

    internal static float horizontalInput;
    internal static float verticalInput;

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
        currentState.text = state.GetType().Name;
        state.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        isDoubleJumping = false;
        
        IState new_state = PlayerController.sDriving;
        new_state.Entry(this.gameObject);
        PlayerController.state = new_state;
        sJumping.Exit();
    }
}
