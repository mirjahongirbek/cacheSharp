using System;
using System.Collections.Generic;

namespace Entity
{
    [Serializable]
   public class AddModal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, dynamic> Data { get; set; }
    }
}
