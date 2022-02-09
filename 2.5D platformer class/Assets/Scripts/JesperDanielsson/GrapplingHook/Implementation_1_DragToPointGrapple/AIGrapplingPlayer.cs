using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AIGrapplingPlayer : MonoBehaviour{
    [SerializeField] GameObject hookPrefab;

    GameObject hook;
    Transform target;
    float distanceToPlayer;
    bool ropeActive;
    

    void Start(){
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update(){
        distanceToPlayer = Vector3.Distance(target.position, transform.position);
        if (distanceToPlayer < 5){
            if (!ropeActive){
                CreatAndShootHook();
            }else{
                Destroy(hook,2);
                ropeActive = false;
            }
        }
        else{
            Destroy(hook);
        }
    }

    void CreatAndShootHook(){
        if (!ropeActive){
            hook = Instantiate(hookPrefab, transform.position, Quaternion.identity);
            var directionToPlayer = target.position - transform.position;
            hook.GetComponent<Rigidbody>().AddForce(directionToPlayer, ForceMode.Impulse);
            ropeActive = true;
        }
    }
}
