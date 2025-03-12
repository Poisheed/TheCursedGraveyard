using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 20;
    public int health = 15;
    public Text lblHealth;
    public Slider sliderHealth;
    //public GameObject pnlDeath;
    //public Button btnRespawn;

    float currentHealthPercentage
    {
        get
        {
            return ((float)(health)) / ((float)(maxHealth));
        }
    }

    void Start()
    {
        health = maxHealth;
        //lblHealth.text = "Salute: " + health;
        //sliderHealth.value = currentHealthPercentage;
        //UpdateHealthbarColor();
        //pnlDeath.SetActive(false);
        //btnRespawn.onClick.AddListener(Respawn);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) Respawn();
        //Debug.Log(health);
    }

    public void Heal(int amount)
    {
        Damage(-amount);
    }

    public void Damage(int damageTaken)
    {
        Debug.Log("HealthMod");
        health -= damageTaken;
        if (health < 1)
        {
            Die();
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        //lblHealth.text = "Salute: " + health;
        sliderHealth.value = currentHealthPercentage;
        //UpdateHealthbarColor();

    }
    void UpdateHealthbarColor()
    {
        Image fillImage = sliderHealth.fillRect.GetComponent<Image>();
        if (currentHealthPercentage >= 0.75f)
        {
            fillImage.color = Color.green;
        }
        else if (currentHealthPercentage >= 0.25f)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }

    public void Die()
    {
        /*RigidbodyFirstPersonController movementController = GetComponent<RigidbodyFirstPersonController>();
        movementController.enabled = false;
        movementController.mouseLook.SetCursorLock(false);
        pnlDeath.SetActive(true);*/
    }

    public void Respawn()
    {
        /*
        Cursor.visible = false;
        pnlDeath.SetActive(false);
        RigidbodyFirstPersonController movementController = GetComponent<RigidbodyFirstPersonController>();
        movementController.mouseLook.SetCursorLock(true);
        movementController.enabled = true;*/
        health = maxHealth;
        //sliderHealth.value = currentHealthPercentage;
        //UpdateHealthbarColor();
    }
}
