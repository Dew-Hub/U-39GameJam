using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class buyucuNPC : MonoBehaviour
{
    public GameObject diyalogKutu;
    public GameObject npcImg;
    public GameObject devamButon;
    public Text diyalogMetin;
    private int index;
    public static int i = 0;
    public float yaziHizi;
    public static bool temas;
    public string[] sentences = new string[1];

    private void Start()
    {
        sentences[0] = "Mezun oluyorsun diye sevinme, boynuz kulagi gecince kirilir!";
    }

    private void Update()
    {
        if (temas && Input.GetKeyDown(KeyCode.E) && i == 0)
        {
            i++;
            if (diyalogKutu.activeInHierarchy)
            {
                metinSifirla();
            }
            else
            {
                diyalogKutu.SetActive(true);
                npcImg.SetActive(true);
                StartCoroutine(Yaz());
            }
        }
        if (diyalogMetin.text == sentences[index])
        {
            devamButon.SetActive(true);
        }
    }

    public void metinSifirla()
    {
        devamButon.SetActive(false);
        diyalogMetin.text = "";
        index = 0;
        diyalogKutu.SetActive(false);
        npcImg.SetActive(false);
    }

    IEnumerator Yaz()
    {
        foreach (char harf in sentences[index].ToCharArray())
        {
            diyalogMetin.text += harf;
            yield return new WaitForSeconds(yaziHizi);
        }
    }

    public void Devam()
    {
        devamButon.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            diyalogMetin.text = "";
            StartCoroutine(Yaz());
        }
        else metinSifirla();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            temas = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            temas = false;
            i = 0;
            metinSifirla();
        }
    }
}
