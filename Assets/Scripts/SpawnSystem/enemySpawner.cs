using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour {

    // a list of enemies to spawn, can be changed for diffrent scenarios in the editor
    [SerializeField]

    private List<GameObject> EnemyWave = new List<GameObject>();


<<<<<<< HEAD
    //bools
    private bool _enemiesSpawned;
    //bools
    void Start() {
        _enemiesSpawned = false;
        _spawnLocation = transform.FindChild(GameTags.enemySpawnPoint);
        _enemyWaveLength = _enemyWave.Count;
    }
    private void OnTriggerEnter2D(Collider2D other)  {
        if (other.tag == GameTags.player && _enemiesSpawned == false){
            EnemyPlacer();
            _enemiesSpawned = true;
        }
    }


    //the code that will actually place the enemies on screen
    private void EnemyPlacer() {
        for (int i = 0; i < _enemyWaveLength; i++)
        {
            Instantiate(_enemyWave[i],new Vector2((_spawnLocation.transform.position.x + (i *  _SpawnDist)),_spawnLocation.transform.position.y),_spawnLocation.transform.rotation);

        }

    
    }
   
=======


    void OnTriggerEnter2D(Collider2D other)  {
        if (other.tag == GameTags.player){
            Debug.Log("spawn enemies");
        }
    }
>>>>>>> 0db8e5b2a5a4520074f78afbb4eb7c046ac32151
}
