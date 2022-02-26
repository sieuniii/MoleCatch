using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{   public Text timeText;
    private float time;
   

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = string.Format ("{0:N2}", time);
        if(time>30f){
            SceneManager.LoadScene(2);            
        }
    }
}
