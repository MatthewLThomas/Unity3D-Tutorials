using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeElapsed : MonoBehaviour
{
    [SerializeField] int dropTime; 
    MeshRenderer mRenderer;
    Rigidbody rigidBody;
    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        mRenderer.enabled = false;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < dropTime+1 && Time.time > dropTime){
            mRenderer.enabled = true;
            rigidBody.useGravity = true;
        }
    }
}
