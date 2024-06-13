using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using UnityEditor.ShaderKeywordFilter;
using Unity.VisualScripting;

[Serializable]
public class InteractionComment
{
    public KeyCode key;
    public string massage;
}

public class InteractionEvent : UnityEvent
{
    public KeyCode keyCode;
    public string text;
}

public class Interaction : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] List<(UnityAction, KeyCode, string, int, float)> interactions = new();
    [SerializeField] UIDocument interactionUiFile;

    Player player;
    VisualElement feedbackUi;
    Label text;

    public void AddInteraction(UnityAction function, KeyCode key, string text, int amount, float hold)
    {
        interactions.Add((function, key, text, amount, hold));
        UpdateText();
    }

    public void RemoveInteraction(KeyCode removingKey)
    {
        interactions.Remove(interactions.Find(interaction => interaction.Item2 == removingKey));
        UpdateText();
    }
    public void RemoveInteraction((UnityAction function, KeyCode key, string text, int amount, float hold) removingInteraction)
    {
        interactions.Remove(removingInteraction);
        UpdateText();
    }
    public void RemoveAllInteraction()
    {
        interactions.Clear();
        UpdateText();
    }

    void Awake()
    {
        Transform UiParent = GameObject.Find("UI").transform;
        interactionUiFile = Instantiate(UiParent.Find("InteractionUi").gameObject, UiParent).GetComponent<UIDocument>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        feedbackUi = interactionUiFile.rootVisualElement.Q<VisualElement>("Frame");
        
        text = feedbackUi.Q<Label>("Text");

        feedbackUi.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUi();
        ManageInput();
    }

    void FixedUpdate()
    {
        if (feedbackUi.style.display == DisplayStyle.None
            && Vector2.Distance(player.transform.position, transform.position) <= distance
            && interactions.Count > 0)
            EnableUi();
        else if(feedbackUi.style.display == DisplayStyle.Flex
            && Vector2.Distance(player.transform.position, transform.position) > distance
            || interactions.Count == 0)
            DisableUi();
    }

    void EnableUi()
    {
        feedbackUi.style.display = DisplayStyle.Flex;

        UpdateText();
    }

    void UpdateText()
    {
        if (interactions.Count == 0) return;
        text.text = interactions[0].Item2.ToString() + " : " + interactions[0].Item3;
        for (int i = 1; i < interactions.Count; i++)
        {
            text.text += "\n" + interactions[i].Item2.ToString() + " : " + interactions[i].Item3;
        }

    }

    void UpdateUi()
    {
        if (feedbackUi.style.display == DisplayStyle.Flex) {
            Vector3 worldPos = Camera.main.WorldToScreenPoint(transform.position) * (1080f / Screen.height);
            feedbackUi.style.left = worldPos.x - (feedbackUi.layout.width / 2);
            feedbackUi.style.top = (1080f - worldPos.y);
        }
    }

    public float holding = 0;
    void ManageInput()
    {
        for (int i = 0; i < interactions.Count && distance >= Vector2.Distance(player.transform.position, transform.position); i++)
        {
            if (Input.GetKeyDown(interactions[i].Item2)) holding = 0;
            else if (Input.GetKey(interactions[i].Item2) && holding != -1)
            {
                print("clicking");
                holding += Time.deltaTime;
                if(holding >= interactions[i].Item5)
                {
                    holding = -1;
                    interactions[i].Item1.Invoke();
                    interactions[i] = new(
                        interactions[i].Item1,
                        interactions[i].Item2,
                        interactions[i].Item3,
                        interactions[i].Item4 - 1,
                        interactions[i].Item5
                        );
                    if (interactions[i].Item4 <= 0)
                    {
                        RemoveInteraction(interactions[i]);
                    }
                    print("Interact");

                }
            }
            else if (Input.GetKeyUp(interactions[i].Item2))
            {
                holding = -1;
            }
            
        }

    }

    void DisableUi()
    {
        feedbackUi.style.display = DisplayStyle.None;
    }

    public void TestFunc1() => print("first");
    public void TestFunc2() => print("second");
    
}
