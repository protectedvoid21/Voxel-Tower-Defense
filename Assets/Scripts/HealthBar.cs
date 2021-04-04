using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour {
    private Transform playerCamera;
    public TextMeshProUGUI healthText;
    public Image fillBar;

    private void Awake() {
        playerCamera = GameObject.FindGameObjectWithTag("CameraParent").transform;
    }

    private void Update() {
        transform.LookAt(transform.position + playerCamera.rotation * Vector3.back);
    }

    public void HpBarUpdate(int health, int maxHealth) {
        fillBar.fillAmount = (float)health / (float)maxHealth;
        healthText.text = health.ToString() + "/" + maxHealth.ToString(); 
    }
}