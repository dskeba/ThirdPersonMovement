﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float turnSpeed = 1f;
    Camera mainCamera;
    public float targetAngle;
    public float horizontal;
    public float vertical;

    private GameObject playerHips;
    private GameObject playerAbdomen;
    private GameObject playerTorso;

    private Animator animator;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        playerHips = GameObject.FindGameObjectWithTag("PlayerHips");
        playerAbdomen = GameObject.FindGameObjectWithTag("PlayerAbdomen");
        playerTorso = GameObject.FindGameObjectWithTag("PlayerTorso");
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        animator.SetFloat("VelX", horizontal);
        animator.SetFloat("VelY", vertical);
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        if (targetAngle == 180)
        {
            targetAngle = 0;
        }
        else if (targetAngle > 90)
        {
            var offset = targetAngle - 90;
            targetAngle = -offset;
        } 
        else if (targetAngle < -90)
        {
            var offset = targetAngle + 90;
            targetAngle = -offset;
        }
        transform.eulerAngles = new Vector3(0, yawCamera + targetAngle, 0);
        playerHips.transform.localEulerAngles = new Vector3(0f, -targetAngle / 2, 0f);
        playerAbdomen.transform.localEulerAngles = new Vector3(0f, -targetAngle / 3, 0f);
        playerTorso.transform.localEulerAngles = new Vector3(0f, -targetAngle / 2, 0f);
    }
}
