using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Stats
{
    private int healthPoints;
    public int HealthPoints 
    {
        get { return healthPoints; }
        set { healthPoints = value; }
    }

    private float actionPoints;
    public float ActionPoints
    {
        get { return actionPoints; }
        set { actionPoints = value; }
    }

    private float apChargeRate;
    public float ApChargeRate
    {
        get { return apChargeRate; }
        set { apChargeRate = value; }
    }

    private float currentAtbRate;
    public float CurrentAtbRate
    {
        get { return currentAtbRate; }
        set { currentAtbRate = value; }
    }

    private int attackPower;
    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    private int defense;
    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    private float range;
    public float Range
    {
        get { return range; }
        set { range = value; }
    }

    public Stats()
    {
        // Per second
        apChargeRate = 0.0f;
        currentAtbRate = apChargeRate;
        actionPoints = 0;

        HealthPoints = 0;
        AttackPower = 0;
        Defense = 0;
        Range = 0.0f;
        /*
        // Per second
        apChargeRate = 20.0f;
        currentAtbRate = apChargeRate;
        actionPoints = 0;

        HealthPoints = 100;
        AttackPower = 10;
        Defense = 10;
        Range = 1.92f;*/
    }

    // Update the characters state this frame
    public void Update()
    { 
        // Increase the characters action charge bar
        GainCharge();
    }

    private void GainCharge()
    {
        actionPoints += Time.deltaTime * apChargeRate;

        if (actionPoints > 100.0f)
        {
            actionPoints = 100.0f;
            PauseAtbGauge();
        }
    }

    public void PauseAtbGauge()
    {
        currentAtbRate = 0.0f;
    }
}
