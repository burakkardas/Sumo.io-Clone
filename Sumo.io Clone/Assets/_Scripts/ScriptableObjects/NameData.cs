using UnityEngine;

[CreateAssetMenu(fileName = "NameData", menuName = "CharacterInfo/NameData", order = 1)]
public class NameData : ScriptableObject
{
    public Name[] names;   
}


[System.Serializable]
public class Name
{
    public string name;
}