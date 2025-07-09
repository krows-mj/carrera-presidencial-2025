using UnityEngine;
using UnityEngine.UI;
public class CardController : MonoBehaviour
{
    [SerializeField] private string nameCandidate;
    [SerializeField] private Sprite startImage, selectedImage;
    private Image imgCandidate;
    private GameObject SelectedCandidate;
    private GameObject Stamp;

    private void Awake()
    {
        imgCandidate = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
        SelectedCandidate = gameObject.transform.GetChild(1).gameObject;
        Stamp = gameObject.transform.GetChild(2).gameObject;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        imgCandidate.sprite = startImage;
        SelectedCandidate.SetActive(false);
        Stamp.SetActive(false);
    }

    // Update is called once per frame
    //void Update(){}

    public void ActiveSelectedCandidate()
    {
        SelectedCandidate.SetActive(true);
        imgCandidate.sprite = selectedImage;
    }
    public void DeactiveSelectedCandidate()
    {
        SelectedCandidate.SetActive(false);
        imgCandidate.sprite = startImage;
    }
    public void DisableCandidate()
    {
        startImage = selectedImage;
        imgCandidate.sprite = selectedImage;
        Stamp.SetActive(true);
    }

    //Getters and Setters
    public string getNameCandidate() { return nameCandidate; }
}
