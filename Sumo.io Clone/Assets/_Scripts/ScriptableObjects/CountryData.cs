using UnityEngine;


[CreateAssetMenu(fileName = "CountryData", menuName = "CharacterInfo/CountryData", order = 1)]
public class CountryData : ScriptableObject
{
    public Country[] countries;
}


[System.Serializable]
public class Country
{
    public string countryName;
    public Sprite countryFlag;
}
