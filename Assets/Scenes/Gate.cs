using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool hasKey = false;
    Soniccontrol playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Sonic").GetComponent<Soniccontrol>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        
        {
            if (playerScript.hasKey == true)
            Destroy(gameObject);
        }
    }
}
