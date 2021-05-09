using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamePulse : Weapon
{


    public GameObject pulseToFill, pulseFilling;

    float targetScale;

    public float maxRadius, radius, increaseRate;

    public Vector3 originalFilling, originalToFill;

    bool playedPreOnce, playedPostOnce;

    void Start()
    {

        foreach (Transform tr in GetComponentInChildren<Transform>())
        {
            if (tr.name == "ToFill") pulseToFill = tr.gameObject;
            if (tr.name == "Filling") pulseFilling = tr.gameObject;
        }

        maxRadius = pulseToFill.transform.localScale.x;

        originalFilling = pulseFilling.transform.localScale;
        originalToFill = pulseToFill.transform.localScale;
    }

    void Update()
    {
        
    }

    public override void Fire()
    {
        playedPostOnce = false;
        if (pulseFilling.transform.localScale.x < maxRadius)
        {

            pulseFilling.SetActive(true);
            pulseToFill.SetActive(true);
            pulseFilling.GetComponent<SphereCollider>().enabled = false;

            radius = Mathf.Clamp(radius + increaseRate * Time.deltaTime, 0, maxRadius);

            pulseFilling.transform.localScale = Vector3.one * radius;

           // pulseFilling.transform.localScale = targetScale * radius / maxRadius;

            //pulseFilling.transform.localScale = Vector3.Lerp(pulseFilling.transform.localScale, targetScale, speed * Time.deltaTime);

            if(!playedPreOnce)
            {
                SoundManager.Instance.PlaySound(SoundManager.Sound.player2PulsePre);
                playedPreOnce = true;
            }

        }
            
        else Release();

    }

    public override void Release()
    {
        pulseFilling.GetComponent<SphereCollider>().enabled = true;
        //pulseFilling.transform.localScale = originalFilling;
        radius = 0;     
        playedPreOnce = false;

        StartCoroutine(waitTime());

        if (!playedPostOnce)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.player2PulsePost);
            playedPostOnce = true;
        }


    }


    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(0.2f);
        pulseFilling.SetActive(false);
        pulseToFill.SetActive(false);
    }
}
