using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float turnSpeed = 1f;
    Camera mainCamera;
    public float targetAngle;
    public float slerpSpeed;
    public float horizontal;
    public float vertical;

    private void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");

        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;


        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, yawCamera + targetAngle, 0f);


        slerpSpeed = turnSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera + targetAngle, 0), slerpSpeed);

        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera + (horizontal * 90f) + (vertical * 180f), 0), turnSpeed * Time.fixedDeltaTime);


    }
}
