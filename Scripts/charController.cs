using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float hareket_hizi = 5f;
    public Animator animatorHeroWalk;
    SpriteRenderer spr;
    Rigidbody2D r2d;
    [SerializeField] GameObject pressKey;


    private void Start()
    {
        animatorHeroWalk.GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        animatorHeroWalk.SetBool("Walk", false);
        if ((hocaNPC.i < 5) && hocaNPC.temas)
        {
            if (hocaNPC.i == 0) pressKey.SetActive(true);
            else if (hocaNPC.i == 1) pressKey.SetActive(false);
        }
        else if ((solucanNPC.i < 5) && solucanNPC.temas)
        {
            if (solucanNPC.i == 0) pressKey.SetActive(true);
            else if(solucanNPC.i==1) pressKey.SetActive(false);
        }
        else if ((morDusmanNPC.i < 5) && morDusmanNPC.temas)
        {
            if (morDusmanNPC.i == 0) pressKey.SetActive(true);
            else if (morDusmanNPC.i == 1) pressKey.SetActive(false);
        }
        else if ((hoca2.i < 5) && hoca2.temas)
        {
            if (hoca2.i == 0) pressKey.SetActive(true);
            else if (hoca2.i == 1) pressKey.SetActive(false);
        }
        
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(-(hareket_hizi * Time.deltaTime), 0, 0);
                animatorHeroWalk.SetBool("Walk", true);
                spr.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(hareket_hizi * Time.deltaTime, 0, 0);
                animatorHeroWalk.SetBool("Walk", true);
                spr.flipX = false;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(0, hareket_hizi * Time.deltaTime, 0);
                animatorHeroWalk.SetBool("Walk", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(0, -(hareket_hizi * Time.deltaTime), 0);
                animatorHeroWalk.SetBool("Walk", true);
            }
        }
    }
}