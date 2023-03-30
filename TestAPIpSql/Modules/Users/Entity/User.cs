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
        public ParamsJson? paramsJson
        {
            get => _param_jsons == null ? new ParamsJson() : JsonConvert.DeserializeObject<ParamsJson>(_param_jsons,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            set => _param_jsons = JsonConvert.SerializeObject(value, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        [Column("param_jsons")]
        public string? _param_jsons { get; set; }
    }

    public class ParamsJson { }
}
