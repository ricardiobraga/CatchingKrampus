using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGeneratorAdaptive : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 50f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartListNight;
    [SerializeField] private List<Transform> levelPartListAfternoon;
    [SerializeField] private List<Transform> levelPartListMorning;
     
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    [SerializeField]
    bool levelDificultNight = true;
    [SerializeField]
    bool levelDificultAfternoon = false;
    [SerializeField]
    bool levelDificultMorning = false;

    [SerializeField] private List<Transform> levelSelected; 

    

    


    private void Awake()
    { 
            CheckDificult();
            // foreach ( Transform item in levelPartListMorning)
            // {
            //     levelSelected.Add(item);
               
            // }
        
        

       lastEndPosition = levelPart_Start.Find("EndPosition").position;

       int statingSpawnLevelParts = 5;
       for (int i = 0; i < statingSpawnLevelParts; i++)
       {
           SpawnLevelPart();
       }

       
       
    }

    private void Update()
    {
    

        CheckDificult();

        // if (levelDificultMorning)
        // {
        //     foreach ( Transform item in levelPartListMorning)
        //     {
        //         levelSelected.Add(item);
               
        //     }
           
        // }





        if (Vector2.Distance(player.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            // Spawn another level part
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
       Transform chosenLevelPart = levelSelected[Random.Range(0, levelSelected.Count)]; 
       Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
       lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    private void CheckDificult ()
    {
        if (levelDificultNight)
        {
            foreach ( Transform item in levelPartListNight)
            {
                levelSelected.Clear();
                levelSelected.Add(item);
               
            } 
        }
        else if (levelDificultAfternoon)
        {
              foreach ( Transform item in levelPartListAfternoon)
            {
                levelSelected.Clear();
                levelSelected.Add(item);               
            }
        }
        else if (levelDificultMorning)
        {
              foreach ( Transform item in levelPartListMorning)
            {
                levelSelected.Clear();
                levelSelected.Add(item);               
            }
        }
    }
}
