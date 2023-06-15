using System.Collections;
using UnityEngine;

public class Key : Interactable
{

    [Header("Interactions")]

    [Tooltip("The Door you want to unlock (Make sure the object has the Door Script component!)")]
    public Door door;

    [Tooltip("A collider for interaction")]
    public new BoxCollider collider;

    [Tooltip("The component that renders the key")]
    public MeshRenderer meshRenderer;

    [Tooltip("A reference to the Objective Manager, used for the generators")]
    public ObjectiveManager manager;

    [Tooltip("Is this the final key")]
    public bool isFinalKey = false;

    [Tooltip("The Name that shows up in the interaction text")]
    public string keyName;

    [Tooltip("What the objective text will be changed to upon interacting")]
    public string objectiveMessage;

    [Tooltip("All of the enemies in the current scene (used for the final key event)")]
    public Enemy[] enemy;

    [Header("Sound Effects")]

    [Tooltip("Where the sound is played from")]
    public AudioSource audioSource;

    [Tooltip("The sound that plays when you pick up the key")]
    public AudioClip pickupSound;

    [Tooltip("Alternate sound that play if this is the final (see also: isFinalKey)")]
    public AudioClip finalKey;


    public override string GetDescription()
    {
        return $"Right Click to pickup the <color=blue>{keyName}</color>.";
    }

    public override void Interact()
    {
        door.isLocked = false;
        door.CloseDoor();
        audioSource.PlayOneShot(pickupSound);
        collider.enabled = false;
        meshRenderer.enabled = false;
        StartCoroutine(CheckSound());

        if(objectiveMessage !=  null ||objectiveMessage != string.Empty)
        {
            manager.objectiveText.text = objectiveMessage;
        }

        if(isFinalKey) 
        {
            audioSource.PlayOneShot(finalKey);
            Invoke(nameof(SetHardMode), 3);
        }
    }

    void SetHardMode()
    {
        foreach (Enemy enemy in enemy)
        {
            enemy.HardMode();
        }
    }

    IEnumerator CheckSound()
    {
        yield return new WaitForSeconds(0.1f);
        if (!audioSource.isPlaying)
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(CheckSound());
    }
}
