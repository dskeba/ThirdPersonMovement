using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var camera = Camera.main;

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        var forward = camera.transform.forward;
        var right = camera.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        transform.position += (forward * input.y + right * input.x) * Time.deltaTime * speed;


        //this is the direction in the world space we want to move:
        //var desiredMoveDirection = forward * vertical + right * horizontal;

        //now we can apply the movement:
        //transform.Translate(desiredMoveDirection * speed * Time.deltaTime);

        float yawCamera = camera.transform.rotation.eulerAngles.y;

        //transform.rotation = Quaternion.Euler(0f, horizontal * 90f, 0f);

/*        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * yawCamera;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            //controller.Move(direction * speed * Time.deltaTime);
        }*/
    }
}
