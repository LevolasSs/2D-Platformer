using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {get; private set; } 

    private void Awake() 
    {
        currentHealth = startingHealth;
    }
    private void takeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);    

        if(currentHealth > 0) {
            //player hurt
        }
        else {
            //player dead
        }
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            takeDamage(1);
        }
    }

}
