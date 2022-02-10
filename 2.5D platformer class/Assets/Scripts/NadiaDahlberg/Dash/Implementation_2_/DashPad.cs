using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPad : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private float currentMoveSpeed;
    
    void Start()
    {
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
         currentMoveSpeed = _playerMovement.moveSpeed;
    }
    
    private void OnCollisionEnter(Collision hit)
    {

        switch (hit.gameObject.tag)
        {
            case "DashBoost":
                _playerMovement.moveSpeed = 20f;
                break;
            case "Default":
                _playerMovement.moveSpeed = currentMoveSpeed; 
                break;
        }
        
    }

}