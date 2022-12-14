using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveScript : MonoBehaviour
{
    private float yaw = 0.0f, pitch = 0.0f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField] float walkSpeed = 5.0f, sensitivity = 2.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(rb.transform.position, Vector3.down, 1 + 0.001f))
            rb.velocity = new Vector3(rb.velocity.x, 5.0f, rb.velocity.z);

        if (Input.GetKey(KeyCode.LeftShift)) walkSpeed = 10f;
        if (Input.GetKeyUp(KeyCode.LeftShift)) walkSpeed = 5f;
        look();
    }

    private void FixedUpdate()
    {
        movement();
    }

    void look()
    {
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -90.0f, 90.0f);
        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        Camera.main.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);

    }
    void movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * walkSpeed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0.0f, Camera.main.transform.right.x);    //expensive operation so call in fixedUpdate as opposed to update
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }
}