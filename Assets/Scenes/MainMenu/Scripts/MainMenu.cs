using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MainMenu : MonoBehaviour
{
    [SerializeField] UIDocument mainMenuDocument;

    private Button buttonPlay;
    private Button buttonSettings;
    private Button buttonQuit;


    #region .  Awake()  .
    private void Awake()
    {
        VisualElement root = mainMenuDocument.rootVisualElement;

        buttonPlay     = root.Q<Button>("buttonPlay");
        buttonSettings = root.Q<Button>("buttonSettings");
        buttonQuit     = root.Q<Button>("buttonQuit");

        buttonPlay    .clickable.clicked += Play;
        buttonSettings.clickable.clicked += Settings;
        buttonPlay    .clickable.clicked += Quit;

    }   // Awake()
    #endregion


    #region .  Play()  .
    private void Play()
    {
        SceneManager.LoadScene("GameScene");
        //SceneManager.LoadScene("FirstAndThirdPerson");

    }   // Play()
    #endregion


    #region .  Settings()  .
    private void Settings()
    {

    }   // Settings()
    #endregion


    #region .  Quit()  .
    private void Quit()
    {

    }   // Quit()
    #endregion


}   // class MainMenu
