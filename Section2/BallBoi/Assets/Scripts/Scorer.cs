using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    public int scorer = 0;
    private void OnCollisionEnter(Collision other) {
        if(!other.gameObject.tag.Equals("Hit")){
            scorer++;
            Debug.Log("You've Bumped into something this many times: " + scorer);
        }
    }
}