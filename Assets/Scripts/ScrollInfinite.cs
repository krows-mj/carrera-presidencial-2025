using UnityEngine;
using UnityEngine.UI;

public class ScrollInfinite : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public float elementWidth = 300f; // ajusta según tu elemento
    public int totalElements;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float posX = content.anchoredPosition.x;

        if (posX < -elementWidth) // se ha desplazado demasiado a la derecha
        {
            MoveFirstToLast();
        }
        else if (posX > 0) // se ha desplazado demasiado a la izquierda
        {
            MoveLastToFirst();
        }
    }

    void MoveFirstToLast()
    {
        if (content.childCount < 2) return;

        Transform first = content.GetChild(0);
        first.SetAsLastSibling();

        Vector2 newPos = content.anchoredPosition;
        newPos.x += elementWidth;
        content.anchoredPosition = newPos;
    }

    void MoveLastToFirst()
    {
        if (content.childCount < 2) return;

        Transform last = content.GetChild(content.childCount - 1);
        last.SetAsFirstSibling();

        Vector2 newPos = content.anchoredPosition;
        newPos.x -= elementWidth;
        content.anchoredPosition = newPos;
    }
}
