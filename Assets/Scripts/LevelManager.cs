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
    
    // Вызов этого метода при нажатии кнопки "Рестарт" или при поражении
    public void OnRestartButtonClicked()
    {
        ReloadLevel();
    }
}