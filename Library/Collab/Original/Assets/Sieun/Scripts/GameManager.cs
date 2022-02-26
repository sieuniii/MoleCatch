using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerManager manager;
    public Text score;
    public Text BestScore;
    private int currentscore; 
    public int stage;
    public Text timeText;
    private float time;
    
    private void Awake() {
        
        BestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    private void Update () {
        time += Time.deltaTime;
        timeText.text = string.Format ("{0:N2}", time);
        if(time>5f){
            SceneManager.LoadScene(2);            
        }
        currentscore = manager.Score;
        score.text = currentscore.ToString();
        
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
        SceneManager.LoadScene(1);
    }




}
