using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // The UI.Text game object
    public Text text;

    // Enumeration of our different states of the game
    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom };

    // The current state of the game
    private States myState;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        myState = States.cell;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        print(myState);
        if (myState == States.cell)                 { state_cell(); }
        else if (myState == States.sheets_0)        { state_sheets_0(); }
        else if (myState == States.sheets_1)        { state_sheets_1(); }
        else if (myState == States.lock_0)          { state_lock_0(); }
        else if (myState == States.lock_1)          { state_lock_1(); }
        else if (myState == States.mirror)          { state_mirror(); }
        else if (myState == States.cell_mirror)     { state_cell_mirror(); }
        else if (myState == States.freedom)         { state_freedom(); }
    }

    /// <summary>
    /// Handles state - the cell, without mirror
    /// </summary>
    void state_cell()
    {
        text.text = "You are in a prison cell, and you want to escape.  There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n\n" +
                    "Press S to view the Sheets, press M to view the Mirror, and press L to view the Lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_0;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            myState = States.mirror;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_0;
        }
    }

    /// <summary>
    /// Handles state - view mirror
    /// </summary>
    void state_mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to Take the mirror or R to return to your cell.";

        if (Input.GetKeyDown(KeyCode.T))
        {
            myState = States.cell_mirror;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    /// <summary>
    /// Handles state - the cell, with mirror
    /// </summary>
    void state_cell_mirror()
    {
        text.text = "You are still in your cell, and you STILL want to escape.  There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "Press S to view the Sheets, or L to Look at the lock.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.sheets_1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            myState = States.lock_1;
        }
    }

    /// <summary>
    /// Handles state - viewing sheets, without mirror
    /// </summary>
    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things.  Surely it's " +
                    "time somebody changed them.  The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press R to Return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    /// <summary>
    /// Handles state - viewing sheets, with mirror
    /// </summary>
    void state_sheets_1()
    {
        text.text = "Holding a mirror in your hand doesn't make the sheet look " +
                    "any better.\n\n" +
                    "Press R to Return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
    }

    /// <summary>
    /// Handles state - view lock, without mirror (locked)
    /// </summary>
    void state_lock_0()
    {
        text.text = "This is one of those button locks.  You have no idea what the " +
                    "combination is.  You wish you could somehow see where the dirty " +
                    "fingerprints were, maybe that would help.\n\n" +
                    "Press R to Return to roaming your cell.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell;
        }
    }

    /// <summary>
    /// Handles state - view lock, with mirror (unlocked)
    /// </summary>
    void state_lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock.  You can just make out fingerprints around " +
                    "the buttons.  You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open or R to return to your cell.";

        if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.freedom;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
    }

    /// <summary>
    /// Handles state - freedom
    /// </summary>
    void state_freedom()
    {
        text.text = "You are FREE!\n\n" +
                    "Press P to Play again.";

        if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.cell;
        }
    }
}