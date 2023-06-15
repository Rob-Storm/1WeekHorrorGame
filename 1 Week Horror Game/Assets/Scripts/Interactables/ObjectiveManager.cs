using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [Tooltip("How many generators are in the scene")]
    public int onGenerators = 6;

    [Tooltip("A key to the lab that has the exit key")]
    public Key LabKey;

    [Tooltip("The key to exit and beat the level")]
    public Key StairwellKey;

    [Tooltip("A reference to tmpro objective text")]
    public TMP_Text objectiveText;

    [Tooltip("Where the sound is played from")]
    public AudioSource audioSource;

    [Tooltip("A reference to the hardmode class (make sure its on the GameManager gameobject!)")]
    public HardMode hardmode;

    [Tooltip("A reference to a generator (used to get sound effects)")]
    public Generator generator;

    private void Start()
    {
        if(hardmode.isEnabled) 
        {
            audioSource.PlayOneShot(generator.lightGenerator);
            audioSource.PlayOneShot(generator.lightEffect);
        }
    }
}
