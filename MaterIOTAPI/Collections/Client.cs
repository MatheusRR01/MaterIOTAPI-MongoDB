using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MaterIOTAPI.Collections;

[Table("client")]
[BsonIgnoreExtraElements]
public class Client
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("nome")]
    [JsonPropertyName("Nome")]
    public string Nome { get; set; }

    [BsonElement("cpf")]
    [JsonPropertyName("Cpf")]
    public string Cpf { get; set; }

    [BsonElement("telefone")]
    [JsonPropertyName("Telefone")]
    public string Telefone { get; set; }

    [BsonElement("endereco")]
    [JsonPropertyName("Endereco")]
    public string Endereco { get; set; }

    [BsonElement("criado_em")]
    [JsonPropertyName("Criado_em")]
    public string Criado_em { get; set; }
}