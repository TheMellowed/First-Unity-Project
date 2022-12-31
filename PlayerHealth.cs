using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int Health;
    public int currentHealth;

    public float FlashLength;
    private float FlashCounter;

    private Renderer rend;
    private Color storedColour;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = Health;
        rend = GetComponent<Renderer>();
        storedColour = rend.material.GetColor("_Color");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }    

        if(FlashCounter > 0)
        {
            FlashCounter -= Time.deltaTime;
            if(FlashCounter <= 0)
            {
                rend.material.SetColor("_Color", storedColour);
            }
        }
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        FlashCounter = FlashLength;
        rend.material.SetColor("_Color", Color.red);
    }
}
