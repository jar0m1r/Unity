using UnityEngine;

public class Hacker : MonoBehaviour {
    //Game Config
    string[] level1Passwords = {"guess", "warning", "alarm"};
    string[] level2Passwords = { "welkom", "computer", "vriendschap" };

    //Game State
    int level;
    string password;
    Screen currentScreen;

    enum Screen {Main, Solve, Win}

	// Use this for initialization
	void Start () {
        ShowMainMenu();
    }

    void ShowMainMenu() {
        currentScreen = Screen.Main;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello, choose your target..");
        Terminal.WriteLine("Press 1 for US Gov");
        Terminal.WriteLine("Press 2 for NL Gov");
        Terminal.WriteLine("Your choice:");
    }

    void OnUserInput(string input) {
        if (input == "menu") {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.Main)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Solve)
        {
            RunSolve(input);
        }
        else
        {
            Terminal.WriteLine("Hmmm try again..");
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2");

        if (isValidLevel) {
            level = int.Parse(input);
            AskForPassword();
        }
    }

    void RunSolve(string input) {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else {
            Terminal.WriteLine("try again..");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Level 1 solved. Well Done!!");
                break;
            case 2:
                Terminal.WriteLine("Level 2 solved. Well Done!!");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void AskForPassword()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Solve;
        SetPassword();
        Terminal.WriteLine("Please enter your password, hint " + password.Anagram());
    }

    void SetPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
