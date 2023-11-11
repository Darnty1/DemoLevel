using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float turningSpeed = 5f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, vertical);
        Quaternion rotation = Quaternion.Euler(0,horizontal * turningSpeed,0);

        rb.rotation *= rotation;
        rb.AddForce(transform.TransformDirection(movement) * movementSpeed);
    }
}
