using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public string SaveFilePath { get => $"{Application.persistentDataPath}/save.json"; }

    public List<int> inteiros = new List<int>() {
        0,1,2,3,5,7,11,13
    };
    public List<PlayerSaveDTO> playerSave = new List<PlayerSaveDTO>();

    public List<PlayerController> Players = new List<PlayerController>();

    private void Awake()
    {
        Players.AddRange(FindObjectsOfType<PlayerController>());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayerSaveToJson();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            LoadPlayerSave();
        }
    }

    private void LoadPlayerSave()
    {
        Debug.Log("Load");
        var jsonString = File.ReadAllText(SaveFilePath);
        Debug.Log(jsonString);

        var saveData = JsonUtility.FromJson<PlayerSave>(jsonString);
        playerSave = new List<PlayerSaveDTO>();
        playerSave.AddRange(saveData.Saves);
    }

    private void PlayerSaveToJson()
    {
        Debug.Log("Save");
        var save = new PlayerSaveDTO();
        save.Name = "Megaman";
        save.Points = 80;
        save.Hp = 100;
        save.Level = 10;
        save.Position = Vector3.zero;
        save.CharClass = CharacterClasses.Ranger;

        playerSave.Add(save);

        playerSave.Add(
            new PlayerSaveDTO()
            {
                Name = "Zero",
                Points = 90,
                Hp = 70,
                Level = 9,
                Position = Vector3.zero,
                CharClass = CharacterClasses.Warrior
            }
        );

        foreach(var player in Players)
        {
            playerSave.Add(player.GetSaveData());
        }

        var saves = new PlayerSave()
        {
            Saves = playerSave.ToArray()
        };
        var json = JsonUtility.ToJson(saves,true);
        Debug.Log(json);

        Debug.Log(SaveFilePath);

        File.WriteAllText(SaveFilePath, json);
    }
}
