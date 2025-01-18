using System;
using System.Collections.Generic;

namespace Scripts_2
{
    public static class EventManager
    {
        // Dictionary to store events and their associated listeners
        private static readonly Dictionary<string, Action> EventDictionary = new();

        // Subscribe a listener to an event
        public static void StartListening(string eventName, Action listenerAction)
        {
            // Check if the event already exists in the dictionary
            if (EventDictionary.ContainsKey(eventName))
                // If the event exists, add the new listener to the existing event
                EventDictionary[eventName] += listenerAction;
            else
                // If the event does not exist, create a new entry in the dictionary
                EventDictionary[eventName] = listenerAction;
        }

        // Unsubscribe a listener from an event
        public static void StopListening(string eventName, Action listenerAction)
        {
            // Check if the event exists in the dictionary
            if (EventDictionary.ContainsKey(eventName))
            {
                // Remove the listener from the event
                EventDictionary[eventName] -= listenerAction;

                // If no listeners remain, remove the event from the dictionary
                if (EventDictionary[eventName] == null) EventDictionary.Remove(eventName);
            }
        }

        // Trigger an event by name
        public static void TriggerEvent(string eventName)
        {
            // Check if the event exists in the dictionary
            if (EventDictionary.ContainsKey(eventName))
                // Invoke all listeners subscribed to the event
                EventDictionary[eventName]?.Invoke();
        }
    }
}