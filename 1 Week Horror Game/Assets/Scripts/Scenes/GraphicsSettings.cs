using TMPro;
using UnityEngine;

public class GraphicsSettings : MonoBehaviour
{
    public TMP_Text currentLevel;

    public int graphicsLevel;

    void Start()
    {
        graphicsLevel = 6;

        if (!PlayerPrefs.HasKey("GraphicsLevel"))
        {
            PlayerPrefs.SetInt("GraphicsLevel", 6);
        }

        graphicsLevel = PlayerPrefs.GetInt("GraphicsLevel");
        QualitySettings.SetQualityLevel(graphicsLevel);
        UpdateText(graphicsLevel);
    }

    public void SetPotato()
    {
        QualitySettings.SetQualityLevel(1);
        UpdateText(1);
        PlayerPrefs.SetInt("GraphicsLevel",1);
    }

    public void SetLow()
    {
        QualitySettings.SetQualityLevel(2);
        UpdateText(2);
        PlayerPrefs.SetInt("GraphicsLevel", 2);
    }

    public void SetMedium()
    {
        QualitySettings.SetQualityLevel(3);
        UpdateText(3);
        PlayerPrefs.SetInt("GraphicsLevel", 3);
    }

    public void SetHigh()
    {
        QualitySettings.SetQualityLevel(4);
        UpdateText(4);
        PlayerPrefs.SetInt("GraphicsLevel", 4);
    }

    public void SetUltra()
    {
        QualitySettings.SetQualityLevel(6);
        UpdateText(6);
        PlayerPrefs.SetInt("GraphicsLevel", 6);
    }

    public void UpdateText(int input)
    {
        currentLevel.text = $"Current Graphics Level: {CheckLevel(input)}";
    }

    public string CheckLevel(int graphicsLevel)
    {
        switch (graphicsLevel) 
        {
            case 1:
                return "Potato";
            case 2:
                return "Low";
            case 3:
                return "Medium";
            case 4:
                return "High";
            case 5:
                return "High";
            case 6:
                return "Ultra";
            default:
                return "Unkown";
        }
    }
}
