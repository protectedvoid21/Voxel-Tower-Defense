using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class CashAnimation {
    public static IEnumerator Animate(int fromCash, int toCash, Text cashText) {
        int operation = 1;
        if(fromCash > toCash) {
            operation = -1;
        }

        float animationSpeed = (float)(toCash - fromCash) * 0.03f;

        for(;fromCash != toCash + operation; fromCash += operation) {
            cashText.text = fromCash.ToString() + "$";
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}