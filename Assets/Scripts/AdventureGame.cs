using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField]
    private Text textComponent;

    [SerializeField]
    private State startingState;

    private State state;


    private void Start()
    {
        state = startingState;

        textComponent.text = state.GetStateStory();
    }

    private void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        State[] nextStates = state.GetNextStates();

        for(int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }

        textComponent.text = state.GetStateStory();
    }
}