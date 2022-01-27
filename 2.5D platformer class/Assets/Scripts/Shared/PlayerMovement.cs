using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
   [SerializeField] float moveSpeed = 5f;
   [SerializeField] float jumpForce = 500f;
   
   Rigidbody _myRigidbody;
   GroundCheck _groundCheck;

   void Start(){
      _myRigidbody = GetComponent<Rigidbody>();
      _groundCheck = GetComponent<GroundCheck>();
   }

   void Update(){
      _myRigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, _myRigidbody.velocity.y, 0);

      if (Input.GetKeyDown(KeyCode.Space) && _groundCheck.IsGrounded){
         _myRigidbody.AddForce(Vector3.up * jumpForce);
      }
   }
}

