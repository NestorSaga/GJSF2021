using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    // Start is called before the first frame update


    public float speed = 5;

    public Vector3 dir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pared")
        {
            Debug.Log("Bengalas de luz y de color");

            Destroy(this.gameObject);
        }
    }
}
