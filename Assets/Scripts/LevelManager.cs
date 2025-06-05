using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Метод для перезагрузки текущего уровня
    public void ReloadLevel()
    {
        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Перезагружаем сцену
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Load(int idScene)
    { 
        SceneManager.LoadScene(idScene);
    }
}