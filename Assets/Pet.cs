//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet
//Name: Eliza Majernik
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 02/26/2024
/////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{
    private string name;
    private float fullness;
    private float happiness;
    private float energyLevel;

    public Pet(string name)
    {
        this.name = name;
        fullness = 100.0f;
        happiness = 100.0f;
        energyLevel = 100.0f;
    }


    public float EnergyLevel
    {
        get => energyLevel;
        set => energyLevel = value;
    }

    public float Happiness
    {
        get => happiness;
        set => happiness = value;
    }

    public float Fullness
    {
        get => fullness;
        set => fullness = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public void Eat(float amount)
    {
        if (fullness + amount < 100.0f && fullness + amount > 0.0f)
        {
            fullness += amount;
        }
        else if(fullness + amount > 100.0f)
        {
            fullness = 100.0f;
        }
        else
        {
            fullness = 0.0f;
        }
    }

    public void Rest(float amount)
    {
        if (energyLevel + amount < 100.0f && energyLevel + amount > 0.0f)
        {
            energyLevel += amount;
        }
        else if(energyLevel + amount > 100.0f)
        {
            energyLevel = 100.0f;
        }
        else
        {
            energyLevel = 0.0f;
        }
    }

    public void Play(float amount)
    {
        if (happiness + amount < 100.0f && happiness + amount > 0.0f)
        {
            happiness += amount;
        }
        else if(happiness + amount > 100.0f)
        {
            happiness = 100.0f;
        }
        else
        {
            happiness = 0.0f;
        }
    }
}
