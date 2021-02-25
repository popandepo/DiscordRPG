using DiscordRPG;
using System;
using Xunit;

namespace DiscordRPG_Bot_UnitTests
{

    public abstract class TestsBase : IDisposable
    {
        public CommandStringParser CommaParser;
        public CommandStringParser DefaultParser;
        public CommandStringParser DifferentPrefix;
        protected TestsBase()
        {
            CommaParser = new CommandStringParser
            {
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


        [Fact]
        public void NoArgumentsAfterCommandTrowsErrorTest()
        {
            string invalid = "!command";
            string content;
            Assert.Throws<Exception>(() => content = DefaultParser.RemoveCommand(invalid));
        }


        [Fact]
        public void SpacesBeforeCommandAreIgnoredTest()
        {
            string valid = "      !command content";
            string command = DefaultParser.ExtractCommand(valid);
            Assert.Equal("command", command);
        }


        [Fact]
        public void ExtractBodyFromValidStringTest()
        {
            string valid = "   !thisIsACommand body arguments follow command";
            string body = DefaultParser.RemoveCommand(valid);
            Assert.Equal("body arguments follow command", body);
        }


        [Fact]
        public void CustomDelimiterCommandExtractTest()
        {
            string valid = "   !thisIsACommand,body,arguments,follow,command";
            string command = CommaParser.ExtractCommand(valid);
            Assert.Equal("thisIsACommand", command);
        }


        [Fact]
        public void CustomDelimiterCommandRemoveTest()
        {
            string valid = "   !thisIsACommand,body,arguments,follow,command";
            string body = CommaParser.RemoveCommand(valid);
            Assert.Equal("body,arguments,follow,command", body);
        }


    }
}
