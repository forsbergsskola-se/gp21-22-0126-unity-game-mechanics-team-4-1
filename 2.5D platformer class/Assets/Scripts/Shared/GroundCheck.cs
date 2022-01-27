using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool IsGrounded{ get; private set; }

    [SerializeField] float groundCheckLength = 1f;
    [SerializeField] float groundCheckRadius = 0.5f;
    [SerializeField] LayerMask groundLayers;

    void Update(){
        var ray = new Ray(transform.position, Vector3.down);
        IsGrounded = Physics.SphereCast(ray, groundCheckRadius, groundCheckLength, groundLayers);
    }
}
