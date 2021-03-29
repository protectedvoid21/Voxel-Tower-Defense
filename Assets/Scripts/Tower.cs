using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
    public int damage;
    public float range;
    public float rateOfFire;
    public float bulletSpeed;

    public Transform partToRotate;
    public Transform shootPosition;
    
    private bool isShooting = false;
    public GameObject bullet;
    
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
        shootPosition.LookAt(closestEnemy.transform.position, Vector3.up);

        if(!isShooting) {
            StartCoroutine(Shoot(closestEnemy));
        }
    }

    private IEnumerator Shoot(GameObject enemy) {
        isShooting = true;

        GameObject newBullet = Instantiate(bullet, shootPosition.position, Quaternion.identity);
        Bullet newBulletComponent = newBullet.GetComponent<Bullet>();
        newBulletComponent.SetProperties(damage, bulletSpeed);
        newBulletComponent.SeekTarget(enemy.transform, shootPosition.rotation);

        yield return new WaitForSeconds(1f / rateOfFire);
        isShooting = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}