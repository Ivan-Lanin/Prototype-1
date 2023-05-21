using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int wheelsOnGround;
    private float horizontalInput;
    private float forwardInput;
    private float speed;
    private float rpm;
    private Rigidbody playerRb;


    private void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround()) {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
        }

        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
        speedometerText.SetText("Speed: " + speed + " kph");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }


    private bool IsOnGround() {
        wheelsOnGround = 0;

        foreach (WheelCollider wheel in allWheels) {
            if (wheel.isGrounded) {
                wheelsOnGround++;
            }
        }

        if (wheelsOnGround == 4) {
            return true;
        }
        else { 
            return false;
        }
    }
}
