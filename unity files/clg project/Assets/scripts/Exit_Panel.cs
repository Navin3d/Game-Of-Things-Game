using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit_Panel : MonoBehaviour
{
 
    
    public GameObject[] canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas[0].SetActive(false);
    }
    public void OnClickAlpha()
    {
        canvas[0].SetActive(true);
    }
    public void IfClickYes()
    {
        SceneManager.LoadScene(1);
    }
    public void IfClickNo()
    {
        canvas[0].SetActive(false);
    }
    
}
