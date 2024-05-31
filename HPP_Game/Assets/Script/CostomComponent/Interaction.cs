using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public class InteractionComment
{
    public KeyCode key;
    public string massage;
}

public class Interaction : MonoBehaviour
{
    [SerializeField] float distance;
    [SerializeField] InteractionComment[] interactions;
    [SerializeField] UIDocument interactionUiFile;

    Player player;
    VisualElement feedbackUi;
    Label text;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        feedbackUi = interactionUiFile.rootVisualElement.Q<VisualElement>("Frame");
        text = feedbackUi.Q<Label>("Text");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUi();
    }

    void FixedUpdate()
    {
        if (feedbackUi.style.display == DisplayStyle.None
            && Vector2.Distance(player.transform.position, transform.position) <= distance)
            EnableUi();
        else if(feedbackUi.style.display == DisplayStyle.Flex
            && Vector2.Distance(player.transform.position, transform.position) > distance)
            DisableUi();
    }
    void EnableUi()
    {
        feedbackUi.style.display = DisplayStyle.Flex;

        text.text = interactions[0].key.ToString() + " : " + interactions[0].massage;
        for(int i = 1; i < interactions.Length; i++)
        {
            text.text += "\n" + interactions[i].key.ToString() + " : " + interactions[i].massage;
        }
    }
    void UpdateUi()
    {
        if (feedbackUi.style.display == DisplayStyle.Flex) {
            Vector3 worldPos = Camera.main.WorldToScreenPoint(transform.position) * (1080 / Screen.height);
            feedbackUi.style.left = worldPos.x - (feedbackUi.layout.width / 2);
            feedbackUi.style.top = (1080 - worldPos.y);
        }
    }

    void ManageInput()
    {
        foreach (var interaction in interactions)
        {
            if (Input.GetKeyDown(interaction.key))
            {

            }
        }
    }

    void DisableUi()
    {
        feedbackUi.style.display = DisplayStyle.None;
    }
}
