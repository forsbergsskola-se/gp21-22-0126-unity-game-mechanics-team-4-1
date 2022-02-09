using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implementation_1_Explosion : MonoBehaviour{
    [SerializeField] float explosionForce = 800f;
    [SerializeField] GameObject particleSystem;
    [SerializeField] GameObject mineMesh;
    
    

    void OnTriggerEnter(Collider other){
        var targetRigidbody = other.GetComponent<Rigidbody>();
        if (targetRigidbody == null)
            return;
        
        var targetDirection = (targetRigidbody.transform.position - this.transform.position).normalized;
        targetRigidbody.AddForce(targetDirection * explosionForce, ForceMode.Force);
        Debug.Log(targetDirection); //TODO:Remove used for debug
        particleSystem.SetActive(true);
        mineMesh.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }
}
