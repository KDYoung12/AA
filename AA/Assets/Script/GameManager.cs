using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textGoal;

    public int goal;

    [SerializeField]
    private Color green;

    [SerializeField]
    private Color red;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        textGoal.SetText(goal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseGoal()
    {
        goal -= 1;
        textGoal.SetText(goal.ToString());

        if (goal <= 0)
        {
            SetGameOver(true);
        }
    }

    public void SetGameOver(bool success)
    {
        if(isGameOver == false)
        {
            isGameOver = true;

            Camera.main.backgroundColor = success ? green : red;
        }
    }
}
