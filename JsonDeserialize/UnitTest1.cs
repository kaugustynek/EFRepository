//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace JsonDeserialize
//{
//    [TestClass]
//    public class UnitTest1
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//        }
//    }
//}

using System;
using System.Diagnostics;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit;

namespace JsonDeserialize
{
    [TestClass]
    public class JsonDeserializerTests
    {
        private const string ValidJson = "{\"Temperature\": 100, \"DewPoint\": 13.4, \"Humidity\": 40}";
        private const string InvalidJson = "";
        private const string InvalidJson2 = "{\"Temperaturesdfsf\": 1dsf, \"DewPoint\": 13.4, \"Humidity\": 40}";
        
        [TestMethod]
        public void When_valid_json_is_passed_it_deserialize_it()
        {
            var result = ValidJson.DeserializeEnvironemnt();
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnvironment>();
            result.DewPoint.Should().Be(13.4);
            result.Temperature.Should().Be(100);
            result.Humidity.Should().Be(40);
        }

        [TestMethod]
        public void When_invalid_json_is_passed_it_returns_null()
        {
            IEnvironment result = null;
            Assert.DoesNotThrow(() => result = InvalidJson.DeserializeEnvironemnt());
            result.Should().BeNull();
        }

        [TestMethod]
        public void When_invalid_json2_is_passed_it_returns_null()
        {
            IEnvironment result = null;
            Assert.DoesNotThrow(() => result = InvalidJson2.DeserializeEnvironemnt());
            result.Should().BeNull();
        }
    }


    public static class StringExtension
    {
        public static IEnvironment DeserializeEnvironemnt(this string input)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnvironment>(input, new EnvironmentConverter());
            }
            catch
            {
                Trace.TraceError("failed to deserialize following json '{0}' to Environment", input);
            }
            return null;
        }
        private class EnvironmentConverter : CustomCreationConverter<IEnvironment>
        {
            public override IEnvironment Create(Type objectType)
            {
                return new Environment();
            }
        }
        private class Environment : IEnvironment
        {
            public double Temperature { get; set; }
            public double Humidity { get; set; }
            public double DewPoint { get; set; }
        }
    }
    public interface IEnvironment
    {
        double Temperature { get; }
        double Humidity { get; }
        double DewPoint { get; }
    }
}