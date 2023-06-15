using System;
using UnityEngine;

public class Generator : Interactable
{
    bool isActive = true;

    public Material offMaterial;

    public Door door;

    public GameObject mainLights;

    public ObjectiveManager manager;

    public static int onGenerators;

    public GameObject[] generatorsInScene;

    public GameObject difficulty1;
    public GameObject difficulty2;
    public GameObject difficulty3;
    public GameObject difficulty4;

    public static int[] eventThreshold;
    public static int eventLevel = 0;

    public AudioSource audioSource;
    public AudioClip normClip;
    public AudioClip powerDownclip;
    public AudioClip finalGenerator, lightGenerator, lightEffect;

    public HardMode hardMode;
    public void Start()
    {
        onGenerators = generatorsInScene.Length;

        Invoke(nameof(AudioStart), 1);
        if(hardMode != null && hardMode.isEnabled)
        {
            difficulty1.SetActive(true);
            difficulty2.SetActive(true);
            difficulty3.SetActive(true);
            Debug.Log("Lights should be out");
            mainLights.SetActive(false);
        }
    }

    public override string GetDescription()
    {
        if (isActive)
        {
            return $"Right Click to <color=red>disable</color> the Generator.";
        }
        else
            return "Generator has been disabled.";
    }

    private void AudioStart()
    {
        audioSource.clip = normClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public override void Interact()
    {
        if(hardMode != null && hardMode.isEnabled && isActive)
        {
            InteractHard();
            Debug.Log("Hardmode is Enabled!");
        }

        else if(!hardMode.isEnabled && isActive)
        {
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.PlayOneShot(powerDownclip);
            isActive = false;
            this.gameObject.GetComponent<Renderer>().material = offMaterial;
            onGenerators--;
            manager.objectiveText.text = $"{onGenerators}/{generatorsInScene.Length} Generators Online.";
            Objective(eventLevel);
            eventLevel++;
        }

    }

    void InteractHard()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(powerDownclip);
        isActive = false;
        this.gameObject.GetComponent<Renderer>().material = offMaterial;
        onGenerators--;

        manager.objectiveText.text = $"{onGenerators}/6 Generators Online.";

        if (onGenerators == 2)
        {
            difficulty4.SetActive(true);
            Debug.Log("Enemy - SPEED Spawned");
        }

        if (onGenerators == 0)
        {
            door.isLocked = false;
            manager.audioSource.PlayOneShot(finalGenerator);
            Debug.Log("Door should be unlocked");
            manager.objectiveText.text = "Office Door is Unlocked.";

        }
    }

    public void Objective(int eventLevel)
    {
        switch (eventLevel) 
        {
            case 0:
                if(difficulty1 != null)
                {
                    difficulty1.SetActive(true);
                    Debug.Log("Batch 1 Spawned");
                }
                break;

            case 1:
                if(difficulty2 != null)
                {
                    SpawnEnemies(difficulty2);
                    Debug.Log("Batch 2 Spawned");
                }
                break;

            case 2:
                if (difficulty3 != null)
                {
                    difficulty3.SetActive(true);
                    Debug.Log("Batch 3 Spawned");
                }
                manager.audioSource.PlayOneShot(lightGenerator);
                manager.audioSource.PlayOneShot(lightEffect);
                break;

            case 6:
                if (difficulty4 != null)
                {
                    difficulty4.SetActive(true);
                    Debug.Log("Enemy - SPEED Spawned");
                }
                door.isLocked = false;
                manager.audioSource.PlayOneShot(finalGenerator);
                Debug.Log("Door should be unlocked");
                manager.objectiveText.text = "Office Door is Unlocked.";
                break;

            default:
                Debug.LogWarning($"Event level {eventLevel} is outside Array Length");
                break;
        }

        Debug.Log($"event level {eventLevel} has been triggered");
    }

    void SpawnEnemies(GameObject spawnObject)
    {
        spawnObject.SetActive(true);
    }
       
}
