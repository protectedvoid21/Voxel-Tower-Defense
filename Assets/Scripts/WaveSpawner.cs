using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour {
    [Header("Current level")]
    [SerializeField] private int levelIndex;
    
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

    [SerializeField] private Wave[] waves;

    private enum WaveType { Waiting, Spawning, InGame, Completed }
    private WaveType waveType;

    public int waveIndex { get; private set; }
    public int maxWaves => waves.Length;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Text waveText;

    [SerializeField] private float timeBetweenWaves;
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

                if(PlayerPrefs.GetInt("unlockedLevel") <= levelIndex) {
                    PlayerPrefs.SetInt("unlockedLevel", levelIndex + 1);
                }
                SceneManager.LoadScene("LevelSelect");
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
            if(!IsEnemyAlive()) {
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

    private bool IsEnemyAlive() {
        return GameObject.FindGameObjectsWithTag("Enemy").Length != 0;
    }

    private void OnValidate() {
        for(int i = 0; i < waves.Length; i++) {
            waves[i].name = $"Wave : {i + 1}";

            if(waves[i].delay == 0) {
                waves[i].delay = 2;
            }
        }
    }
}