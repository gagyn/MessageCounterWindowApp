using System.Collections.Generic;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class DaysContainer
    {
        public List<Day> Days { get; private set; }
        public Day DayWithMaxNumberOfMessages { get; private set; }

        public DaysContainer(JsonStructureClass jsonObject) => InitObject((List<Message>)jsonObject.messages);
        public DaysContainer(List<Message> messages) => InitObject(messages);
        private void InitObject(List<Message> messages)
        {
            Days = new List<Day>();
            DayWithMaxNumberOfMessages = new Day();

            messages.Reverse();

            for (int i = 0; i < messages.Count; i++)
            {
                Day day = new Day(messages, ref i);
                Days.Add(day);

                if (day.NumberOfMessages > DayWithMaxNumberOfMessages.NumberOfMessages)
                    DayWithMaxNumberOfMessages = day;
            }

            Days.Reverse();
        }
    }
}
