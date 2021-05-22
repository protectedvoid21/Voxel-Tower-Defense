using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour {
    [System.Serializable]
    public class Wave {
        public string name;
        public float delay;
        public EnemyType[] enemyList;

        [System.Serializable]
        public class EnemyType {
            public Enemy enemy;
            public int count;
        }
    }

    public Wave[] waves;

    private enum WaveType { Waiting, Spawning, InGame, Completed }
    private WaveType waveType;

    private int waveIndex;

    public Transform spawnPoint;
    public Text waveText;

    public float timeBetweenWaves;
    private float timeCountdown;

    private bool spawning = false;

    private void Start() {
        waveType = WaveType.Waiting;
        WaveTextUpdate();
    }

    private void Update() {
        if(waveType == WaveType.Waiting) {
            if(waves.Length == waveIndex) {
                waveType = WaveType.Completed;
                print("Game completed");
            }
            timeCountdown -= Time.deltaTime;
            if(timeCountdown <= 0) {
                timeCountdown = timeBetweenWaves;
                waveType = WaveType.Spawning;
            }
        }
        if(waveType == WaveType.Spawning) {
            if(!spawning) {
                StartCoroutine(SpawnWave());
            }
        }
        if(waveType == WaveType.InGame) {
            if(!isEnemyAlive()) {
                waveType = WaveType.Waiting;
            }
        }
    }

    private IEnumerator SpawnWave() {
        WaveTextUpdate();
        spawning = true;
        foreach(var enemyWave in waves[waveIndex].enemyList) {
            for(int j = 0; j < enemyWave.count; j++) {
                Instantiate(enemyWave.enemy, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(waves[waveIndex].delay);
            }
        }
        waveIndex++;
        waveType = WaveType.InGame;
        spawning = false;
    }

    private void WaveTextUpdate() {
        waveText.text = "Wave : " + (waveIndex + 1).ToString() + "/" + waves.Length.ToString();
    }

    private bool isEnemyAlive() {
        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
            return false;
        }
        return true;
    }
}