using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DiscordRPG.Tools;

namespace DiscordRPG_Bot_UnitTests
{

    public abstract class TestsBase : IDisposable
    {
        public CommandStringParser CommaParser;
        public CommandStringParser DefaultParser;
        public CommandStringParser DifferentPrefix;
        protected TestsBase()
        {
            CommaParser = new CommandStringParser {
                Delimiter = ',',
                Prefix = '!'
            };

            DifferentPrefix = new CommandStringParser
            {
                Prefix = '?'
            };

            DefaultParser = new CommandStringParser();
        }
        public void Dispose()
        {
            // This is incorrect...
        }
    }

    public class CommandStringParserTests : TestsBase
    {


        [Fact]
        public void ExtractCommandFromValidStringTest()
        {
            string valid = "!edit 123412341234";
            string command = DefaultParser.ExtractCommand(valid);
            Assert.Equal("edit", command);
        }


    }
}
