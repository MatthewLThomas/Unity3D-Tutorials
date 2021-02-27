using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemenet : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrust = 2;
    [SerializeField] float wheelForce = 2;

    [SerializeField] AudioSource enigeneThrust;
    [SerializeField] AudioSource rcsThrust;
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
        if(throttle > 0f){
            if(!enigeneThrust.isPlaying){  
                enigeneThrust.Play();
            }
        }else{
            enigeneThrust.Stop();
        }
        enigeneThrust.volume = throttle;
    }
    void ProcessRotation(float wheel){ 
        rb.AddRelativeTorque(Vector3.back*wheel*wheelForce*Time.deltaTime);
        if(wheel != 0){
            if(!rcsThrust.isPlaying){
                rcsThrust.Play();
            }
        }else{
            rcsThrust.Stop();
        }
        rcsThrust.volume = Mathf.Abs(wheel)/2;
    }
    
       
    

    
}
