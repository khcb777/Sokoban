using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    private bool isSwipe = false;
    private float minSwipeDistance = 50f;
    
    private void Update()
    {
        // Обработка свайпов на мобильных устройствах
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                CheckSwipe();
            }
        }

        // Обработка клавиш для тестирования в редакторе
        if (Input.GetKeyDown(KeyCode.UpArrow)) TryMove(Vector2.up);
        if (Input.GetKeyDown(KeyCode.DownArrow)) TryMove(Vector2.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) TryMove(Vector2.left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) TryMove(Vector2.right);
    }

    private void CheckSwipe()
    {
        if (Vector2.Distance(fingerDownPosition, fingerUpPosition) >= minSwipeDistance)
        {
            Vector2 direction = fingerUpPosition - fingerDownPosition;
            direction.Normalize();

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0) TryMove(Vector2.right);
                else TryMove(Vector2.left);
            }
            else
            {
                if (direction.y > 0) TryMove(Vector2.up);
                else TryMove(Vector2.down);
            }
            
            fingerDownPosition = fingerUpPosition;
        }
    }

    private void TryMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + direction, direction, 0.1f);
        
        if (!hit.collider)
        {
            // Нет препятствий - просто двигаемся
            transform.position += (Vector3)direction;
        }
        else if (hit.collider.CompareTag("Box"))
        {
            // Удар в ящик - проверяем, можем ли его толкнуть
            RaycastHit2D boxHit = Physics2D.Raycast(hit.collider.transform.position + (Vector3)direction, direction, 0.1f);
            
            if (!boxHit.collider)
            {
                // За ящиком пусто - двигаем и игрока, и ящик
                hit.collider.transform.position += (Vector3)direction;
                transform.position += (Vector3)direction;
            }
        }
    }
}