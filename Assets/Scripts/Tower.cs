using UnityEngine;

public class Tower : MonoBehaviour {
    public int damage;
    public float range;
    public float rateOfFire;

    public Transform partToRotate;
    
    private void Update() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies == null) {
            return;
        }

        float closestEnemyDistance = range;
        GameObject closestEnemy = null;

        foreach(GameObject enemy in enemies) {
            float enemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
            if(enemyDistance < closestEnemyDistance) {
                closestEnemyDistance = enemyDistance;
                closestEnemy = enemy;
            }
        }
        if(closestEnemy == null) return;

        Vector3 dir = closestEnemy.transform.position - partToRotate.position;
        partToRotate.LookAt(closestEnemy.transform.position, Vector3.up);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}