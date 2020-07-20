using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class ContactDestroy : MonoBehaviour{

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    private GameController controller;

    void Start() {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController> ();
        if(controller == null) {
            Debug.LogError("Unale to find the GameController script");
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Boundary") {
            //Do nothing
            return;
        }
        if(other.tag != "Player"){
            controller.addScore(10);
        }
        //Destroy the collision object
        Destroy(other.gameObject);
        //Destroy the asteroid itself
        Destroy(gameObject);
        //Instantiate the Explosion game object at the
        //same position as the Asteroid object
        GameObject tmp = Instantiate(asteroidExplosion, transform.position, transform.rotation) as GameObject;
        Destroy(tmp, 1);
        if (other.tag == "Player") {
            //If the other game object is the ship, instantiate an 
            //explosion at the same position as the player object
            tmp = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(tmp, 1);
        }
    }
}
