using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacherSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] Attacher[] attacherPrefabArray;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    // Start is called before the first frame update


    IEnumerator Start()
    {
        while (spawn)
        {
            
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay,maxSpawnDelay));
            SpawnAttacher();
            
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }


    private void SpawnAttacher()
    {
        var attackerIndex = UnityEngine.Random.Range(0, attacherPrefabArray.Length);
        Spawn(attacherPrefabArray[attackerIndex]);
    }

    private void Spawn (Attacher myAttacker)
    {
        Attacher newAttacker =
        Instantiate(myAttacker, transform.position, transform.rotation) as Attacher;
        newAttacker.transform.parent = transform;
    }
}
