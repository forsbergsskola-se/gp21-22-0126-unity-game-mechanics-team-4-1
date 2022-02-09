using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGrapplingPlayer : MonoBehaviour{
    Transform target;

    void Start(){
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update(){
        
    }
}
