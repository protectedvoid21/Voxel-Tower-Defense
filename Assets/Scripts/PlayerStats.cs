using DefenseGame.Menu;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    #region Singleton
    private static PlayerStats instance;

    private PlayerStats() {
        if(instance != null) {
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private int startMoney;
    [SerializeField] private int startHealth;
    [SerializeField] private Text cashText;
    [SerializeField] private Text healthText;

    public static int money { get; private set; }
    private static int health;

    private void Start() {
        health = startHealth;
        money = startMoney;
        cashText.text = money.ToString() + "$";
        healthText.text = health.ToString();
    }

    public static void AddCash(int amount) {
        instance.StartCoroutine(NumberAnimation.Animate(money, money + amount, instance.cashText, "$"));
        money += amount;
    }

    public static void RemoveCash(int amount) {
        if(money - amount >= 0) {
            instance.StartCoroutine(NumberAnimation.Animate(money, money - amount, instance.cashText, "$"));
            money -= amount;
        }
    }

    public static void RemoveHealth(int amount) {
        if(health - amount >= 0) {
            instance.StartCoroutine(NumberAnimation.Animate(health, health - amount, instance.healthText));
            health -= amount;
        }
        else {
            FindObjectOfType<GameOverMenu>().Display();
        }
    }
}
