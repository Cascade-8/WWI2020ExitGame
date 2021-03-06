using System;
using Character;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class TaskNotificationHandler : MonoBehaviour
    {
        [Header("InteractionCanvas")]
        public Canvas interactionCanvas;

        public GameObject door;
        public GameObject character;
        private static readonly int IsOpenTriggered = Animator.StringToHash("IsOpenTriggered");

        /**
         * <<summary>Selects the Expected Task Message that has to be shown, based on the name of the <param name="coll"></param></summary>
         */
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
                                        message.GetComponent<Text>().text = "\nBinärzahlen\nEntschlüssle die Botschaft!".ToUpper();;
                    break;
                case "TaskCollider2":   title.GetComponent<Text>().text = "Sicherungsschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nArduino\nErmittle die geheime Botschaft des Arduinos!".ToUpper();
                    break;
                case "TaskCollider3":   title.GetComponent<Text>().text = "Netzwerkschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nMastermind!\nKnacke das Passwort!".ToUpper();
                    break;
                case "TaskCollider4":   title.GetComponent<Text>().text = "Transportschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nIP Adresse\nZeige deine CMD-Skills!".ToUpper();
                    break;
                case "TaskCollider5":   title.GetComponent<Text>().text = "Sitzungsschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nWebsite\nFinde den Code".ToUpper();
                    break;
                case "TaskCollider6":   title.GetComponent<Text>().text = "Präsentationsschicht".ToUpper();
                                        message.GetComponent<Text>().text = "\nMinecraft\nLöse die Aufgaben auf dem Minecraftserver!".ToUpper();
                    break;
                case "Door":
                    if (character.GetComponent<CharacterHandler>().GETTasks() != 6) 
                    {
                        title.GetComponent<Text>().text = "Türe öffnen".ToUpper();
                        message.GetComponent<Text>().text = "\nSchließe erst alle Herausforderungen ab!\n".ToUpper();
                        interactionCanvas.transform.Find("InteractionHint").gameObject.SetActive(false);
                    }
                    else
                    {
                        title.GetComponent<Text>().text = "Türe öffnen".ToUpper();
                        message.GetComponent<Text>().text = "\nGehe hindurch!\n".ToUpper();
                        door.GetComponent<Animator>().SetBool(IsOpenTriggered, true);
                        interactionCanvas.transform.Find("InteractionHint").gameObject.SetActive(false);
                    }
                    break;
                default:                title.GetComponent<Text>().text = "".ToUpper();
                                        message.GetComponent<Text>().text = "".ToUpper();
                                        interactionCanvas.transform.Find("InteractionHint").gameObject.SetActive(false);
                                        interactionCanvas.enabled = false;
                    break;
            }
        }
        public void SetCanvasActive(bool state)
        {
            interactionCanvas.enabled = state;
        }
    }
}