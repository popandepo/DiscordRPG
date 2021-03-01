using System;
using System.Collections.Generic;
using System.Text;
using DiscordRPG;
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

    }

    /// <summary>
    /// 
    /// </summary>
    public class TestObject
    {
        #region fields
        public int field1 = 10;
        private int field2 = 2;
        public string field3 = "42";
        #endregion

        #region properties
        public int Prop1 { get; set; } = 99;
        public string Prop2 { get; set; } = "this is a string";
        #endregion

        #region constructors
        public TestObject()
        {

        }
        #endregion

        #region methods
        public string TestMethod(int input1)
        {
            return input1.ToString();
        }
        #endregion
    }



}
