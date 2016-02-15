using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawner : MonoBehaviour {


    //lists
    // a list of enemies to spawn, can be changed for diffrent scenarios in the editor
    [SerializeField]
    private List<GameObject> _enemyWave = new List<GameObject>();
    //lists

    //transforms
    [SerializeField]
    private Transform _spawnLocation;
    //transforms

    //ints
    private int _enemyWaveLength;
    //use this to select the distance between the spawned enemies before placing them
    [SerializeField]
    private int _SpawnDist;
    //ints

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
   
}
