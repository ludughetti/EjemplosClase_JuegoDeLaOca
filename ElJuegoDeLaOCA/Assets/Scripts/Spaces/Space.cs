﻿using UnityEngine;

public class Space : MonoBehaviour
{
    [SerializeField] protected BoardController boardController;
    [SerializeField] protected SpaceType spaceType;
    [SerializeField] protected int spacePosition = 0;
    [SerializeField] protected int moveToPosition = 0;
    [SerializeField] protected string textToShow = string.Empty;

    private void Start()
    {
        if (string.Empty.Equals(textToShow))
            Debug.Log("_textToShow is empty, please set up the corresponding text");
    }

    public virtual string ApplySpaceRule(Player player)
    {
        return textToShow;
    }
}