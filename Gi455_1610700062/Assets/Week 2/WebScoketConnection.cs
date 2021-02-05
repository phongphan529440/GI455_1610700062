using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

namespace programChat 
{
    public class WebScoketConnection : MonoBehaviour
    {
        public GameObject ConnectionUI;
        public GameObject ChatBox;
        public GameObject ChatPanel;

        
        
        
        private string otherString; //server msg
 
        public InputField MsgInput;
        public InputField urlInputfield;
        //public InputField portInputfield;

        private WebSocket websocket;
        // Start is called before the first frame update
        void Start()
        {
           ConnectionUI.gameObject.SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            
           
        }
        private void OnDestroy()
        {
            if (websocket != null)
            {
                websocket.Close();
                websocket.OnMessage -= OnMessage;
            }
        }
        public void ClickToConnenct()
        {
            websocket = new WebSocket($"ws://{urlInputfield.text}:49151/");
            websocket.OnMessage += OnMessage; // Function รับข้อความ
            websocket.Connect();

            ConnectionUI.gameObject.SetActive(false);
            ChatPanel.gameObject.SetActive(true);
        }
        public void SendMessage()
        {
            websocket.Send(MsgInput.text);
            GameObject msgContainer = Instantiate(ChatBox, ChatPanel.transform);
            msgContainer.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleRight;
            Text prefabText = msgContainer.transform.GetChild(0).GetComponent<Text>();
            prefabText.alignment = TextAnchor.MiddleRight;
            prefabText.text = MsgInput.text; 
        }

        public void OnMessage(object sender,MessageEventArgs messageEventArgs)
        {
            Debug.Log("Receive msg : " + messageEventArgs.Data);
            otherString = messageEventArgs.Data;
            GameObject msgContainer = Instantiate(ChatBox, ChatPanel.transform);
            msgContainer.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.MiddleLeft;
            Text prefabText = msgContainer.transform.GetChild(0).GetComponent<Text>();
            prefabText.alignment = TextAnchor.MiddleLeft;
            prefabText.text = otherString;

        }
    }
}


