using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLeft : MonoBehaviour{

    //making the player looks moving by making everything moves to the left like the fence and the bone

    private float speed = 10;
    private PlayerController playerControllerScript;

void Start(){
    playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
}

void Update(){
    if(!playerControllerScript.gameOver){
        transform.Translate(Vector3.left * Time.deltaTime * speed,Space.World);
}
}

}
