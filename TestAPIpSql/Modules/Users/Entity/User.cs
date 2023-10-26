using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPISql.Modules.Users.Entity
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }

        [NotMapped]
        public ParamsJson? ParamsJsons
        {
            get => _paramJsons == null ? new ParamsJson() : JsonConvert.DeserializeObject<ParamsJson>(_paramJsons,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            set => _paramJsons = JsonConvert.SerializeObject(value, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        [Column("ParamJsons")]
        public string? _paramJsons { get; set; }
    }

    public class ParamsJson { }
}
