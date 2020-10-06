using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    UIManager uiManager;
    Level01Controller controller;

    private void Awake()
    {
        //fill our references
        uiManager = FindObjectOfType<UIManager>();
        controller = FindObjectOfType<Level01Controller>();
    }

    public void DamagePlayer(int _damageAmount)
    {
        //subtract from the health
        health -= _damageAmount;
        Debug.Log("Health is now " + health);

        //update the slider
        uiManager.UpdateHealthSlider();

        if(health <= 0)
        {
            health = 0;
            controller.deathMenu();
            
        }

    }
}
