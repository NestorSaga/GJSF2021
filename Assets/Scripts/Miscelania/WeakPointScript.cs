using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointScript : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Attack")
        {
            transform.parent.GetComponent<Player_2_Controller>().TakeDamage(10);
            other.transform.parent.GetComponent<PlayerController>().addKnockback(transform);
        }
    }
}
