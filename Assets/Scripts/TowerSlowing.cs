using UnityEngine;

public class TowerSlowing : Tower {
    [SerializeField] private int slowPercentage;
    [SerializeField] private float slowDuration;

    private void Update() {
        GameObject[] enemies = SearchForEnemies();

        foreach(var enemy in enemies) {
            float enemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if(enemyDistance < range) {
                StartCoroutine(enemy.GetComponent<EnemyBuff>().AddSlowDebuff(slowPercentage, slowDuration));
            }
        }
    }

    private GameObject[] SearchForEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies == null) {
            return null;
        }
        return enemies;
    }

    private void OnDestroy() {
        GameObject[] enemies = SearchForEnemies();

        foreach(var enemy in enemies) {
            float enemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if(enemyDistance < range) {
                enemy.GetComponent<EnemyBuff>().CancelSlow();
            }
        }
    }
}
