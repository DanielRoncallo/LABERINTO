using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MazeDirectives : MonoBehaviour
{
    GameObject pc;

    public int keysToFind;

    public Text keysValueText;

    public MazeGoal mazeGoalPrefab;
    public MazeKey mazeKeyPrefab;
    MazeGoal mazeGoal;

    int foundKeys;

    List<Vector3> mazeKeyPositions;


    public int enemiesToSpawn;

    public MazeEnemy mazeEnemyPrefab;
    List<Vector3> mazeEnemyPositions;

    void Awake()
    {
        MazeGenerator.OnMazeReady += StartDirectives;
    }

    void Start()
    {
        pc = GameObject.FindGameObjectWithTag("MainCamera");
        SetKeyValueText();
    }

    void StartDirectives()
    {
        mazeGoal = Instantiate(mazeGoalPrefab, MazeGenerator.instance.mazeGoalPosition, Quaternion.identity) as MazeGoal;
        mazeGoal.transform.SetParent(transform);

        mazeKeyPositions = MazeGenerator.instance.GetRandomFloorPositions(keysToFind);
        mazeEnemyPositions = MazeGenerator.instance.GetRandomFloorPositions(enemiesToSpawn);

        for (int i = 0; i < mazeKeyPositions.Count; i++)
        {
            MazeKey mazeKey = Instantiate(mazeKeyPrefab, mazeKeyPositions[i], Quaternion.identity) as MazeKey;
            mazeKey.transform.SetParent(transform);
        }
        for (int i = 0; i < mazeEnemyPositions.Count; i++)
        {
            MazeEnemy mazeEnemy = Instantiate(mazeEnemyPrefab, mazeEnemyPositions[i], Quaternion.identity) as MazeEnemy;
            mazeEnemy.transform.SetParent(transform);
        }
    }

    //AQUI SE VA A OTRO NIVEL
    public void OnGoalReached()
    {
        Debug.Log("Goal Reached");
        if (foundKeys == keysToFind)
        {
            Debug.Log("FINAL NIVEL");
            Debug.Log("Escape the maze");
            pc.GetComponent<PlayerController>().NextLevel();
            pc.GetComponent<PlayerController>().SceneLevel();
        }
    }

    public void OnKeyFound()
    {
        foundKeys++;

        SetKeyValueText();

        if (foundKeys == keysToFind)
        {
            GetComponentInChildren<MazeGoal>().OpenGoal();
        }
    }

    void SetKeyValueText()
    {
        keysValueText.text = foundKeys.ToString() + " of " + keysToFind.ToString();
    }

    void OnDestroy()
    {
        MazeGenerator.OnMazeReady -= StartDirectives;
    }

}
