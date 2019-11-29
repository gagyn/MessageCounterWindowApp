using System.Collections.Generic;

namespace MessageCounterBackend.JsonStructure
{
    public class Participant
    {
        public string name { get; set; }
    }

    public class Message
    {
        public string sender_name { get; set; }
        public ulong timestamp_ms { get; set; }
        public string content { get; set; }
        public IEnumerable<Photo> photos { get; set; }
        public IEnumerable<AudioFile> audio_files { get; set; }
        public IEnumerable<Sticker> stickers { get; set; }
        public string type { get; set; }
    }

    public class Photo
    {
        public string uri { get; set; }
        public ulong creation_timestamp { get; set; }
    }

    public class AudioFile
    {
        public string uri { get; set; }
        public ulong creation_timestamp { get; set; }
    }

    public class Sticker
    {
        public string uri { get; set; }
    }

    public class JsonStructureClass
    {
        public IEnumerable<Participant> participants { get; set; }
        public IEnumerable<Message> messages { get; set; }
        public string title { get; set; }
        public bool is_still_participant { get; set; }
        public string thread_type { get; set; }
        public string thread_path { get; set; }
    }
}
