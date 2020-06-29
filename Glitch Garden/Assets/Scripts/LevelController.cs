using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    bool levelTimerFinished = false;
    int numberofAttackers = 0;
    [SerializeField] GameObject winLabel, loseLabel;
    [SerializeField] float waitToLoad = 4f; 


    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberofAttackers++;
    }


    public void Attackerkilled()
    {
        numberofAttackers--;
      
        if (numberofAttackers <= 0 && levelTimerFinished)

        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<Level>().LoadNextScene();


    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
       
    }


    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttacherSpawner[] spawnerArray = FindObjectsOfType<AttacherSpawner>();
            foreach (AttacherSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
