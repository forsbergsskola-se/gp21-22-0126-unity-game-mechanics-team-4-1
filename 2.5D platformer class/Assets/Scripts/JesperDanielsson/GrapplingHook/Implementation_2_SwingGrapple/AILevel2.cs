using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILevel2 : MonoBehaviour{
    [SerializeField] float moveSpeed = 1;
    
    Transform target;

    void Start(){
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update(){
        var directionToPlayer = target.position - transform.position;
        directionToPlayer.Normalize();
        transform.position += directionToPlayer * moveSpeed;

        var heightToPlayer = Mathf.Abs(target.position.y - transform.position.y);
        if (heightToPlayer > 4.5f){
            GetComponent<Rigidbody>().useGravity = false;
            moveSpeed = 0.1f;
        }
        else{
            GetComponent<Rigidbody>().useGravity = true;
            moveSpeed = 0.01f;
        }
    }
}
