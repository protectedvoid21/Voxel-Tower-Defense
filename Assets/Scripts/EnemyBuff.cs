using System.Collections;
using UnityEngine;

public class EnemyBuff : MonoBehaviour {
    private bool isSlowed = false;
    private Enemy enemy;

    private void Awake() {
        enemy = gameObject.GetComponent<Enemy>();
    }
    
    public IEnumerator AddSlowDebuff(int slowPercent, float duration) {
        if(isSlowed == true) yield break;
        isSlowed = true;

        enemy.speed = enemy.speed * (1 - (slowPercent * 0.01f));
        while(duration >= 0) {
            duration -= Time.deltaTime;
            yield return null;
        }
        CancelSlow();
    }

    public void CancelSlow() {
        enemy.speed = enemy.startSpeed;
        isSlowed = false;
    }
}
