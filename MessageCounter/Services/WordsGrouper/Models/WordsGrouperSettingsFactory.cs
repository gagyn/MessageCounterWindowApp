using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MessageCounter.Services.WordsGrouper.Models
{
    public class WordsGrouperSettingsFactory
    {
        public WordsGrouperSettings Create(string fileContent)
        {
            return JsonConvert.DeserializeObject<WordsGrouperSettings>(fileContent);
        }
    }
}
