using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoginPage : MonoBehaviour
{
    public InputField username;
    public InputField password;
   
    public GameObject[] canvas;
    public void Start()
    {
        canvas[0].SetActive(true);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void CheckValidation()
    {
        string uname = username.text;
        string pass = password.text;
        if (uname == "navinsm@gmail.com" && pass == "navin3d")
        {
            LoadGame();
        }
        else if (uname == "kishore@gmail.com" && pass == "kishore")
        {

            LoadGame();

        }
        else if (uname == "" || pass == "")
        {

            canvas[0].SetActive(false);
            canvas[1].SetActive(true);

        }
        else
        {
            canvas[0].SetActive(false);
            canvas[1].SetActive(true);

        }

    }
    public void ClearRecords()
    {
        username.text = "";
        password.text = "";
    }
    public void BackToLogin()
    {
        canvas[0].SetActive(true);
        canvas[1].SetActive(false);
        ClearRecords();
    }
    
}
