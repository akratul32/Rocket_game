using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_R : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float mainThrust = 2000f;
    [SerializeField] float rotationThrust = 50f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*mainThrust *Time.deltaTime);
        }
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationThrust);        
        }
    }

    private void ApplyRotation(float rotaionVariable)
    {
        rb.freezeRotation=true; //frezzing rotation so that we can manually rotate
        transform.Rotate(Vector3.forward*rotaionVariable*Time.deltaTime);
        rb.freezeRotation = false;// Unfreezing the rotation so that the physics can takeover
    }
}


