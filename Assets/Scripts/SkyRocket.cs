using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRocket : MonoBehaviour
{
    public float speed = 20;
    [HideInInspector] public Vector3 targetPosition;
    GameObject mark;

    void Start()
    {
        mark = transform.GetChild(0).gameObject;
        SoundManager.Instance.PlaySound(SoundManager.Sound.player2RocketFlying);

    }

    void Update()
    {
        if(targetPosition != null)
        {
            mark.transform.position = targetPosition;
            mark.transform.eulerAngles = Vector3.zero;
            transform.position += transform.forward * speed * Time.deltaTime;

            if (transform.position.y <= 0)
            {
                EffectsManager.Instance.InstantiateEffect("Explosion", transform.position);
                SoundManager.Instance.PlaySound(SoundManager.Sound.player2RocketExplode);
                Destroy(gameObject);
            }
        }
    }
}
