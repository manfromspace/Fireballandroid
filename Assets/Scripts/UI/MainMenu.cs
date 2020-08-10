using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highScoreText;

    public RectTransform menuTransform;
    public RectTransform optionTransform;
    public RectTransform quitTranform;
    public RectTransform creditTransform;
    // Start is called before the first frame update
    void Start()
    {

        highScoreText.text = ((int) PlayerPrefs.GetFloat("Highscore")).ToString();   

        menuTransform.transform.gameObject.SetActive(true);
        optionTransform.transform.gameObject.SetActive(false);
        creditTransform.transform.gameObject.SetActive(false);
        quitTranform.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToTut()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ToMenU()
    {
        
        menuTransform.transform.gameObject.SetActive(true);
        optionTransform.transform.gameObject.SetActive(false);
        creditTransform.transform.gameObject.SetActive(false);
        quitTranform.transform.gameObject.SetActive(false);
    }
    public void ToOption()
    {
        menuTransform.transform.gameObject.SetActive(false);
        optionTransform.transform.gameObject.SetActive(true);
        creditTransform.transform.gameObject.SetActive(false);
        quitTranform.transform.gameObject.SetActive(false);
    }
    public void ToCredits()
    {
        menuTransform.transform.gameObject.SetActive(false);
        optionTransform.transform.gameObject.SetActive(false);
        creditTransform.transform.gameObject.SetActive(true);
        quitTranform.transform.gameObject.SetActive(false);
    }
    public void ToQuit()
    {
        menuTransform.transform.gameObject.SetActive(false);
        optionTransform.transform.gameObject.SetActive(false);
        creditTransform.transform.gameObject.SetActive(false);
        quitTranform.transform.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit(); 
    }
}
