using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoLoader : MonoBehaviour
{
    const float loadingTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Invoke("AutoLoader", loadingTime);
        StartCoroutine("AutoLoader");
    }

    /* void AutoLoader()
     {
         SceneManager.LoadScene(1);
     }*/

    IEnumerator AutoLoader()
    {
        yield return new WaitForSeconds(loadingTime);
        SceneManager.LoadScene("Loader");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
