using System.Collections.Generic;
using MessageCounterBackend.JsonStructure;
using MessageCounterBackend.StatContainers.ListTypesClasses;

namespace MessageCounterBackend.StatContainers
{
    public class DaysContainer : Container
    {
        public List<Day> Days { get; }
        public Day DayWithMaxNumberOfMessages { get; }

        public DaysContainer(JsonStructureClass jsonObject) : this(jsonObject.messages as List<Message>) { }
        public DaysContainer(List<Message> messages)
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
