using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction {UP, DOWN, LEFT, RIGHT}
public enum State {IDLE, MOVING, ATTACKING}
public class PlayerController : MonoBehaviour
{


    private Rigidbody rb;
    public float speed = 5;

    public Vector3 jump;
    public float jumpForce = 5;

    public bool isGrounded;

    CapsuleCollider sphereCol;
    public GameObject hittBox;

    Direction direction = Direction.DOWN;

    State state = State.IDLE;

    public float attackRange = 1;

    public float attackDuration = 0.2f;
    public float damage = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCol = GetComponent<CapsuleCollider>();
        
    }

    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        //Player Input

        Vector3 pInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Direction

        if (Input.GetAxis("Horizontal") < 0) direction = Direction.LEFT;
        else if (Input.GetAxis("Horizontal") > 0) direction = Direction.RIGHT;
        else if (Input.GetAxis("Vertical") < 0) direction = Direction.DOWN;
        else if (Input.GetAxis("Vertical") > 0) direction = Direction.UP;

        //Movement
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
            StartCoroutine(AttackCoroutine(attackDuration));

    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }



    private void Attack()
    {

    }
    IEnumerator AttackCoroutine(float duration)
    {

        switch (direction)
        {
            case Direction.UP:
                hittBox.transform.localPosition = transform.forward * attackRange;
                break;

            case Direction.DOWN:
                hittBox.transform.localPosition = -transform.forward * attackRange;
                break;

            case Direction.LEFT:
                hittBox.transform.localPosition = -transform.right * attackRange;
                break;

            case Direction.RIGHT:
                hittBox.transform.localPosition = transform.right * attackRange;
                break;
        }
        hittBox.SetActive(true);

        while (duration > 0)
        {
            duration -= Time.deltaTime;





            yield return null;
        }
        hittBox.SetActive(false);
    }
}
