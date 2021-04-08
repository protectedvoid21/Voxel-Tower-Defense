using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class CashAnimation {
    public static IEnumerator Animate(int fromCash, int toCash, Text cashText) {
        int operation = fromCash > toCash ? -1 : 1;

        for(;fromCash != toCash + operation; fromCash += operation) {
            cashText.text = fromCash.ToString() + "$";
            yield return new WaitForSeconds(0.01f);
        }
    }
}