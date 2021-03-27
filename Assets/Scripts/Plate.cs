using UnityEngine;

public class Plate : MonoBehaviour {
    public GameObject hoverElement;
    private MeshRenderer hoverRenderer;

    private Color defaultColor;
    public Color hoverColor;

    private void Start() {
        hoverRenderer = hoverElement.GetComponent<MeshRenderer>();
        defaultColor = hoverRenderer.sharedMaterial.color;
    }

    private void OnMouseDown() {
        BuildManager buildManager = FindObjectOfType<BuildManager>();
        buildManager.Build(this);
    }

    private void OnMouseOver() {
        hoverRenderer.material.color = hoverColor;
    }

    private void OnMouseExit() {
        hoverRenderer.material.color = defaultColor;
    }
}
