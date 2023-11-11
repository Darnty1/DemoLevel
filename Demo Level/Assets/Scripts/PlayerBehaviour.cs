using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [Tooltip("Movementspeed of the Player")]
    public float movementSpeed = 5f;
    [Tooltip("Turningspeed of the Player")]
    public float turningSpeed = 5f;
    [Tooltip("The Strength of the player to push the enemies")]
    public float pushForce = 10f;
    [Tooltip("The Strenght of the enemies to push the player")]
    public float enemyPushForce = 5f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once 
    void Update()
    { 
        if (transform.position.y < -20)
        {
            SceneManager.LoadScene(0);
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, vertical);
        Quaternion rotation = Quaternion.Euler(0,horizontal * turningSpeed,0);

        rb.rotation *= rotation;
        rb.AddForce(transform.TransformDirection(movement) * movementSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Rigidbody otherRB = collision.gameObject.GetComponent<Rigidbody>();
            otherRB.AddForce((otherRB.transform.position - transform.position) * pushForce, ForceMode.Impulse);
            rb.AddForce((transform.position - otherRB.transform.position) * enemyPushForce, ForceMode.Impulse);
        }
    }
}
