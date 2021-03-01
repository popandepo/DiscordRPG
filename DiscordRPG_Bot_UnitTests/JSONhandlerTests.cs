using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DiscordRPG_Bot_UnitTests
{
    public class JSONhandlerTests
    {

        [Fact]
        public void ObjectPropertiesAreTranslatedTest()
        {
            /*Description*/
            
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class name
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
        public name()
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
