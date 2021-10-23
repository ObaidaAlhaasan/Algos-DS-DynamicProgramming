using Data.Structure.StringManipulation;
using Xunit;

namespace Data.Structure.Tests.StringManipulation
{
    public class StringManipulationTests
    {
        [Fact]
        public void NumOfVowels()
        {
            Assert.Equal(3, StringManipulations.GetVowelCount("hello world!"));
        }

        [Fact]
        public void ReverseString()
        {
            Assert.Equal("!dlrow olleh", StringManipulations.ReverseString("hello world!"));
            Assert.Equal("!dlrow", StringManipulations.ReverseString("world!"));
        }


        [Fact]
        public void ReverseOrderOfWords()
        {
            Assert.Equal("beautiful are Trees", StringManipulations.ReverseOrderOfWords("Trees are beautiful"));
            Assert.Equal("beautiful", StringManipulations.ReverseOrderOfWords("beautiful"));
        }

        [Fact]
        public void IsRotationOfAnotherString()
        {
            Assert.Equal(true, StringManipulations.IsRotationOfAnotherString("ABCD", "DABC"));
            Assert.Equal(true, StringManipulations.IsRotationOfAnotherString("ABCD", "CDAB"));
            Assert.Equal(false, StringManipulations.IsRotationOfAnotherString("ABCD", "ADBC"));
        }

        [Fact]
        public void RemoveDuplicatesChars()
        {
            Assert.Equal("Helo!", StringManipulations.RemoveDuplicatesChars("Hellooo!!"));
            Assert.Equal("helo", StringManipulations.RemoveDuplicatesChars("hheelloo"));
            Assert.Equal("w", StringManipulations.RemoveDuplicatesChars("www"));
        }

        [Fact]
        public void MostRepeatedChar()
        {
            Assert.Equal('o', StringManipulations.MostRepeatedChar("Hellooo!!"));
            Assert.Equal('e', StringManipulations.MostRepeatedChar("hheeeeeeeeelloo"));
            Assert.Equal('w', StringManipulations.MostRepeatedChar("www"));
        }

        [Fact]
        public void CapitalizeFirstLetterOfEachWord()
        {
            Assert.Equal("Trees Are Beautiful", StringManipulations.CapitalizeFirstLetterOfEachWord("trees are beautiful"));
            Assert.Equal("Trees Are Beautiful", StringManipulations.CapitalizeFirstLetterOfEachWord(" trees are beautiful "));
            Assert.Equal("Trees", StringManipulations.CapitalizeFirstLetterOfEachWord("trees"));
            Assert.Equal("", StringManipulations.CapitalizeFirstLetterOfEachWord("     "));
            Assert.Equal("Trees Are", StringManipulations.CapitalizeFirstLetterOfEachWord(" trees      are       "));
            Assert.Equal("Are", StringManipulations.CapitalizeFirstLetterOfEachWord("       are       "));
        }


        [Fact]
        public void StringsAreAnagram()
        {
            Assert.Equal(true, StringManipulations.StringsAreAnagram("abcd", "adbc"));
            Assert.Equal(true, StringManipulations.StringsAreAnagram("abcd", "cadb"));
            Assert.Equal(true, StringManipulations.StringsAreAnagram("abcd", "abcd"));
            Assert.Equal(false, StringManipulations.StringsAreAnagram("abcd", "abce"));
        }

        [Fact]
        public void StringIsPalindrome()
        {
            Assert.Equal(true, StringManipulations.StringIsPalindrome("abba"));
            Assert.Equal(true, StringManipulations.StringIsPalindrome("abcba"));
            Assert.Equal(false, StringManipulations.StringIsPalindrome("abca"));
        }

        [Fact]
        public void BoyerMooreHorSpool()
        {
            Assert.Equal(true, StringManipulations.BoyerMooreHorspoolAlgo("TEST", "THIS IS A TEST TEXT"));
            Assert.Equal(true, StringManipulations.BoyerMooreHorspoolAlgo("AABA", "AABAACAADAABAABA"));
            Assert.Equal(false, StringManipulations.BoyerMooreHorspoolAlgo("GOGO", "Here is the Truth TOOTH of "));
        }

        [Fact]
        public void BoyerMooreHorSpoolArr()
        {
            Assert.Equal(10, StringManipulations.BoyerMooreHorspoolArr("TEST", "THIS IS A TEST TEXT"));
            Assert.Equal(0, StringManipulations.BoyerMooreHorspoolArr("AABA", "AABAACAADAABAABA"));
            Assert.Equal(-1, StringManipulations.BoyerMooreHorspoolArr("GOGO", "Here is the Truth TOOTH of "));
        }

        [Fact]
        public void BoyerMooreHorSpoolSimple()
        {
            Assert.Equal(10, StringManipulations.BoyerMooreHorspoolSimpleAlgo("TEST", "THIS IS A TEST TEXT"));
            Assert.Equal(0, StringManipulations.BoyerMooreHorspoolSimpleAlgo("AABA", "AABAACAADAABAABA"));
            Assert.Equal(-1, StringManipulations.BoyerMooreHorspoolSimpleAlgo("GOGO", "Here is the Truth TOOTH of "));
        }
    }
}