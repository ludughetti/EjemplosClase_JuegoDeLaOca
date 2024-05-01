public class SpaceRuleResult
{
    private readonly string _textToShow = string.Empty;
    private readonly bool _isWin = false;
    private bool _canRollAgain = false;

    public SpaceRuleResult(string textToShow)
    {
        _textToShow = textToShow;
    }

    public SpaceRuleResult(string textToShow, bool canRollAgain)
    {
        _textToShow = textToShow;
        _canRollAgain = canRollAgain;
    }

    public SpaceRuleResult(string textToShow, bool canRollAgain, bool isWin)
    {
        _textToShow = textToShow;
        _canRollAgain = canRollAgain;
        _isWin = isWin;
    }

    public string GetTextToShow()
    {
        return _textToShow;
    }

    public bool IsWin()
    {
        return _isWin;
    }

    public bool CanRollDiceAgain()
    {
        return _canRollAgain;
    }
}
