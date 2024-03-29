using UnityEngine;
using System.Collections;

public class TowerShooting : Tower {
    public float bulletSpeed;

    public Transform partToRotate;
    public Transform[] shootPosition;
    
    private bool isShooting = false;
    private int shootIndex = 0;
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
        for(int i = 0; i < shootPosition.Length; i++) {
            shootPosition[i].LookAt(closestEnemy.transform.position, Vector3.up);
        }
        if(shootIndex == shootPosition.Length) {
            shootIndex = 0;
        }

        if(!isShooting) {
            StartCoroutine(Shoot(closestEnemy));
        }
    }

    private IEnumerator Shoot(GameObject enemy) {
        isShooting = true;

        AudioManager.instance.Play("tower_shoot");
        GameObject newBullet = Instantiate(bullet, shootPosition[shootIndex].position, Quaternion.identity);
        Bullet newBulletComponent = newBullet.GetComponent<Bullet>();
        newBulletComponent.SetProperties(damage, bulletSpeed);
        newBulletComponent.SeekTarget(enemy.transform, shootPosition[shootIndex].rotation);
        shootIndex++;

        yield return new WaitForSeconds(10f / rateOfFire);
        isShooting = false;
    }
}