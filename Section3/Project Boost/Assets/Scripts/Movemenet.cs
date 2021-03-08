using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemenet : MonoBehaviour
{
    
    [SerializeField] float thrust = 2;
    [SerializeField] float wheelForce = 2;
    [SerializeField] ParticleSystem frontRightThrust;
    [SerializeField] ParticleSystem frontLeftThrust;
    [SerializeField] ParticleSystem backRightThrust;

    [SerializeField] ParticleSystem BackLeftThrust;

    [SerializeField] AudioSource enigeneThrust;
    [SerializeField] AudioSource rcsThrust;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FrontThrustEnable();
        BackThrustEnable();
    }

    // Update is called once per frame
    void Update()
    {
        float wheel = ProcessRotation(Input.GetAxis("Horizontal"));
        float throttle = ProcessThrust(Input.GetAxis("Jump"));
        FrontThrustSpeed(throttle, wheel);
        BackThrustSpeed(throttle, wheel);
    }

    void BackThrustSpeed(float throttle, float wheel){
        
        if (wheel < 0) {
            backRightThrust.startSpeed = 10*(throttle);
            BackLeftThrust.startSpeed = 10*(throttle);
        }else{
            backRightThrust.startSpeed = 10*(throttle+wheel);
            BackLeftThrust.startSpeed = 10*(throttle+wheel);
        }
    }
    void FrontThrustSpeed(float throttle, float wheel){
        if (wheel > 0) {
            frontRightThrust.startSpeed = 10*(throttle);
            frontLeftThrust.startSpeed = 10*(throttle);
        }else{
            frontRightThrust.startSpeed = 10*(throttle-wheel);
            frontLeftThrust.startSpeed = 10*(throttle-wheel);
        }
    }

    public void FrontThrustEnable(){
        frontLeftThrust.Play();
        frontRightThrust.Play();
    }
    public void BackThrustEnable(){
        backRightThrust.Play();
        BackLeftThrust.Play();
    }
    public void FrontThrustDisable(){
        frontLeftThrust.Stop();
        frontRightThrust.Stop();
    }
    public void BackThrustDisable(){
        backRightThrust.Stop();
        BackLeftThrust.Stop();
    }
    float ProcessThrust(float throttle){
        rb.AddRelativeForce(Vector3.right * throttle * thrust*Time.deltaTime);
        if(throttle > 0f){
            if(!enigeneThrust.isPlaying){  
                enigeneThrust.Play();
                
            }
        }else{
            enigeneThrust.Stop();
           
        }
        enigeneThrust.volume = throttle;
        return throttle;
    }
    float ProcessRotation(float wheel){ 
        rb.AddRelativeTorque(Vector3.back*wheel*wheelForce*Time.deltaTime);
        if(wheel != 0){
            if(!rcsThrust.isPlaying){
                rcsThrust.Play();
            }
        }else{
            rcsThrust.Stop();
        }
        rcsThrust.volume = Mathf.Abs(wheel)/2;
        return wheel;
    }
    
       
    

    
}
