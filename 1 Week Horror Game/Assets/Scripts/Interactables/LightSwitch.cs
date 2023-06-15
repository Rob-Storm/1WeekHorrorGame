using UnityEngine;

public class LightSwitch : Interactable
{
    [Tooltip("The Light/Lights you want to be affected")]
    public Light[] m_Light;


    [Tooltip("Do you want the light to start on?")]
    public bool isOn;
    bool start = true;

    [Tooltip("Where the sound is played from")]
    public AudioSource audioSource;

    [Tooltip("The sound that plays when you use the light switch")]
    public AudioClip click;

    private void Start()
    {
        UpdateLight();
        start = false;
    }

    private void UpdateLight()
    {
        if (!start)
        {
            foreach (var light in m_Light)
            {
                light.enabled = isOn;
            }
        }
        audioSource.PlayOneShot(click);
    }

    public override string GetDescription()
    {
        if (isOn)
        {
            return "Right Click to turn <color=red>off</color> the Light.";
        }
        else
            return "Right Click to turn <color=green>on</color> the Light.";
    }

    public override void Interact()
    {
        isOn = !isOn;
        UpdateLight();
    }

}