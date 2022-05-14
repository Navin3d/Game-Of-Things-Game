using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class username : MonoBehaviour
{
    public static username user;
    public InputField input;
    
    public void SetPlayerName()
    {
       NameDisplay.playername = input.text;
        
    }
}
