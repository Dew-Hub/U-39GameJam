using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hoca2 : MonoBehaviour
{
    public GameObject diyalogKutu;
    public GameObject hocaImg;
    public GameObject mainImg;
    public GameObject buycuImg;
    public GameObject devamButon;
    public Text diyalogMetin;
    Animator anm;
    private int index;
    public static int i = 0;
    public float yaziHizi;
    public static bool temas;
    public string[] cumleler = new string[14];
    SpriteRenderer spr;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        anm = GetComponent<Animator>();
        cumleler[0] = "Hocam buyrun kitaplari getirdim.";
        cumleler[1] = "Tebrikler evladim seni ustun basari ile mezun ediyorum. Bu kitaplari da sana teslim ediyorum.";
        cumleler[2] = "Bu cok buyuk bir sorumluluk, altindan kalkabilir miyim ki?";
        cumleler[3] = "Sana guveniyorum, Benim emeklilik vaktim geldi, Artik akademiyi sen yoneteceksin";
        cumleler[4] = "Hayir, Bunlar benim hakkimdi";
        cumleler[5] = "Sen her zaman kibrine yenik dusmus birisiydin, bunlari hak etmiyorsun";
        cumleler[6] = "Oyle mi?";
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
                hocaImg.SetActive(true);
                StartCoroutine(Yaz());
            }
        }
        if (diyalogMetin.text == cumleler[index])
        {
            devamButon.SetActive(true);
        }
        if (i == 9)
        {
            anm.SetTrigger("olum");
            cumleler[7] = "Hocaaaam!!!";
            cumleler[8] = "Nereden bilebilirdim bir ogrencimin bana oldurucu darbeyi yapacagini. Artik kurtulamam.";
            cumleler[9] = "Hicbir yol yok mu?";
            cumleler[10] = "Evlat, benim yolculugum burada bitti. Sen onu durdurmalisin kitabi goturdu. Buyuk felaketler getirecek";
            cumleler[11] = "Merak etmeyin hocam, onu durduracagim ancak siz...";
            cumleler[12] = "ihhh";
            cumleler[13] = "hayiiiiiir";
            i++;
        }
    }

    public void metinSifirla()
    {
        diyalogMetin.text = "";
        index = 0;
        diyalogKutu.SetActive(false);
        hocaImg.SetActive(false);
        mainImg.SetActive(false);
        buycuImg.SetActive(false);
    }

    IEnumerator Yaz()
    {
        if (i % 2 == 0 && i<10 )
        {
            hocaImg.SetActive(true);
            mainImg.SetActive(false);
            buycuImg.SetActive(false);
        }
        else if (i % 2 == 1 && i > 10)
        {
            hocaImg.SetActive(true);
            mainImg.SetActive(false);
            buycuImg.SetActive(false);
        }
        else if (i < 5 || i>=10)
        {
            hocaImg.SetActive(false);
            mainImg.SetActive(true);
            buycuImg.SetActive(false);
        }
        else if(i<10){
            hocaImg.SetActive(false);
            mainImg.SetActive(false);
            buycuImg.SetActive(true);
        }
        foreach (char harf in cumleler[index].ToCharArray())
        {
            diyalogMetin.text += harf;
            yield return new WaitForSeconds(yaziHizi);
        }
    }

    public void Devam()
    {
        Debug.Log("i:" + i);
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
