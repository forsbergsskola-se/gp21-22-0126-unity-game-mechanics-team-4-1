using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Implementation_1_DragToPointGrapple : MonoBehaviour{
    [SerializeField] float grappleSpeed;
    [SerializeField] float maxGrappleDistance;
    [SerializeField] float grappleCooldown;
    [SerializeField] LayerMask grappleLayer;

    Rigidbody rigidbody;
    Transform player;
    
    Camera camera;
    
    Vector2 mousePosition;
    Vector2 grapplePoint;
    Vector2 grappleDistance;

    bool hasGrapplePoint;

    void Start(){
        rigidbody = GetComponent<Rigidbody>();
        player = this.transform;
        camera = Camera.main;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            SetGrapplePoint();
        }
        Grapple();
        Debug.DrawRay(player.position, grapplePoint, Color.red);
        Debug.Log(hasGrapplePoint);
    }

    void Grapple(){
        if (hasGrapplePoint){
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
            GrappleToDestination();
            hasGrapplePoint = false;
            rigidbody.useGravity = true;
            rigidbody.velocity = Vector3.down;
        }
    }

    void GrappleToDestination(){
        var currentPosition = Vector2.Lerp(player.position, grapplePoint, Time.deltaTime * grappleSpeed);
        transform.position = currentPosition;
    }

    void SetGrapplePoint(){
        var distanceVector = camera.ScreenToWorldPoint(Input.mousePosition) - player.position;
        
        if (Physics.Raycast(player.position, distanceVector, out var hit, maxGrappleDistance, grappleLayer)){
            Debug.Log("raycast hit");
            if (Vector2.Distance(hit.point, player.position) <= maxGrappleDistance){
                grapplePoint = hit.point;
                grappleDistance = grapplePoint - (Vector2) player.position;
                hasGrapplePoint = true;
            }
        }
    }
    
}
