using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConcreteState
{
    public class Driving : IState
    {
        private GameObject vehicle;

        public void Entry(GameObject vehicle)
        {
            this.vehicle = vehicle;
        }

        public void Update()
        {
            Driving.DefaultDrive(this.vehicle);

            this.StateTransition();
        }

        public void FixedUpdate()
        {
            ;
        }

        public void StateTransition()
        {
            if (Input.GetButtonDown("Jump"))
            {
                IState new_state = PlayerController.sJumping;
                new_state.Entry(this.vehicle);
                PlayerController.state = new_state;
                this.Exit();
            }

            else if (Input.GetButtonDown("Fire3"))
            {
                IState new_state = PlayerController.sSpeedBoost;
                new_state.Entry(this.vehicle);
                PlayerController.state = new_state;
                this.Exit();
            }
        }

        public void Exit()
        {
            ;
        }

        public static void DefaultDrive(GameObject vehicle)
        {
            PlayerController.horizontalInput = Input.GetAxis("Horizontal");
            PlayerController.verticalInput = Input.GetAxis("Vertical");

            vehicle.transform.Translate(Vector3.forward * PlayerController.speed * PlayerController.verticalInput * Time.deltaTime);
            vehicle.transform.Rotate(Vector3.up, PlayerController.turnSpeed * PlayerController.horizontalInput * Time.deltaTime);
        }
    }

    public class Spasming : IState
    {
        private GameObject vehicle;

        public void Entry(GameObject vehicle)
        {
            this.vehicle = vehicle;
        }

        public void Update()
        {
            if (!PlayerController.isSpasming)
            {
                vehicle.GetComponent<Rigidbody>().AddForce(0, 0, PlayerController.boost);
                PlayerController.isSpasming = true;
            }

            this.StateTransition();
        }

        public void FixedUpdate()
        {
            ;
        }

        public void StateTransition()
        {
            if (Input.GetButtonDown("Fire3"))
            {
                IState new_state = PlayerController.sDriving;
                new_state.Entry(this.vehicle);
                PlayerController.state = new_state;
                this.Exit();
            }
        }

        public void Exit()
        {
            PlayerController.isSpasming = false;
        }
    }

    public class Jumping : IState
    {
        private GameObject vehicle;

        public void Entry(GameObject vehicle)
        {
            this.vehicle = vehicle;
        }

        public void Update()
        {
            Driving.DefaultDrive(this.vehicle);
            
            if (!PlayerController.isJumping)
            {
                vehicle.GetComponent<Rigidbody>().AddForce(0, PlayerController.jumpHeight, 0);
                PlayerController.isJumping = true;
            }

            this.StateTransition();
        }

        public void FixedUpdate()
        {
            ;
        }

        public void StateTransition()
        {
            if (Input.GetButtonDown("Jump"))
            {
                IState new_state = PlayerController.sDoubleJumping;
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

    public class DoubleJumping : IState
    {
        private GameObject vehicle;

        public void Entry(GameObject vehicle)
        {
            this.vehicle = vehicle;
        }

        public void Update()
        {
            Driving.DefaultDrive(this.vehicle);
            
            if (!PlayerController.isDoubleJumping)
            {
                vehicle.GetComponent<Rigidbody>().AddForce(0, PlayerController.jumpHeight, 0);
                PlayerController.isDoubleJumping = true;
            }

            this.StateTransition();
        }

        public void FixedUpdate()
        {
            ;
        }

        public void StateTransition()
        {
            ;
        }

        public void Exit()
        {
            ;
        }
    }
}
