using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    float xValue = 0.0f;
    float yValue = 0.0f;
    float zValue = 0.0f;
    [SerializeField] float Speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      MovePlayer();
    }

    void MovePlayer(){
        xValue =  Input.GetAxis("Horizontal")*Time.deltaTime*Speed;
        zValue = Input.GetAxis("Vertical")*Time.deltaTime*Speed;
        transform.Translate(xValue,yValue,zValue); 
    }
}
