using System.Collections.Generic;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace FluentSandbox
{
    public class UnitTest1
    {
        [Fact]
        public void WorksOnNetFrameworkButFailsOnCore()
        {
            const string json = @"{
                ""NestedDictionary"": {
                    ""StringProperty"": ""string"",
                    ""IntProperty"": 123
                }
            }";
            
            var expectedResult = new Dictionary<string, object>
            {
                ["NestedDictionary"] = new Dictionary<string, object>
                {
                    ["StringProperty"] = "string",
                    ["IntProperty"] = 123
                }
            };

            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void WorksOnBoth()
        {
            const string json = @"{
                    ""StringProperty"": ""string"",
                    ""IntProperty"": 123
                }";

            var expectedResult = new Dictionary<string, object>
            {
                ["StringProperty"] = "string",
                ["IntProperty"] = 123
            };

            var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
