using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower;
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] private GameObject centerOfMass;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;


    private void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
        transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);
    }
}
