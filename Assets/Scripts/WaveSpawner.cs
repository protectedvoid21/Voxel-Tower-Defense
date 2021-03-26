using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {
    [System.Serializable]
    public class Wave {
        public string name;
        public float delay;
        public EnemyType[] enemyList;

        [System.Serializable]
        public class EnemyType {
            public GameObject enemy;
            public int count;
        }
    }

    public Wave[] waves;

    private enum WaveType { Waiting, Spawning, InGame }
    private WaveType waveType;

    private int waveIndex = 0;

    public Transform spawnPoint;

    public float timeBetweenWaves;
    private float timeCountdown;

    private void Start() {
        waveType = WaveType.Waiting;
    }

    private void Update() {
        if(waveType == WaveType.Waiting) {
            timeCountdown -= Time.deltaTime;
            if(timeCountdown <= 0) {
                timeCountdown = timeBetweenWaves;
                waveType = WaveType.InGame;
            }
        }
        if(waveType == WaveType.Spawning) {
            StartCoroutine(SpawnWave());
        }
        if(waveType == WaveType.InGame) {
            if(!isEnemyAlive()) {
                waveType = WaveType.Waiting;
            }
        }
    }

    private IEnumerator SpawnWave() {
        waveIndex++;
        for(int i = 0; i < waves[waveIndex].enemyList.Length; i++) {
            for(int j = 0; j < waves[waveIndex].enemyList[j].count; j++) {
                Instantiate(waves[waveIndex].enemyList[j].enemy, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(waves[waveIndex].delay);
            }
        }
    }

    private bool isEnemyAlive() {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            return false;
        }
        return true;
    }
}