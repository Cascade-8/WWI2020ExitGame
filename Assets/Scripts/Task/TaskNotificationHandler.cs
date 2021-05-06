using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class TaskNotificationHandler : MonoBehaviour
    {
        [Header("InteractionCanvas")]
        public Canvas interactionCanvas;
        
        public void SelectTaskMessage(string coll)
        {
            interactionCanvas.enabled = true;
            var hint = interactionCanvas.transform.Find("InteractionHint").gameObject;
            var message = interactionCanvas.transform.Find("InteractionMessage").gameObject;
            var title = interactionCanvas.transform.Find("InteractionTitle").gameObject;
            hint.SetActive(true);
            
            // Re-render
            hint.GetComponent<Text>().text = "";
            hint.GetComponent<Text>().text = "Drücke die Leertaste zum Interagieren!";
            message.GetComponent<Text>().text = "";
            title.GetComponent<Text>().text = "";
            
            switch (coll)
            {
                case "TaskCollider1":   title.GetComponent<Text>().text = "Bitübertragung".ToUpper();
                                        message.GetComponent<Text>().text = "Finde die geheime Botschaft\nund gebe sie in das Gerät ein".ToUpper();;
                    break;
                case "TaskCollider2":   title.GetComponent<Text>().text = "Sicherungsschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nKabel verbinden\nPlease execute the following task!".ToUpper();
                    break;
                case "TaskCollider3":   title.GetComponent<Text>().text = "Netzwerkschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nMastermind!\nKnacke das Passwort".ToUpper();
                    break;
                case "TaskCollider4":   title.GetComponent<Text>().text = "Transportschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nIP Adresse der DHBW rausfinden\nPlease execute the following task!".ToUpper();
                    break;
                case "TaskCollider5":   title.GetComponent<Text>().text = "Sitzungsschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nWebsite Moritz\nPlease execute the following task!".ToUpper();
                    break;
                case "TaskCollider6":   title.GetComponent<Text>().text = "Präsentationsschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nTBD\nPlease execute the following task!".ToUpper();
                    break;
                case "Door":            title.GetComponent<Text>().text = "Türe öffnen".ToUpper();
                                        message.GetComponent<Text>().text = "\nSchließe erst alle Herausforderungen ab!\n".ToUpper();
                                    interactionCanvas.transform.Find("InteractionHint").gameObject.SetActive(false);
                    break;
                default:                title.GetComponent<Text>().text = "".ToUpper();
                                        message.GetComponent<Text>().text = "".ToUpper();
                                    interactionCanvas.transform.Find("InteractionHint").gameObject.SetActive(false); 
                    break;
            }
        }
        public void SetCanvasActive(bool state)
        {
            interactionCanvas.enabled = state;
        }
    }
}