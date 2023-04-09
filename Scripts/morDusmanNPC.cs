using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class morDusmanNPC : MonoBehaviour
{
    public GameObject diyalogKutu;
    public GameObject mainImg;
    public GameObject morImg;
    public GameObject devamButon;
    public GameObject diyalogText;
    public Text diyalogMetin;
    private int index;
    public static int i = 0;
    public float yaziHizi;
    public static bool temas;
    public string[] cumleler = new string[4];

    private void Start()
    {
        cumleler[0] = "Caldigin kitabi geri almaya geldim";
        cumleler[1] = "Bu kitaptaki buyulerle herkesi yenebilirim, Hic bir sey yapamazsin.";
        cumleler[2] = "Kitabi okumadigina gore bir sey yapamazsin.";
        cumleler[3] = "Sen kasindin, Gel bakalim!";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && i == 0)
        {
            i++;
            if (diyalogKutu.activeInHierarchy)
            {
                metinSifirla();
            }
            else
            {
                diyalogKutu.SetActive(true);
                mainImg.SetActive(true);
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
        mainImg.SetActive(false);
        morImg.SetActive(false);
        diyalogText.SetActive(false);
    }

    IEnumerator Yaz()
    {
        if (i % 2 == 1)
        {
            mainImg.SetActive(true);
            morImg.SetActive(false);
        }
        else
        {
            mainImg.SetActive(false);
            morImg.SetActive(true);
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
