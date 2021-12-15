using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private void Awake() {

        if (GameManager.instance != null) {
            Destroy(gameObject);
            return;
        }

        PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Ressources
    public List<Sprite> enemySprites;
    public List<int> xpTable;

    // References
    public Player player;
    public Enemy enemy;
    public FloatingTextManager floatingTextManager;

    // Logic
    public int points;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save state
    public void SaveState() {
        string s = "";

        s += "0" + "|";
        s += points.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode) {

        if (!PlayerPrefs.Haskey("SaveState")) {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Receiving the data from file
        points = int.Parse(data[1]);

        Debug.Log("LoadState");
    }
}
