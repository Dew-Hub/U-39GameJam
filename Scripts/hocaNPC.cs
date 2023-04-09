using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hocaNPC : MonoBehaviour
{
    public GameObject diyalogKutu;
    public GameObject hocaImg;
    public GameObject mainImg;
    public GameObject devamButon;
    public Text diyalogMetin;
    private int index;
    public static int i = 0;
    public float yaziHizi;
    public static bool temas;
    public string[] cumleler = new string[4];

    private void Start()
    {
        cumleler[0] = "Evladim sen cok basarili bir buyucusun. Buyu akademisinden mezun olman icin son bir gorev veriyorum.";
        cumleler[1] = "Sagolun hocam, Nedir vazifem?";
        cumleler[2] = "Akademimizin 2 nadide eserini magara canavarlari caldi, Onlari geri getir. ";
        cumleler[3] = "Tamam hocam, O kitaplari geri getirecegim";
    }

    private void Update()
    {
        if (temas && Input.GetKeyDown(KeyCode.E) && i==0)
        {
            i++;
            if (diyalogKutu.activeInHierarchy)
            {
                metinSifirla();
            }
            else
            {
                diyalogKutu.SetActive(true);
                hocaImg.SetActive(true);
                StartCoroutine(Yaz());
            }
        }
        if (diyalogMetin.text == cumleler[index])
        {
            devamButon.SetActive(true);
        }
    }

    public void metinSifirla()
    {
        diyalogMetin.text = "";
        index = 0;
        diyalogKutu.SetActive(false);
        hocaImg.SetActive(false);
        mainImg.SetActive(false);
    }

    IEnumerator Yaz()
    {   
        if (i % 2 == 1)
        {
            hocaImg.SetActive(true);
            mainImg.SetActive(false);
        }else
        {
            hocaImg.SetActive(false);
            mainImg.SetActive(true);
        }
        foreach (char harf in cumleler[index].ToCharArray())
        {
            diyalogMetin.text += harf;
            yield return new WaitForSeconds(yaziHizi);
        }
    }

    public void Devam()
    {
        i++;
        devamButon.SetActive(false);
        if (index < cumleler.Length - 1)
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
            metinSifirla();
        }
    }
}
