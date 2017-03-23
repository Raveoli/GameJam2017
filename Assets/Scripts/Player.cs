using UnityEngine;
using System.Collections;

public class Player:MonoBehaviour  {


    float maxHealth=100f;

    private float currentHealth;

    int maxContamination=3;
    int minContamination = 0;

    private int currentContamination;
    public bool isPlaying;

    public void DecreaseHealth(float _amount)
    {
        if (currentHealth - _amount >= 0)
            currentHealth -= _amount;
        else
            currentHealth = 0;  
    }

    public void IncreaseHealth(float _amount)
    {
        if (currentHealth + _amount >= 100f)
            currentHealth = 100f;
        else
            currentHealth += _amount;
    }
    
    public float GetContaminaionLevel()
    {
        return currentContamination;
    }

    public float GetHealthLevel()
    {
        return currentHealth;
    }
    
    public float GetContaminaionPercent()
    {
        return (float)currentContamination / maxContamination;
    }

    public float GetHealthPercent()
    {
        return (float)currentHealth / maxHealth;
    }

    public void SetDefaults()
    {
        currentContamination = minContamination;
        currentHealth = maxHealth;
        isPlaying = true;
    }

    public void IncreaseContamination()
    {
        if(currentContamination<3)
            currentContamination++;
    }

    public float MaxContamination()
    {
        return maxContamination;
    }
}
