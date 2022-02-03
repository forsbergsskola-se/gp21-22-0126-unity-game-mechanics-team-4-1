using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Implementation_2_Implosion : MonoBehaviour
{
    [SerializeField] float implosionForce = 10f;
    [SerializeField] GameObject particleSystem;
    [SerializeField] GameObject mineMesh;
    void OnTriggerEnter(Collider other){
        var targetRigidbody = other.GetComponent<Rigidbody>();
        if (targetRigidbody == null)
            return;
        
        var targetDirection = this.transform.position.normalized - targetRigidbody.transform.position.normalized;
        targetRigidbody.AddForce(targetDirection * implosionForce, ForceMode.Acceleration);
        particleSystem.SetActive(true);
        mineMesh.SetActive(false);
        GetComponent<Collider>().enabled = false;
    }
}
