using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyAdventure : MonoBehaviour
{
    //hier staan alle mogelijke gamestates
    private enum States
    {
        start,
        intro,
        castle,
        pickpocket,
        sneak,
        door,
        lockpick,
        window,
        quarterslp,
        quartersnlp,
        safelp,
        safenlp,
        uniform,
        tax,
        distraction,
        end,
    }

    private States currentState = States.start;
    // zorgt dat de het eerste stukje script word aangeroepen
    void Start()
    {
        ShowMainMenu();
    }
    // Speler inputs en wat het spel er mee doet
    void OnUserInput(string input)
        {
            switch (currentState)
            {
                case States.start:
                
                        if (input == "start")
                        {
                            startintro();
                        }
                        else if (input == "I wanna be a wizard!")
                        {
                            Terminal.WriteLine("The DM looks at you annoyed...");
                        } 
                        break;
                
                case States.intro:
                    if (input == "continue")
                    {
                        castle();
                    }
                    break;
                
                case States.castle:
                    if (input == "pickpokket")
                    {
                        pickpokket();
                    }else if (input == "sneak")
                    {
                        sneak();
                    }
                    break;
                
                case States.pickpocket:
                    if (input == "continue")
                    {
                        door();
                    }
                    break;
                
                case States.sneak:
                    if (input == "continue")
                    {
                        door();
                    }
                    break;
                
                case States.door:
                    if (input == "lockpick")
                    {
                        lockpick();
                    }else if (input == "window")
                    {
                        window();
                    }
                    break;
                
                case States.lockpick:
                    if (input == "continue")
                    {
                        quartersnlp();
                    }
                    break;
                
                case States.window:
                    if (input == "continue")
                    {
                        quarterslp();
                    }
                    break;
                
                case States.quarterslp:
                    if (input == "safe")
                    {
                        safelp();
                    }else if (input == "uniform")
                    {
                        uniform();
                    }
                    break;
                
                case States.safelp:
                    if (input == "continue")
                    {
                        safelp2();
                    }
                    break;
                
                case States.quartersnlp:
                    if (input == "safe")
                    {
                        safenlp();
                    }else if (input == "uniform")
                    {
                        uniform();
                    }
                    break;
                
                case States.safenlp:
                    if (input == "continue")
                    {
                        safenlp2();
                    }
                    break;
                
                case States.uniform:
                    if (input == "tax")
                    {
                        tax();
                    }else if (input == "distract")
                    {
                        distraction();
                    }
                    break;
                
                case States.tax:
                    if (input == "continue")
                    {
                        tax2();
                    }
                    break;
                    
                case States.distraction:
                    if (input == "continue")
                    {
                        distraction2();
                    }
                    break;
                
                case States.end:
                    if (input == "menu")
                    {
                        Startmenu();
                    }
                    break;
            }
        }

    
    //scripts met tekst die de speler te zien krijgt en gamestate updates
    void ShowMainMenu()
        {
            Terminal.WriteLine("Welcome to the Tiefling's heist");
            Terminal.WriteLine("It's night in the SilverBush keep");
            Terminal.WriteLine("You were told tonight would be");
            Terminal.WriteLine("full of oppurtunity by a fortune");
            Terminal.WriteLine("teller and you are ready to acquire");
            Terminal.WriteLine("great fortune it's finally time");
            Terminal.WriteLine("to make a move...");
            Terminal.WriteLine("type start to begin");
        } 
    
    void startintro()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You make your way into the");
        Terminal.WriteLine("city, its night and the roads'");
        Terminal.WriteLine("are lit only by the light of");
        Terminal.WriteLine("a not quite full moon hiding");
        Terminal.WriteLine("partially behind some small");
        Terminal.WriteLine("clouds.");
        Terminal.WriteLine("you're prepared for a profitable ");
        Terminal.WriteLine("night... (continue)");
        currentState = States.intro;
    }
    
    void castle()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("as you head towards the Keep");
        Terminal.WriteLine("you notice the gaurd's captain");
        Terminal.WriteLine("Joffrey sleeping while on his");
        Terminal.WriteLine("duty... an excellent opportunity");
        Terminal.WriteLine("or a rookie mistake?");
        Terminal.WriteLine("you think as you see his gold");
        Terminal.WriteLine("pouch hanging from his hip");
        Terminal.WriteLine("");
        Terminal.WriteLine("(pickpokket/sneak)");
        currentState = States.castle;
        
    }
    
    void pickpokket()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you grab your dagger and you");
        Terminal.WriteLine("prepare hold your hand");
        Terminal.WriteLine("underneath you quickly slice of");
        Terminal.WriteLine("and catch the pouch.");
        Terminal.WriteLine("you quickly head inside");
        Terminal.WriteLine("(continue)");
        currentState = States.pickpocket;
    }
    
    void sneak()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("only a fool would risk stealing");
        Terminal.WriteLine("from the gaurd's captain, you");
        Terminal.WriteLine("you think as you sneak past him.");
        Terminal.WriteLine("");
        Terminal.WriteLine("(continue)");
        currentState = States.sneak;
    }
    
    void door()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("as you near the lord's quarter's");
        Terminal.WriteLine("you see the door is closed...");
        Terminal.WriteLine("you head for it and its locked");
        Terminal.WriteLine("obvious... you brought lockpick's'");
        Terminal.WriteLine("but you noticed the window is open");
        Terminal.WriteLine("now do you pick the lock or sneak");
        Terminal.WriteLine("around.");
        Terminal.WriteLine("(lockpick/window)");
        currentState = States.door;
    }
    
    void lockpick()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you decide it makes the most");
        Terminal.WriteLine("sense to pick the lock...");
        Terminal.WriteLine("you quickly look around and");
        Terminal.WriteLine("get to it...");
        Terminal.WriteLine("as you manage to open the door");
        Terminal.WriteLine("your lockpick break's");
        Terminal.WriteLine("(continue)");
        currentState = States.lockpick;
    }
    
    void window()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("the window seems like a safer");
        Terminal.WriteLine("bet... you sneakily get around");
        Terminal.WriteLine("the building and find the window");
        Terminal.WriteLine("you climb up swifly and enter");
        Terminal.WriteLine("the building");
        Terminal.WriteLine("");
        Terminal.WriteLine("(continue)");
        currentState = States.window;
    }
    
    void quarterslp()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you look around inside the dusty");
        Terminal.WriteLine("room and notice paperwork everywhere.");
        Terminal.WriteLine("you also notice a safe... locked, and");
        Terminal.WriteLine("a gaurd's uniform that certainly could");
        Terminal.WriteLine("be usefull");
        Terminal.WriteLine("");
        Terminal.WriteLine("(uniform/safe)");
        currentState = States.quarterslp;
    }
    
    void quartersnlp()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you look around inside the dusty");
        Terminal.WriteLine("room and notice paperwork everywhere.");
        Terminal.WriteLine("you also notice a safe... locked, and");
        Terminal.WriteLine("a gaurd's uniform that certainly could");
        Terminal.WriteLine("be usefull");
        Terminal.WriteLine("");
        Terminal.WriteLine("(uniform/safe)");
        currentState = States.quartersnlp;
        
    }

    void safelp()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You grab your lockpick's and open");
        Terminal.WriteLine("the safe silently, and as you look");
        Terminal.WriteLine("in you see laying there lots of");
        Terminal.WriteLine("valuebles. you quickly collect them");
        Terminal.WriteLine("now its time to get out");
        Terminal.WriteLine("");
        Terminal.WriteLine("(continue)");
        currentState = States.safelp;
        
    }
    
    void safelp2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You head out throug the window you");
        Terminal.WriteLine("entered throug and you get out");
        Terminal.WriteLine("");
        Terminal.WriteLine("it seems the fortune teller was right");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("(menu)");
        currentState = States.end;
    }

    void safenlp()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("as you try to open the safe your");
        Terminal.WriteLine("begin to realize your lockpick is");
        Terminal.WriteLine("broken you grab your crowbar and try");
        Terminal.WriteLine("to open it but the loud noise");
        Terminal.WriteLine("wakes the gaurds andbefore you know");
        Terminal.WriteLine("it you are surounded");
        Terminal.WriteLine("");
        Terminal.WriteLine("(continue)");
        currentState = States.safenlp;
    }
    
    void safenlp2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("the gaurds catch you and you give ");
        Terminal.WriteLine("up you're taken right to the jail");
        Terminal.WriteLine("");
        Terminal.WriteLine("it seems the fortune teller was ");
        Terminal.WriteLine("wrong");
        Terminal.WriteLine("");
        Terminal.WriteLine("(menu)");
        currentState = States.end;
    }

    void uniform()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you grab the uniform and put it on");
        Terminal.WriteLine("and decide to head to the jeweler");
        Terminal.WriteLine("now will you cause a distraction and");
        Terminal.WriteLine("quickly grab something or will you");
        Terminal.WriteLine("simply 'collect' some taxes.");
        Terminal.WriteLine("");
        Terminal.WriteLine("(distract/tax)");
        currentState = States.uniform;
    }

    void tax()    
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("as you ask for taxes demandingly");
        Terminal.WriteLine("the jeweler signals a guard");
        Terminal.WriteLine("'I already paid those!' he tells");
        Terminal.WriteLine("you as guards surround you already");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("(continue)");
        currentState = States.tax;
    }

    void tax2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("the gaurds catch you and you give up");
        Terminal.WriteLine("you're taken right to the jail'");
        Terminal.WriteLine("");
        Terminal.WriteLine("it seems the fortune teller was wrong");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("(menu)");
        currentState = States.end;
    }

    void distraction()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("you run in screaming there is a troll");
        Terminal.WriteLine("attack as people start running out in");
        Terminal.WriteLine("panic you quickly shove Jewels into");
        Terminal.WriteLine("your bag and make a run for it");
        Terminal.WriteLine("");
        Terminal.WriteLine("");
        Terminal.WriteLine("(continue)");
        currentState = States.distraction;
    }
    
    void distraction2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("in the panic caused you manage to");
        Terminal.WriteLine("escape the city with quite");
        Terminal.WriteLine("some expensive loot");
        Terminal.WriteLine("");
        Terminal.WriteLine("it seems the fortune teller was right");
        Terminal.WriteLine("");
        Terminal.WriteLine("(menu)");
        currentState = States.end;
    }
    
    void Startmenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}