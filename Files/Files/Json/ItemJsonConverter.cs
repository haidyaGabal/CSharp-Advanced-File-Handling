using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Files.Json
{
    public class ItemJsonConverter
    {
        public string Convert(List<ItemModel> data) 
        {
            return JsonSerializer.Serialize(data);
        }
        public List<ItemModel> ConvertBack(string data)
        {
            return JsonSerializer.Deserialize<List<ItemModel>>(data);
        }
    }
}
