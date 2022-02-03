using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour{
    [SerializeField] float ropeSpeed = 1f;
    public Vector3 Destination{ get; set; }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, Destination, ropeSpeed);
    }
}
