using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)]
    [SerializeField]
    private string storyText;

    [SerializeField]
    private State[] nextStates;


    public State[] GetNextStates()
    {
        return nextStates;
    }

    public string GetStateStory()
    {
        return storyText;
    }
}