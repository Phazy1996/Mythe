using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour {

    // a list of enemies to spawn, can be changed for diffrent scenarios in the editor
    [SerializeField]

    private List<GameObject> EnemyWave = new List<GameObject>();




    void OnTriggerEnter2D(Collider2D other)  {
        if (other.tag == GameTags.player){
            Debug.Log("spawn enemies");
        }
    }
}
