using DiscordRPG;
using System.Collections.Generic;
using Xunit;

namespace DiscordRPG_Bot_UnitTests
{
    public class JSONhandlerTests
    {

        [Fact]
        public void ObjectPropertiesAreTranslatedTest()
        {
            /*Description*/
            var tObj = new TestObject();
            var expected = @"{""properties"":[{""name"":""Prop1"",""value"":99,""type"":""Int32""},{""name"":""Prop2"",""value"":""this is a string"",""type"":""String""}]}";
            var result = JSONhandler.GetProperties(tObj);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void ObjectFieldsAreTranslatedTest()
        {
            var tObj = new TestObject();
            var expected = @"{""fields"":[{""name"":""field1"",""value"":10,""type"":""Int32""},{""name"":""field2"",""value"":2,""type"":""Int32""},{""name"":""field3"",""value"":""42"",""type"":""String""}]}";
            var result = JSONhandler.GetFields(tObj);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void PropWithArrayTest()
        {
            var tObj = new TestArrayObject();
            var expected = @"{""properties"":[{""name"":""IntArray1"",""value"":[1,2,3,4],""type"":""Int32[]""},{""name"":""Empty"",""value"":[],""type"":""Int32[]""},{""name"":""StringList"",""value"":[""one"",""two""],""type"":""List<String>""}]}";
            var result = JSONhandler.GetProperties(tObj);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void fieldWithArrayTest()
        {
            var tObj = new TestArrayObject();
            var expected = @"{""fields"":[{""name"":""intArray1"",""value"":[1,2,3,4],""type"":""Int32[]""},{""name"":""empty"",""value"":[],""type"":""Int32[]""},{""name"":""stringList"",""value"":[""one"",""two""],""type"":""List<String>""}]}";
            var result = JSONhandler.GetFields(tObj);
            Assert.Equal(expected, result);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class TestObject
    {
        #region fields
        public int field1 = 10;
        public int field2 = 2;
        public string field3 = "42";
        #endregion

        #region properties
        public int Prop1 { get; set; } = 99;
        public string Prop2 { get; set; } = "this is a string";
        #endregion

        #region methods
        public string TestMethod(int input1)
        {
            return input1.ToString();
        }
        #endregion
    }


    public class TestArrayObject
    {
        #region fields
        public int[] intArray1 = new int[] { 1, 2, 3, 4 };
        public int[] empty = new int[] { };
        public List<string> stringList = new List<string> { "one", "two" };
        #endregion

        #region properties
        public int[] IntArray1 { get; set; } = new int[] { 1, 2, 3, 4 };
        public int[] Empty { get; set; } = new int[] { };
        public List<string> StringList { get; set; } = new List<string> { "one", "two" };
        #endregion

        #region methods
        public string TestMethod(int input1)
        {
            return input1.ToString();
        }
        #endregion
    }


}
