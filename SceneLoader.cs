using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Geçiş yapılacak sahne adı mesela "okul"
    public string targetSceneName;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            //targetSceineName değiştirelim
            SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Single);
        }
    }
}
