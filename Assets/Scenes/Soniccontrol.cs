using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Soniccontrol : MonoBehaviour
{
    public float Speed = 50f;

    public float speed;

    public float upRotation;
    public float downRotation;

    float thisISDecimal = 3.14f;
    CharacterController CharacterControl;
    public Transform playercam;

    Vector3 vel;

    public bool hitSomething;

    public float lookSensitivity;

    public float castDist;

    public Camera mainCam;

    GameObject hitObj;

    float xRotation = 0;
    public TMP_Text itemText;
    public string lookingAt = "nothing!";

    public bool hasKey = false;

    


    // Start is called before the first frame update
    void Start()
    {
        CharacterControl = GetComponent<CharacterController>();
        itemText.text = lookingAt;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -upRotation, downRotation);
        playercam.localRotation = Quaternion.Euler(xRotation, 0, 0);

        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        vel = transform.TransformDirection(vel);
        CharacterControl.Move(vel * Time.deltaTime);


       if(Input.GetMouseButtonDown(0)&& hitObj !=null)
        {
            hasKey = true;
            Destroy(hitObj);
        }
    }

    void FixedUpdate()
    {
       
        RaycastHit hit;
        Vector3 rayStart = mainCam.ViewportToWorldPoint(Input.mousePosition);
        if (Physics.SphereCast(rayStart, 1, playercam.forward, out hit, castDist))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "key")
            {
              hitSomething = true;
              hitObj = hit.transform.gameObject;
            }

        }
        else
        {
            hitSomething = false;
            hitObj = null;
        }
      
    }
}
