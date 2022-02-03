using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowHook : MonoBehaviour{
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float swingSpeed = 1f;
    [SerializeField] GameObject hookPrefab;

    GameObject curHook;
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            var destination = Camera.main.WorldToScreenPoint(Input.mousePosition);

            curHook = Instantiate(hookPrefab, transform.position, Quaternion.identity);
            curHook.GetComponent<RopeController>().Destination = destination;
        }
    }
}
