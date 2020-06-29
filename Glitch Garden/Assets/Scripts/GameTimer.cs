using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer In Seconds")]
    [SerializeField] float LevelTime = 10f;
    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) {return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;
        bool timerFinish = (Time.timeSinceLevelLoad >= LevelTime);
        if (timerFinish)
        {
         
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;

        }
    }
}
