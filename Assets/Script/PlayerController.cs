using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string Name;
    public int Points;
    public int Hp;
    public int Level;
    public CharacterClasses CharClass;

    public PlayerSaveDTO GetSaveData()
    {
        var save = new PlayerSaveDTO()
        {
            Name = this.Name,
            Points = this.Points,
            Hp = this.Hp,
            Level = this.Level,
            CharClass = this.CharClass,
            Position = transform.position,
        };
        return save;
    }
}
