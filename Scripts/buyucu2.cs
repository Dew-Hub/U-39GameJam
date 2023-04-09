using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buyucu2 : MonoBehaviour
{
    Animator anim;
    bool isinlan=false;
    bool kontrol = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (hoca2.i == 5)
        {
            this.transform.position = new Vector2(-1.21f, this.transform.position.y);
            isinlan = true;
            kontrol = true;
            anim.SetBool("isinlan",isinlan);
            anim.SetBool("kontrol",kontrol);
            StartCoroutine(oynat());
        }
        if (hoca2.i == 8)
        {
            anim.SetTrigger("hucum");
            hoca2.i++;
            StartCoroutine(kac());
        }
    }
    IEnumerator oynat()
    {
        yield return new WaitForSeconds(1f);
        isinlan = false;
        kontrol = false;
        anim.SetBool("isinlan", isinlan);
        anim.SetBool("kontrol", kontrol);
    }
    IEnumerator kac()
    {
        yield return new WaitForSeconds(1f);
        isinlan = true;
        anim.SetBool("isinlan", isinlan);
        yield return new WaitForSeconds(1f);
        this.transform.position = new Vector2(-140.931f, this.transform.position.y);
        isinlan = false;
        anim.SetBool("isinlan", isinlan);
    }
}
