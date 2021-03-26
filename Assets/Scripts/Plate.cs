using UnityEngine;

public class Plate : MonoBehaviour {
    public GameObject hoverElement;
    private MeshRenderer hoverRenderer;

    private Color defaultColor;
    public Color hoverColor;

    private void Start() {
        hoverRenderer = hoverElement.GetComponent<MeshRenderer>();
        hoverColor = hoverRenderer.sharedMaterial.color;
    }

    private void Update() {
        hoverRenderer.sharedMaterial.color = defaultColor;
    }

    private void OnMouseOver() {
        hoverRenderer.sharedMaterial.color = hoverColor;
    }
}
