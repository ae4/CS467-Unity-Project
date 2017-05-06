using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    public float max_health = 100f;
    public float curr_health = 0f;
    public GameObject healthBar;

    void Start() {
        curr_health = max_health;
        setHealthBar(curr_health/max_health);
    }

    void Update() {
        if (curr_health <= 0)
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void decreaseHealth(float damage)
    {
        curr_health -= damage;
        float calc_health = curr_health / max_health;
        setHealthBar(calc_health);
    }

    public void increaseHealth(float addHealth)
    {
        curr_health += addHealth;
        if (curr_health > 100)
        {
            curr_health = 100;
        }
        float calc_health = curr_health / max_health;
        setHealthBar(calc_health);
    }

    public void setHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
