using UnityEngine;
using UnityEngine.UI;

public class PlateUI : MonoBehaviour {
    [SerializeField] private Text damageText;
    [SerializeField] private Text rateOfFireText;
    [SerializeField] private Text rangeText;

    public Vector3 offset;

    public void SetTarget(Plate plate) {
        transform.position = plate.transform.position + offset;
        gameObject.SetActive(true);
    }

    public void Upgrade() {

    }

    public void Sell() {

    }
}