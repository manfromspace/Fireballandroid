using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutToNext : MonoBehaviour
{
    public GameObject TutMenu;
    // Start is called before the first frame update
    void Start()
    {
        TutMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        NextScene();
    }

    public void NextScene()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("GameScene");
        }
        if (Input.GetMouseButton(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
