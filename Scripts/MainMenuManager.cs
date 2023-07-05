using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Labirint
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject authorText;
        [SerializeField] private Button nextLevel, repeatLevel, menu, startGame, about;
        [SerializeField] private Text header;
        private static int menuStatus;


        public static int MenuStatus
        {
            private get { return menuStatus; }
            set { menuStatus = value; }
        }
        public void StartGameButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void AboutAuthorButton() 
        {
            menuStatus = 3;
        }
        public void InMenuButton() 
        {
            menuStatus = 0;
        }
        public void NextLevelButton() 
        {
            SceneManager.LoadScene(SceneController.NextLevel);
        }
        public void RepeatLevelButton() 
        {
            SceneManager.LoadScene(SceneController.CurrentLevel);
        }
        public void Exit() 
        {
            Application.Quit();
        }
        private void Update()
        {
            switch (menuStatus)
            {
                case 1:
                    startGame.gameObject.SetActive(false);
                    about.gameObject.SetActive(false);
                    repeatLevel.gameObject.SetActive(false);
                    header.text = "Ура! Вы прошли уровень";
                    nextLevel.gameObject.SetActive(true);
                    menu.gameObject.SetActive(true);
                    break;
                case 2:
                    startGame.gameObject.SetActive(false);
                    about.gameObject.SetActive(false);
                    nextLevel.gameObject.SetActive(false);
                    header.text = "Вы проиграли!";
                    repeatLevel.gameObject.SetActive(true);
                    menu.gameObject.SetActive(true);
                    break;
                case 3:
                    startGame.gameObject.SetActive(false);
                    about.gameObject.SetActive(false);
                    nextLevel.gameObject.SetActive(false);
                    repeatLevel.gameObject.SetActive(false);
                    authorText.SetActive(true);
                    menu.gameObject.SetActive(true);
                    break;
                default:
                    menu.gameObject.SetActive(false);
                    repeatLevel.gameObject.SetActive(false);
                    nextLevel.gameObject.SetActive(false);
                    authorText.SetActive(false);
                    header.text = "Лабиринт";
                    startGame.gameObject.SetActive(true);
                    about.gameObject.SetActive(true);
                    break;
            }
        }
    }
}
