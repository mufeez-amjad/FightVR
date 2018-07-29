using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActivateTextAnimation : MonoBehaviour {
    private float startTime;
    private TextMesh textMesh;
    Color originalColor;

    public float startDelay = 1f;
    public float fadeOutTime = 2f;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        textMesh = GetComponent<TextMesh>();
        originalColor = textMesh.color;
	}
	
	// Update is called once per frame
	void Update () {
        float elapsedTime = Time.time - startTime;

        float t = Mathf.Clamp01((elapsedTime - startDelay) / fadeOutTime);

        textMesh.color = Color.Lerp(originalColor, Color.clear, t);

        if (t > (startDelay + fadeOutTime)) {
            this.gameObject.SetActive(false);
        }
	}
}
