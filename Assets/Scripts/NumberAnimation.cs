using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public static class NumberAnimation {
    public static IEnumerator Animate(int fromAmount, int toAmount, Text displayText, string textAddition = "") {
        int operation = fromAmount > toAmount ? -1 : 1;

        for(;fromAmount != toAmount + operation; fromAmount += operation) {
            displayText.text = fromAmount.ToString() + textAddition;
            yield return new WaitForSeconds(0.01f);
        }
    }
}