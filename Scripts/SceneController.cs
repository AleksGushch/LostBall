using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Labirint
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private GameObject[] labirints;
        [SerializeField] private GameObject mainUIobjects;
        [SerializeField] private Transform ball;
        [SerializeField] private Text timerText;
        [SerializeField] private float levelTime;
        private WinTrigger winTrigger;
        private LooseTrigger[] looseTrigger;
        private GameObject respawnPoint;
        private static int nextLevel, currentLevel, currentLabirint;
        private static bool restart;
        private int numberLabirint;
        private float currentTime;
        private bool cutSceneTrigger;
        public static int NextLevel 
        {
            get { return nextLevel; }
            private set { nextLevel = value; }
        }
        public static int CurrentLevel 
        {
            get { return currentLevel; }
            private set { currentLevel = value; }
        }
        /// <summary>
        /// Этот метод запускает основную сцену по сигналу эмиттера после проигрывания кат-сцены
        /// </summary>
        public void PostStartCutScene() 
        { 
            mainUIobjects.SetActive(true);
            cutSceneTrigger= true;
        }
        private void Start()
        {
            LabirintRandom();
            labirints[numberLabirint].SetActive(true);
            currentLevel = SceneManager.GetActiveScene().buildIndex;
            winTrigger = FindObjectOfType<WinTrigger>();
            looseTrigger = FindObjectsOfType<LooseTrigger>();
            respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint");
            ball.position=respawnPoint.transform.position;
            currentLabirint = numberLabirint;
            restart= false;
            mainUIobjects.SetActive(false);
        }

        private void Update()
        {
            Timer();
            LoadFinishScene();
        }
        /// <summary>
        /// Этот метод загружает меню победы/поражения после входа в триггер победы/поражения
        /// </summary>
        private void LoadFinishScene()
        {
            if (winTrigger.CheckWinZone)
            {
                SceneManager.LoadScene(0);
                winTrigger.CheckWinZone = false;
                MainMenuManager.MenuStatus = 1;
                if (currentLevel == SceneManager.sceneCountInBuildSettings - 1)
                {
                    nextLevel = 1;//индекс сцены первого уровня
                }
                else
                {
                    nextLevel = currentLevel + 1;
                }
            }
            foreach (var loose in looseTrigger)
            {
                if (loose.CheckLooseZone)
                {
                    SceneManager.LoadScene(0);
                    loose.CheckLooseZone = false;
                    MainMenuManager.MenuStatus = 2;
                    restart = true;
                    cutSceneTrigger = false;
                }
            }
        }
        /// <summary>
        /// Метод запускает рандомную подборку лабиринта.
        /// </summary>
        private void LabirintRandom() 
        {
            if (restart)
            {
                numberLabirint = currentLabirint;
            }
            else
            {
                numberLabirint = Random.Range(0, labirints.Length);
            }
        }
        private void Timer() 
        {
            if (cutSceneTrigger)
            {
                currentTime += Time.deltaTime;
                timerText.text = (levelTime - currentTime).ToString("F2");
                if (currentTime >= levelTime)
                {
                    SceneManager.LoadScene(0);
                    MainMenuManager.MenuStatus = 2;
                    restart = true;
                    currentTime = 0;
                    cutSceneTrigger= false;
                }
            }
        }
    }
}
