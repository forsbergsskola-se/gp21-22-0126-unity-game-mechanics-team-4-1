using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Implementation_2_Implosion : MonoBehaviour
{
    [SerializeField] float implosionForce = 10f;
    [SerializeField] float progressTimeChanger = 5f;
    [SerializeField] GameObject particleSystem;
    [SerializeField] GameObject mineMesh;
    [SerializeField] GameObject blackHoleMesh;
    IEnumerator OnTriggerEnter(Collider other){
        var targetRigidbody = other.GetComponent<Rigidbody>();
        var progress = 0f;
        var finalPosistion = transform.position + new Vector3(0, 5, 0);
        var startPosition = transform.position;
        
        if (targetRigidbody != null){
            while (progress < 1f){
                progress += Time.deltaTime / progressTimeChanger;
                transform.position = Vector3.Lerp(startPosition, finalPosistion, progress);

                var targetDirection = (this.transform.position - targetRigidbody.transform.position).normalized;
                targetRigidbody.AddForce(targetDirection * implosionForce, ForceMode.Acceleration);
                particleSystem.SetActive(true);
                mineMesh.SetActive(false);
                blackHoleMesh.SetActive(true);
                GetComponent<Collider>().enabled = false;
                yield return null;
            }
            blackHoleMesh.SetActive(false);
        }
    }
}
