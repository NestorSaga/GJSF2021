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
        SoundManager.Instance.PlaySound(SoundManager.Sound.player2RocketFlying);
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
            SoundManager.Instance.PlaySound(SoundManager.Sound.player2RocketExplode);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pared")
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.player2RocketExplode);
            Destroy(this.gameObject);
        }
        if(other.tag == "Player")
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.player2RocketExplode);
            Destroy(this.gameObject);
        }
    }
}
