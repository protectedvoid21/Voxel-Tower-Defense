using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour {
    public int maxHealth;
    public float speed;
    public int worth;
    private int health;
    
    private Transform[] waypoints;
    private int waypointIndex = 0;

    public GameObject healthBar;
    public TextMeshProUGUI healthText;
    public Image fillBar;
    private Transform playerCamera;

    private void Awake() {
        health = maxHealth;
        playerCamera = GameObject.FindGameObjectWithTag("CameraParent").transform;
        hpBarUpdate();

        waypoints = GameObject.FindObjectOfType<Waypoints>().waypoints;
        transform.position = waypoints[waypointIndex].position;
        waypointIndex++;
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * 0.1f * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(waypoints[waypointIndex].position - transform.position); 

        healthBar.transform.LookAt(transform.position + playerCamera.rotation * Vector3.forward);

        if(Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.01f) {
            waypointIndex++;
        }

        if(waypointIndex == waypoints.Length) {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage) {
        health -= damage;
        hpBarUpdate();
        if(health < 0) {
            PlayerStats.AddCash(worth);
            Destroy(gameObject);
        }
    }

    private void hpBarUpdate() {
        fillBar.fillAmount = (float)health / (float)maxHealth;
        healthText.text = health.ToString() + "/" + maxHealth.ToString();        
    }
}
