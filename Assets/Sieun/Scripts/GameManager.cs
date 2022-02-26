using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerManager manager;
    public Text score;
    public Text BestScore;
    public int currentscore; 
    public int stage;

    private void Awake() {

        if(stage ==0){
            currentscore=0;
            PlayerPrefs.SetInt("BestScore", 0);
        }

        if (stage == 1){
            currentscore = 0;
            PlayerPrefs.SetInt("CurrentScore", 0);
        }

        if(stage == 2){
            currentscore = PlayerPrefs.GetInt("CurrentScore", 0);
           
        }
        score.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        BestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        
        
    }

    private void Update () {
        PlayerPrefs.SetInt("CurrentScore",currentscore);
        score.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        
        if (currentscore > PlayerPrefs.GetInt("BestScore", 0)){
            PlayerPrefs.SetInt("BestScore", currentscore);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(stage+1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();
        #endif
    }

    public void Restart()
    {
        stage = 1;
        SceneManager.LoadScene(1);
    }




}
