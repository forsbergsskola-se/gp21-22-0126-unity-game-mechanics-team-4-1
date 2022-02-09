using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implementation_1_Dash : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    
    [Header("Dashing")]
    public Rigidbody myRigidbody;  
    [SerializeField] private float dashingVelocity = 14f;
    [SerializeField] private float dashingTime = 0.5f;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;


    private void Update()
    {   
        var dashInput = Input.GetButtonDown("Dash");

        if (dashInput && canDash)
        {
            isDashing = true;
            canDash = false;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());
        }

        if (isDashing)
        {
            myRigidbody.velocity = dashingDir.normalized * dashingVelocity;
            return;
        } 
        
        if (IsGrounded())
        {
            canDash = true;
        }
    } 
    
    
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
    }
    
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}