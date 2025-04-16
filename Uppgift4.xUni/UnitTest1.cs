using Microsoft.VisualStudio.TestPlatform.TestHost;
using Lexicon_Uppgift4;
using System.Collections.Generic;

namespace Uppgift4.xUni
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true, "(())")]
        [InlineData(true, "{}")]
        [InlineData(true, "[({})]")]
        [InlineData(true, "List<int> list = new List<int>() { 1, 2, 3, 4 }")]
        [InlineData(false, "(()])")]
        [InlineData(false, "[)")]
        [InlineData(false, "{[()}]")]
        [InlineData(false, "List<int> list = new List<int>() { 1, 2, 3, 4 )")]

        public void CheckParenthesisTestWithDifferentinputs(bool returnInput, string input)
        {
            //Arrange



            //Act
            bool answer = LexiconProgram.analyzeString(input);

            //Aknowledge
            Assert.Equal(returnInput, answer);
        }


    }
}