using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gecis : MonoBehaviour
{
    Scene sahne;
    // Start is called before the first frame update
    void Start()
    {
        sahne = SceneManager.GetActiveScene();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sahne.buildIndex + 1);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
