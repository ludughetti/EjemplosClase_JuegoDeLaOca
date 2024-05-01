using System;
using UnityEngine;

public class Space : MonoBehaviour
{
    [SerializeField] protected BoardController boardController;
    [SerializeField] protected SpaceType _spaceType;
    [SerializeField] protected int _moveToPosition = 0;
    [SerializeField] protected string textToShow = string.Empty;

    private void Start()
    {
        if (string.Empty.Equals(textToShow))
            Debug.Log("_textToShow is empty, please set up the corresponding text");
    }

    public virtual SpaceRuleResult ApplySpaceRule(ref Player player)
    {
        return ReturnResultText();
    }

    protected virtual SpaceRuleResult ReturnResultText()
    {
        return new SpaceRuleResult(textToShow);
    }
}