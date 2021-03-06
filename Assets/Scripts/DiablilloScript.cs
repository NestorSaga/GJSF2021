using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiablilloScript : MonoBehaviour
{

    [HideInInspector]
    public Transform target = null;

    float speed = 5;

    void Start()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.diablilloSound);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target!=null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        if (target != null && transform.position == target.position ) Destroy(gameObject);
    }
}
