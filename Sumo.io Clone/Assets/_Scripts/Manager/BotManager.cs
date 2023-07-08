using UnityEngine;
using NOSurrender;
using TMPro;

public class BotManager : MonoBehaviour
{
    [SerializeField] private Color[] botColors = null;
    [SerializeField] private SkinnedMeshRenderer[] botSkinnedMeshRenderers = null;
    [SerializeField] private TMP_Text[] botNameTexts = null;
    [SerializeField] private SpriteRenderer[] botCountrySpriteRenderers = null;
    [SerializeField] private NameData nameData = null;
    [SerializeField] private CountryData countryData = null;



    private void Start()
    {
        SetRandomColor();
        SetRandomNameAndCountry();
    }
    
    
    
    private void SetRandomColor()
    {
        foreach (var botMeshRenderer in botSkinnedMeshRenderers)
        {
            botMeshRenderer.material.color = botColors[Util.GetRandomIndex(botColors.Length)];
        }
    }



    private void SetRandomNameAndCountry()
    {
        for(int i = 0; i < botNameTexts.Length; i++)
        {
            botNameTexts[i].text = nameData.names[Util.GetRandomIndex(nameData.names.Length)].name;
            botCountrySpriteRenderers[i].sprite = countryData.countries[Util.GetRandomIndex(countryData.countries.Length)].countryFlag;
        }
    }
}
