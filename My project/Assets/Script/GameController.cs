using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;
    public float startWait;
    public float clonetWait;
    public float waveWait;
    
    public TMP_Text scoreText;
    public TMP_Text restartText;
    public TMP_Text gameOverText;
    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        score = 0;
        gameOver = restart = false;
        scoreText.text = "Score: 0";
        restartText.text = "";
        gameOverText.text = "";
        StartCoroutine(Waves());        
    }

    void Update(){
        if(restart && Input.GetKeyDown(KeyCode.R)){
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    
    IEnumerator Waves()
    {
        while(true){
            yield return new WaitForSeconds(startWait);
            for(int i = 0; i < count; i++){
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(clonetWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver){
                restart = true;
                restartText.text = "Press 'R' to restart";
                break;
            }
        }
    }

    public void addScore(int sc){
        score += sc;
        scoreText.text = "Score: " + score;
    }

    public void GameOver(){
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
