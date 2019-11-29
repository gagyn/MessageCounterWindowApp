using System.Collections.Generic;

namespace MessageCounter.Models
{
    public class ParticipantJson
    {
        public string name { get; set; }
    }

    public class MessageJson
    {
        public string sender_name { get; set; }
        public ulong timestamp_ms { get; set; }
        public string content { get; set; }
        public IEnumerable<PhotoJson> photos { get; set; }
        public IEnumerable<AudioFileJson> audio_files { get; set; }
        public IEnumerable<StickerJson> stickers { get; set; }
        public string type { get; set; }
    }

    public class PhotoJson
    {
        public string uri { get; set; }
        public ulong creation_timestamp { get; set; }
    }

    public class AudioFileJson
    {
        public string uri { get; set; }
        public ulong creation_timestamp { get; set; }
    }

    public class StickerJson
    {
        public string uri { get; set; }
    }

    public class JsonStructureClass
    {
        public IEnumerable<ParticipantJson> participants { get; set; }
        public IEnumerable<MessageJson> messages { get; set; }
        public string title { get; set; }
        public bool is_still_participant { get; set; }
        public string thread_type { get; set; }
        public string thread_path { get; set; }
    }
}
