using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string[] stateNames;
    [SerializeField] private string[] parameterNames;
    [SerializeField] private int[] stateIDs;
    [SerializeField] private int[] parameterIDs;

    private void Awake()
    {
        cameraObject.transform.SetParent(playerObject.transform);
        animator = GetComponent<Animator>();
        stateIDs = new int[stateNames.Length];
        parameterIDs = new int[parameterNames.Length];

        for (int i = 0; i < stateNames.Length; i++)
        {
            stateIDs[i] = Animator.StringToHash(stateNames[i]);
        }

        for (int i = 0; i < parameterNames.Length; i++)
        {
            parameterIDs[i] = Animator.StringToHash(parameterNames[i]);
        }
    }

    public int GetStateID(int index)
    {
        return stateIDs[index];
    }

    public int GetParameterID(int index)
    {
        return parameterIDs[index];
    }
    
}

