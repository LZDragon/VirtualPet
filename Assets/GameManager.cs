using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject newPetPanel;
    [SerializeField] private TMP_InputField petNameInput;
    [SerializeField] private Button submitButton;
    [SerializeField] private TMP_Text petNameText;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider energySlider;
    private Pet currentPet;
    // Start is called before the first frame update
    void Start()
    {
        newPetPanel.SetActive(true);
        submitButton.onClick.AddListener(EvaluateInput);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EvaluateInput()
    {
        String chosenName = petNameInput.text;
        if (chosenName != "")
        {
            currentPet = new Pet(chosenName);
            petNameText.text = currentPet.Name;
            DisplayStats();
            newPetPanel.SetActive(false);
        }
        else
        {
            //Todo:Display error
        }
    }

    void DisplayStats()
    {
        happinessSlider.value = currentPet.Happiness;
        hungerSlider.value = currentPet.Fullness;
        energySlider.value = currentPet.EnergyLevel;

    }
}
