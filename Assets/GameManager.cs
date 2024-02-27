using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] private ParticleSystem heartParticleSystem;
    [SerializeField] private ParticleSystem foodParticleSystem;
    [SerializeField] private ParticleSystem energyParticleSystem;
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
        currentPet.Eat(-5.0f*Time.deltaTime);
        currentPet.Play(-12.0f*Time.deltaTime);
        currentPet.Rest(-3.0f*Time.deltaTime);
        DisplayStats();
        if (currentPet.Happiness == 0.0f || currentPet.Fullness == 0.0f || currentPet.EnergyLevel == 0.0f)
        {
            LoadLoseScreen();
        }
    }

    void PlayWithPet()
    {
        currentPet.Play(5.0f);
        currentPet.Rest(-1.0f);
        currentPet.Eat(-0.5f);
        heartParticleSystem.Play();
    }

    void FeedPet()
    {
        currentPet.Eat(5.0f);
        currentPet.Rest(0.5f);
        foodParticleSystem.Play();
    }

    void PetRests()
    {
        currentPet.Rest(7.0f);
        currentPet.Play(-0.5f);
        energyParticleSystem.Play();
    }

    void LoadLoseScreen()
    {
        SceneManager.LoadScene(2);
    }
}
