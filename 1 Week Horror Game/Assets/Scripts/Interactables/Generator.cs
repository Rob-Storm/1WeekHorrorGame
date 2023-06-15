using UnityEngine;

public class Generator : Interactable
{
    bool isActive = true;

    public Material offMaterial;

    public Door door;

    public GameObject mainLights;

    public ObjectiveManager manager;

    public GameObject difficulty1;
    public GameObject difficulty2;
    public GameObject difficulty3;
    public GameObject difficulty4;

    public AudioSource audioSource;
    public AudioClip normClip;
    public AudioClip powerDownclip;
    public AudioClip finalGenerator, lightGenerator, lightEffect;

    public HardMode hardMode;
    public void Start()
    {
        Invoke(nameof(AudioStart), 1);
        if(hardMode.isEnabled)
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
        if(hardMode.isEnabled && isActive)
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
            manager.onGenerators--;

            manager.objectiveText.text = $"{manager.onGenerators}/6 Generators Online.";

            if (manager.onGenerators == 5)
            {
                difficulty1.SetActive(true);
                Debug.Log("Batch 1 Spawned");
            }

            if (manager.onGenerators == 4)
            {
                difficulty2.SetActive(true);
                Debug.Log("Batch 2 Spawned");
            }

            if (manager.onGenerators == 3)
            {
                mainLights.SetActive(false);
                manager.audioSource.PlayOneShot(lightGenerator);
                manager.audioSource.PlayOneShot(lightEffect);
                Debug.Log("Lights should be out");
                difficulty3.SetActive(true);
                Debug.Log("Batch 3 Spawned");
            }

            if (manager.onGenerators == 0)
            {
                door.isLocked = false;
                manager.audioSource.PlayOneShot(finalGenerator);
                Debug.Log("Door should be unlocked");
                manager.objectiveText.text = "Office Door is Unlocked.";
                difficulty4.SetActive(true);
                Debug.Log("Enemy - SPEED Spawned");
            }
        }

    }

    void InteractHard()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(powerDownclip);
        isActive = false;
        this.gameObject.GetComponent<Renderer>().material = offMaterial;
        manager.onGenerators--;

        manager.objectiveText.text = $"{manager.onGenerators}/6 Generators Online.";

        if (manager.onGenerators == 2)
        {
            difficulty4.SetActive(true);
            Debug.Log("Enemy - SPEED Spawned");
        }

        if (manager.onGenerators == 0)
        {
            door.isLocked = false;
            manager.audioSource.PlayOneShot(finalGenerator);
            Debug.Log("Door should be unlocked");
            manager.objectiveText.text = "Office Door is Unlocked.";

        }
    }
}
