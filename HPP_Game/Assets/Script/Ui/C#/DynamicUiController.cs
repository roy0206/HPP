using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DynamicUiController : MonoBehaviour
{
    public static DynamicUiController Instance;
    [SerializeField] UIDocument document;
    VisualElement root;
    public VisualElement Root => root;

    private void Awake()
    {
        Instance = this;
        document = GetComponent<UIDocument>();
        root = document.rootVisualElement;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
