// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Emir Kaan Ersöz | Student ID: 220444093
using UnityEngine;
public class FlightController : MonoBehaviour
{
    [Header("Flight Settings")]
    [SerializeField] private float pitchSpeed = 90f;
    [SerializeField] private float yawSpeed = 90f;
    [SerializeField] private float rollSpeed = 90f;
    [SerializeField] private float thrustSpeed = 20f;

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent<Rigidbody>() and set freezeRotation
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.freezeRotation = true; 
        }
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C): Implementation using Time.deltaTime
        
        // Pitch- Vertical Axis
        float pitchInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        // Yaw  - Horizontal Axis 
        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        // Roll
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        if (Input.GetKey(KeyCode.E)) rollInput = -1f;
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);
    }

    private void HandleThrust()
    {
        // TODO (Task 3-D): Forward thrust using Spacebar
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}
