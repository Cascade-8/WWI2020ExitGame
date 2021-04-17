using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class TaskHandler : MonoBehaviour
    {
        [Header("Tasks")]
        public GameObject tasks;

        [Header("InteractionCanvas")]
        public Canvas interactionCanvas;
        public Text interactionTitel;
        public Text interactionMessage;
        public Text interactionHint;
        public void SelectTaskMessage(Collider2D coll)
        {
            interactionCanvas.enabled = true;
            interactionHint.enabled = true;
            switch (coll.name)
            {
                case "TaskArea1": interactionTitel.text = "Bitübertragung".ToUpper();
                    HandleTaskScreen(0);
                    interactionMessage.text = "\nFinde die geheime Botschaft\nund gebe sie in das Gerät ein".ToUpper();
                    break;
                case "TaskArea2": interactionTitel.text = "Sicherungsschicht".ToUpper();
                    HandleTaskScreen(1);
                    interactionMessage.text = "\nKabel verbinden\nPlease execute the following task!".ToUpper();
                    break;
                case "TaskArea3": interactionTitel.text = "Netzwerkschicht".ToUpper();
                    HandleTaskScreen(2);
                    interactionMessage.text = "\nMastermind!\nKnacke das Passwort".ToUpper();
                    break;
                case "TaskArea4": interactionTitel.text = "Transportschicht".ToUpper();
                    HandleTaskScreen(3);
                    interactionMessage.text = "\nIP Adresse der DHBW rausfinden\nPlease execute the following task!".ToUpper();
                    break;
                case "TaskArea5": interactionTitel.text = "Sitzungsschicht".ToUpper();
                    HandleTaskScreen(4);
                    interactionMessage.text = "\nWebsite Moritz\nPlease execute the following task!".ToUpper();
                    break;
                case "TaskArea6": interactionTitel.text = "Präsentationsschicht".ToUpper();
                    HandleTaskScreen(5);
                    interactionMessage.text = ("\nTBD\nPlease execute the following task!").ToUpper();
                    break;
                case "Door": interactionTitel.text = "Türe öffnen".ToUpper();
                    interactionMessage.text = "\n Sie müssen zuerst alle Aufgaben erfüllen!\n".ToUpper();
                    interactionHint.enabled = false;
                    break;
            }
        }
        public void HandleTaskScreen(int selector)
        {
            if (selector == -1)
            {
                tasks.transform.GetChild(0).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                tasks.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                tasks.transform.GetChild(2).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                tasks.transform.GetChild(3).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                tasks.transform.GetChild(4).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                tasks.transform.GetChild(5).transform.GetChild(0).GetComponent<Renderer>().enabled = false;
                interactionTitel.text = "";
                interactionMessage.text = "";
                interactionCanvas.enabled = false;
            }
            else
            {
                tasks.transform.GetChild(selector).transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            }
        }
        public void HandleInteraction()
        {
            // Future Stuff
        }
    }
}