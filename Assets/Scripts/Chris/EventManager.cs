using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Chris{
    public sealed class EventManager : GenericSingleton<EventManager>
    {
        Dictionary<string, UnityEvent> _eventDictionary;
        
        public override void Awake(){
            base.Awake();
            if(Instance._eventDictionary == null){
                Instance._eventDictionary = new Dictionary<string, UnityEvent>();
            }
        }
        private void StartListening(string eventName, UnityAction listener){
            UnityEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent)){
                //Event name is in dictionary
                thisEvent.AddListener(listener);
            }else{
                thisEvent = new UnityEvent();
                thisEvent.AddListener(listener);
                Instance._eventDictionary.Add(eventName, thisEvent);
            } 
        }
        private void StopListening(string eventName, UnityAction listener){
            if (Instance._eventDictionary == null) return;
            UnityEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent)){
                thisEvent.RemoveListener(listener);
            }
        }
        private void TriggerEvent(string eventName){
            UnityEvent thisEvent = null;
            if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent)){
                thisEvent.Invoke();
            } 
        }
    }
}
