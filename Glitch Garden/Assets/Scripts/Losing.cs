using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour
{
    HealthDisplay text;
    [SerializeField] int damage = 10;

    private void Start()
    {
        text = FindObjectOfType<HealthDisplay>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (text.HaveEnoughHealth(damage))
        {
            text.SpendHealth(damage);
           
        }
        else
        {
            //StartCoroutine(StopGame());
            GetComponent<AudioSource>().Play();
            FindObjectOfType<LevelController>().HandleLoseCondition();
            //  FindObjectOfType<Level>().LoadYouLose();
        }
        Destroy(collision.gameObject);

    }


    IEnumerator StopGame()
    {
        
        yield return new WaitForSeconds(.5f);
        FindObjectOfType<LevelController>().HandleLoseCondition();
        
    }
}
