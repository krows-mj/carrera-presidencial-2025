using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ScrollSnap : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public float snapSpeed = 10f;

    [SerializeField] private float elementSpacing; // ancho total por elemento (incluyendo spacing)
    [SerializeField] private bool isSnapping = false;
    [SerializeField] private bool isDragging = false;

    private void Awake()
    { 
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //CalculateSpacing();
        elementSpacing = content.GetChild(0).GetComponent<RectTransform>().rect.width + 
                          content.GetComponent<HorizontalLayoutGroup>().spacing;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDragging && !isSnapping && Mathf.Abs(scrollRect.velocity.x) < 50f)
        {
            StartCoroutine(SnapToClosest());
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("¡Comenzó a arrastrar!");
        isDragging = true;
        isSnapping = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("terminó de arrastrar!");
        isDragging = false;
    }

    void CalculateSpacing()
    {
        if (content.childCount < 2) return;

        var child0 = content.GetChild(0).GetComponent<RectTransform>();
        var child1 = content.GetChild(1).GetComponent<RectTransform>();
        elementSpacing = Mathf.Abs(child1.anchoredPosition.x - child0.anchoredPosition.x);
    }

    IEnumerator SnapToClosest()
    {
        isSnapping = true;

        float contentX = content.anchoredPosition.x;
        float targetIndex = Mathf.Round(contentX / elementSpacing);
        float targetX = targetIndex * elementSpacing;

        while (Mathf.Abs(content.anchoredPosition.x - targetX) > 0.1f)
        {
            float newX = Mathf.Lerp(content.anchoredPosition.x, targetX, Time.deltaTime * snapSpeed);
            content.anchoredPosition = new Vector2(newX, content.anchoredPosition.y);
            yield return null;
        }

        content.anchoredPosition = new Vector2(targetX, content.anchoredPosition.y);
        isSnapping = false;
    }
}
