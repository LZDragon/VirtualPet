using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject newPetPanel;
    [SerializeField] private TMP_InputField petNameInput;
    [SerializeField] private Button submitButton;
    [SerializeField] private TMP_Text petNameText;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Button playButton;
    [SerializeField] private Button feedButton;
    [SerializeField] private Button restButton;
    private bool drain;
    private Pet currentPet;
    // Start is called before the first frame update
    void Start()
    {
        drain = false;
        newPetPanel.SetActive(true);
        submitButton.onClick.AddListener(EvaluateInput);
        
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (drain)
        {
            StatDrain();
        }
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
            drain = true;
            AddStatButtonListeners();
        }
        else
        {
            //Todo:Display error
        }
    }

    void AddStatButtonListeners()
    {
        playButton.onClick.AddListener(PlayWithPet);
        feedButton.onClick.AddListener(FeedPet);
        restButton.onClick.AddListener(PetRests);
    }

    void DisplayStats()
    {
        happinessSlider.value = currentPet.Happiness;
        hungerSlider.value = currentPet.Fullness;
        energySlider.value = currentPet.EnergyLevel;

    }

    void StatDrain()
    {
        currentPet.Eat(-1.0f*Time.deltaTime);
        currentPet.Play(-1.5f*Time.deltaTime);
        currentPet.Rest(-0.5f*Time.deltaTime);
        DisplayStats();
    }

    void PlayWithPet()
    {
        currentPet.Play(5.0f);
        currentPet.Rest(-1.0f);
    }

    void FeedPet()
    {
        currentPet.Eat(5.0f);
    }

    void PetRests()
    {
        currentPet.Rest(5.0f);
    }
}
