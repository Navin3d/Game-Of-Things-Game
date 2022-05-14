using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private float  speed = 6f;
    private float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    static IEnumerator ChangeMovement(string movement) 
    {
        UnityWebRequest www = UnityWebRequest.Get($"http://localhost:8080/robot/RBT-6052fc99-a076-461d-bd21-eadce9c2a5b0/{movement}");

        yield return www.SendWebRequest();

        Debug.Log("Response: " + www.downloadHandler.text);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(ChangeMovement("Stop"));
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * speed;

        if(Input.GetAxis("Horizontal") > 0) 
        {
            StartCoroutine(ChangeMovement("Backward"));
        }
        else if (Input.GetAxis("Horizontal") < 0) 
        {
            StartCoroutine(ChangeMovement("Forward"));
        }
        else if (Input.GetAxis("Vertical") > 0) 
        {
            StartCoroutine(ChangeMovement("Left"));
        }
        else if (Input.GetAxis("Vertical") < 0) 
        {
            StartCoroutine(ChangeMovement("Right"));
        }
        else 
        {
            StartCoroutine(ChangeMovement("Stop"));
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(velocity * Time.deltaTime);
        }
        if (transform.position.x > -32)  // Forward
        {
            transform.position = new Vector3(-32, transform.position.y, transform.position.z);            
        }
        else if (transform.position.x < -70) // Backward
        {
            transform.position = new Vector3(-70,transform.position.y, transform.position.z);
        }
        if (transform.position.z < -48) // Left
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        }
        else if (transform.position.z > 31)  // Right
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 31);
        }
    }
    
}
    
