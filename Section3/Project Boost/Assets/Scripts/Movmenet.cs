using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movmenet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 2;
    [SerializeField] float wheelForce = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRotation(Input.GetAxis("Horizontal"));
        ProcessThrust(Input.GetAxis("Jump"));
    }
    void ProcessThrust(float throttle){
        rb.AddRelativeForce(Vector3.right * throttle * thrust*Time.deltaTime);
    }
    void ProcessRotation(float wheel){
        rb.AddRelativeTorque(Vector3.back*wheel*wheelForce*Time.deltaTime);
    }
    
       
    

    
}
