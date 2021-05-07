using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    private Rigidbody rb;
    public float speed;

    public Vector3 jump;
    public float jumpForce;

    public bool isGrounded;

    CapsuleCollider sphereCol;
    BoxCollider hittBox;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCol = GetComponent<CapsuleCollider>();
        hittBox = GetComponentInChildren<BoxCollider>();
        hittBox.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Basic movement
        Vector3 pInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + pInput * Time.deltaTime * speed);

        //Jump
        if (Physics.CheckSphere(transform.position - transform.up * sphereCol.height/2, 0.1f, (1 << 8)))
        {
            // Definimos grounded
            isGrounded = true;

            // Si salta...
            if (Input.GetKey(KeyCode.Space))
                rb.velocity = Vector3.up * jumpForce;
        }

        else isGrounded = false;

        //Attack
        if (Input.GetKey(KeyCode.Mouse0))
            Attack();

    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }



    private void Attack()
    {


        hittBox.enabled = true;
        //Animation
        Debug.Log("ras");
        hittBox.enabled = false;
    }
}
