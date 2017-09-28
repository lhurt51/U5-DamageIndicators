using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float maxHealth = 100.0f;
    public float curHealth = 0.0f;
    public GameObject healthBar;

	// Use this for initialization
	void Start () {
        curHealth = maxHealth;
        InvokeRepeating("IncreaseHealth", 1.0f, 1.0f);
	}

    void OnMouseDown() {
        DecreaseHealth(Random.Range(1, 10));
    }

    void DecreaseHealth(int amount) {
        if (curHealth == 0.0f) {
            Debug.Log("Player is dead");
            Destroy(gameObject);
        }
        else if (curHealth > 0.0f) {
            curHealth = Mathf.Clamp(curHealth - amount, 0.0f, maxHealth);
            CreateDamageText(amount);
        }
        float calcHealth = curHealth / maxHealth;
        SetHealthBar(calcHealth);
    }

    void IncreaseHealth() {
        if (curHealth == maxHealth) {
            Debug.Log("Player full health");
        }
        else if (curHealth < maxHealth) {
            curHealth = Mathf.Clamp(curHealth + 5.0f, 0.0f, maxHealth);
        }
        float calcHealth = curHealth / maxHealth;
        SetHealthBar(calcHealth);
    }

    public void SetHealthBar(float myHealth) {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void CreateDamageText(int amount) {
        var instText = new GameObject("DamageText");
        var textMesh = instText.AddComponent<TextMesh>();
        var faceCam = instText.AddComponent<FaceCamera_Late>();
        var anim = instText.AddComponent<DamageTextAnimation>();

        instText.transform.parent = transform;
        faceCam.reverseFace = true;
        textMesh.characterSize = 0.1f;
        textMesh.anchor = TextAnchor.MiddleCenter;
        textMesh.alignment = TextAlignment.Center;
        textMesh.fontStyle = FontStyle.Bold;
        anim.SetDamageText(amount);
    }
}
