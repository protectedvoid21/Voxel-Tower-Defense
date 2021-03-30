using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField] private int startMoney;
    public Text cashText;

    public static int money;

    private void Start() {
        money = startMoney;
    }

    private void Update() {
        cashText.text = money.ToString() + "$";
    }

    public static void AddCash(int amount) {
        money += amount;
    }

    public static void RemoveCash(int amount) {
        if(money - amount >= 0) {
            money -= amount;
        }
    }
}
