using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool hasKey = false;

    CharacterController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Sonic").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (hasKey == true)
        {
            Destroy(gameObject);
        }
    }
}
