using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextAnimation : MonoBehaviour {
    public int startFontSize = 40;
    public int endFontSize = 55;
    public int fontSizeVar = 10;
    public float animStartY = 1.5f;
    public float animEndY = 3f;
    public float animVar = 0.2f;
    public float animSpeed = 1.0f;
    public Color textColor = new Color(255, 0, 0, 0);

    bool bAnimate = false;
    float t = 0.0f;
	
	// Update is called once per frame
	void Update () {
        if (bAnimate == true) {
            AnimateDamageText();
            t += animSpeed * Time.deltaTime;
            if (t > animSpeed) {
                Destroy(gameObject);
            }
        }
    }

    public void SetDamageText(int amount) {
        Debug.Log("SetText");
        ClearDamageText();
        GetComponent<TextMesh>().text = amount.ToString();
        bAnimate = true;
    }

    private void ClearDamageText() {
        t = 0.0f;
        bAnimate = false;
        animStartY += Random.Range(-animVar, animVar);
        animEndY += Random.Range(-animVar, animVar);
        GetComponent<TextMesh>().text = "";
        GetComponent<TextMesh>().fontSize = startFontSize += Random.Range(-fontSizeVar, fontSizeVar);
        transform.position = new Vector3(transform.position.x + Random.Range(-animVar, animVar), animStartY, transform.position.z + Random.Range(-animVar, animVar));
        GetComponent<TextMesh>().color = textColor;
    }

    private void AnimateDamageText() {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(animStartY, animEndY, t), transform.position.z);
        GetComponent<TextMesh>().fontSize = (int)Mathf.Lerp(startFontSize, endFontSize, t);
        GetComponent<TextMesh>().color = new Color(GetComponent<TextMesh>().color.r, GetComponent<TextMesh>().color.g, GetComponent<TextMesh>().color.b, Mathf.Lerp(1, 0, t));
    }

}
