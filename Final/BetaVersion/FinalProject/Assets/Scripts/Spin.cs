using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // code from challenge 3 in create with code spin speed modified 
    private float spin = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // will spin bone 
        transform.Rotate(Vector3.up, spin * Time.deltaTime);
    }
}
