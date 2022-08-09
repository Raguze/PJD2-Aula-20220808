using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveDTO
{
    public string Name;
    public int Points;
    public int Hp;
    public int Level;
    public Vector3 Position;
    public CharacterClasses CharClass;
}
