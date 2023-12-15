using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 start;
    private float repeat = 3;
   
    // Start is called before the first frame update
    void Start()
    {
        // startup values
        start = transform.position;
        repeat = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // start value changes as game updates itself
        if (transform.position.x < (start.x - repeat))
        {
            transform.position = start;
        }



    }

 
    

    }
    

