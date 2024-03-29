﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public GameObject asteroid;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float startWait;
    //Score
    public Text scoreText;
    public int score;
    //End Text
    public Text endText;
    private bool gameEnded;

    // Start is called before the first frame update
    void Start(){
        gameEnded = false;
        endText.gameObject.SetActive(false);
        scoreText.text = "Score: 0";
        StartCoroutine(SpawnWaves());
    }
    void Update() {
        if (gameEnded) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Scene level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(level.name);
            }
        }
    }
    public void endGame() {
        gameEnded = true;
        endText.gameObject.SetActive(true);
    }
    IEnumerator SpawnWaves() {
        //Wait some time before spawning the first wave
        yield return new WaitForSeconds(startWait);

        //Endless spawn loop
        while (true) {
            for (int i = 0; i < asteroidCount; i++) {
                //Position to spawn an asteroid at. The position is a random point 
                //at the x axis (between a min and max value and the pre-set spawn
                //values for the y and z axis.
                Vector3 spawnAt = new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x),
                    spawnValues.y,
                    spawnValues.z);
                //Quaternion.identity equals no rotation. We deal with rotation in the
                //RandomRotator script.
                Instantiate(asteroid, spawnAt, Quaternion.identity);
                //Wait for next spawn
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
    public void addScore(int points) {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
