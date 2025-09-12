using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProCeur.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class BaseController : Controller
    {
        private readonly IMediator _mediatR;
        public BaseController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task<ObjectResult> Ok<T>(T request = null) where T : class
        {
            //var model = DeserializeData<T>(request != null ? request.ToString() : "{}");
            var response = await _mediatR.Send(request);
            return new OkObjectResult(response);
        }

        public T DeserializeData<T>(string json) where T : class
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonEmptyStringToIntConverter() },
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            return System.Text.Json.JsonSerializer.Deserialize<T>(json, options);
        }

        // Custom JSON converters for specific handling
        public class JsonEmptyStringToIntConverter : System.Text.Json.Serialization.JsonConverter<int>
        {
            public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    string value = reader.GetString();
                    if (value == "null")
                    {
                        return 0;
                    }
                    return string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32();
                }
                else if (reader.TokenType == JsonTokenType.Null)
                {
                    return 0;
                }

                throw new System.Text.Json.JsonException($"Unexpected token {reader.TokenType} when parsing integer.");
            }

            public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            {
                System.Text.Json.JsonSerializer.Serialize(writer, value);
            }
        }
    }
}
