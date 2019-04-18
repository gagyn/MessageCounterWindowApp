using System.Collections.Generic;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class DaysContainer
    {
        public readonly List<Day> days;
        public readonly Day dayWithMaxNumberOfMessages;

        public DaysContainer(JsonStructureClass jsonObject)
        {
            days = new List<Day>();
            dayWithMaxNumberOfMessages = new Day();

            List<Message> messages = new List<Message>(jsonObject.messages);
            messages.Reverse();

            for (int i = 0; i < messages.Count; i++)
            {
                Day day = new Day(messages, ref i);
                days.Add(day);
                
                if (day.NumberOfMessages > dayWithMaxNumberOfMessages.NumberOfMessages)
                    dayWithMaxNumberOfMessages = day;
            }
        }
    }
}
