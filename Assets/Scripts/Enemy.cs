using UnityEngine;

public class Enemy : MonoBehaviour {
    public int maxHealth;
    public float speed;
    public int worth;
    private int health;
    
    private Transform[] waypoints;
    private int waypointIndex = 0;

    private HealthBar healthBar;

    private void Awake() {
        health = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.HpBarUpdate(health, maxHealth);

        waypoints = GameObject.FindObjectOfType<Waypoints>().waypoints;
        transform.position = waypoints[waypointIndex].position;
        waypointIndex++;
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * 0.1f * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(waypoints[waypointIndex].position - transform.position);

        if(Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.01f) {
            waypointIndex++;
        }

        if(waypointIndex == waypoints.Length) {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage) {
        health -= damage;
        healthBar.HpBarUpdate(health, maxHealth);
        if(health <= 0) {
            PlayerStats.AddCash(worth);
            Destroy(gameObject);
        }
    }
}
