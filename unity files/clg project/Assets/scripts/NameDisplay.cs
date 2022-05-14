using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public static string playername;
    public string name;
    public Text userid;
    public void Start()
    {
        userid.text = playername;
    }
}
