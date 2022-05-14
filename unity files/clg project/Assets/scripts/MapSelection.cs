using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    public void OnClickMap()
    {
        SceneManager.LoadScene(2);
    }
    public void OnClickBack()
    {
        SceneManager.LoadScene(0);
    }
}
