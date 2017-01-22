using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    // The UI.Text game object
    public Text text;

    // Enumeration of our different states of the game
    private enum States { cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, stairs_1,
                          stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3, closet_door, in_closet};

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
        if      (myState == States.cell)            { cell(); }
        else if (myState == States.sheets_0)        { sheets_0(); }
        else if (myState == States.sheets_1)        { sheets_1(); }
        else if (myState == States.lock_0)          { lock_0(); }
        else if (myState == States.lock_1)          { lock_1(); }
        else if (myState == States.mirror)          { mirror(); }
        else if (myState == States.cell_mirror)     { cell_mirror(); }
        else if (myState == States.corridor_0)      { corridor_0(); }
        else if (myState == States.stairs_0 )       { stairs_0(); }
        else if (myState == States.stairs_1)        { stairs_1(); }
        else if (myState == States.stairs_2)        { stairs_2(); }
        else if (myState == States.courtyard )      { courtyard(); }
        else if (myState == States.floor )          { floor(); }
        else if (myState == States.corridor_1)      { corridor_1(); }
        else if (myState == States.corridor_2)      { corridor_2(); }
        else if (myState == States.corridor_3)      { corridor_3(); }
        else if (myState == States.closet_door )    { closet_door(); }
        else if (myState == States.in_closet)       { in_closet(); }
    }

    #region State Handler Methods

    /// <summary>
    /// Handles state - the cell, without mirror
    /// </summary>
    void cell()
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
    void mirror()
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
    void cell_mirror()
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
    void sheets_0()
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
    void sheets_1()
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
    void lock_0()
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
    void lock_1()
    {
        text.text = "You carefully put the mirror through the bars, and turn it round " +
                    "so you can see the lock.  You can just make out fingerprints around " +
                    "the buttons.  You press the dirty buttons, and hear a click.\n\n" +
                    "Press O to Open or R to return to your cell.";

        if (Input.GetKeyDown(KeyCode.O))
        {
            myState = States.corridor_0;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.cell_mirror;
        }
    }

    /// <summary>
    /// Handles state - corridor, no hairclip
    /// </summary>
    void corridor_0()
    {
        text.text = "You're out of your cell, but not out of trouble.  " +
                    "You are in the corridor, there is a closet and some stairs leading to " +
                    "the courtyard.  There's also various detritus on the floor.\n\n" +
                    "Press C to view the Closet, F to inspect the Floor, or S to climb the Stairs.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_0;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myState = States.floor;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.closet_door;
        }
    }

    /// <summary>
    /// Handles state - stairs, without hairclip
    /// </summary>
    void stairs_0()
    {
        text.text = "You are walking up the stairs towards the outside light. " +
                    "You realise it's not break time, and you'll be caught immediately. " +
                    "You slither back down the stairs and reconsider.\n\n" +
                    "Press R to Return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
    }

    /// <summary>
    /// Handles state - stairs, with hairclip
    /// </summary>
    void stairs_1()
    {
        text.text = "Unfortunately wielding a puny hairclip hasn't given you the " +
                    "confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
                    "Press R to Retreat down the stairs.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_1;
        }
    }

    /// <summary>
    /// Handles state - stairs, with hairclip, closet door open
    /// </summary>
    void stairs_2()
    {
        text.text = "You feel smug for picking the closet door open, and are still armed with " +
                    "a hairclip (now badly bent).  Even these achievements together don't give " +
                    "you the courage to climb up the stairs to your death!" +
                    "You slither back down the stairs and reconsider!\n\n" +
                    "Press R to Return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_2;
        }
    }

    /// <summary>
    /// Handles state - courtyard, with hairclip, dressed as a cleaner
    /// </summary>
    void courtyard()
    {
        text.text = "You walk through the courtyard dressed as a cleaner.  " +
                    "The guard tips his hat to you as you waltz passed, claiming " +
                    "your freedom.  Your heart races as you walk into the sunset.\n\n" +
                    "Press P to Play again.";

        if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.cell;
        }
    }

    /// <summary>
    /// Handles state - floor
    /// </summary>
    void floor()
    {
        text.text = "Rummaging around on the dirty floor, you find a hairclip.\n\n" +
                    "Press R to Return to standing, or H to take the Hairclip.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            myState = States.corridor_1;
        }
    }

    /// <summary>
    /// Handles state - corridor, with hairclip
    /// </summary>
    void corridor_1()
    {
        text.text = "Still in the corridor.  Floor still dirty.  Hairclip in hand.  " +
                    "Now what?  You wonder if that lock on the closet would succumb " +
                    "to some lock-picking?\n\n" +
                    "Press P to Pick the lock, or S to climb the Stairs.";

        if (Input.GetKeyDown(KeyCode.P))
        {
            myState = States.in_closet;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_1;
        }
    }

    /// <summary>
    /// Handles state - corridor, with hairclip, closet open, not dressed as cleaner
    /// </summary>
    void corridor_2()
    {
        text.text = "Back in the corridor, having declined to dress up as a cleaner.\n\n" +
                    "Press C to revist the Closet, or S to climb the Stairs.";

        if (Input.GetKeyDown(KeyCode.C))
        {
            myState = States.in_closet;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.stairs_2;
        }
    }

    /// <summary>
    /// Handles state - corridor, with hairclip, closet open, dressed as a cleaner
    /// </summary>
    void corridor_3()
    {
        text.text = "You're standing back in the corridor, convincingly dressed as a cleaner.  " +
                    "You strongly consider the run to freedom.\n\n" +
                    "Press S to take the Stairs, or U to Undress.";

        if (Input.GetKeyDown(KeyCode.S))
        {
            myState = States.courtyard;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            myState = States.in_closet;
        }
    }

    /// <summary>
    /// Handles state - closet door, locked, no hairclip
    /// </summary>
    void closet_door()
    {
        text.text = "You are looking at a closet door, unfortunately it's locked.  " +
                    "Maybe you could find something around to encourage it to open?\n\n" +
                    "Press R to Return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_0;
        }
    }

    /// <summary>
    /// Handles state - closet, unlocked, hairclip
    /// </summary>
    void in_closet()
    {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size!  " +
                    "Seems like your day is looking up.\n\n" +
                    "Press D to Dress up, or R to Return to the corridor.";

        if (Input.GetKeyDown(KeyCode.R))
        {
            myState = States.corridor_2;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            myState = States.corridor_3;
        }
    }

    #endregion
}