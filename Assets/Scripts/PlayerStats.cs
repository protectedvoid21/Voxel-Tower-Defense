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
    public Text cashText;

    public static int money { get; private set; }

    private void Start() {
        money = startMoney;
    }

    public static void AddCash(int amount) {
        instance.StartCoroutine(CashAnimation.Animate(money, money + amount, instance.cashText));
        money += amount;
    }

    public static void RemoveCash(int amount) {
        if(money - amount >= 0) {
            instance.StartCoroutine(CashAnimation.Animate(money, money - amount, instance.cashText));
            money -= amount;
        }
    } 
}
