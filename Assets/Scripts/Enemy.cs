using UnityEngine;

public class Enemy : MonoBehaviour {
    public int maxHealth;
    private int health;
    public float speed;
    
    private Transform[] waypoints;
    private int waypointIndex = 0;

    private void Awake() {
        health = maxHealth;
        waypoints = GameObject.FindObjectOfType<Waypoints>().waypoints;
        transform.position = waypoints[waypointIndex].position;
        waypointIndex++;
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
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
        if(health < 0) {
            Destroy(gameObject);
        }
    }
}
