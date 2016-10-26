﻿namespace Nfluent.Tests
{
    using NFluent;
    using NFluent.Helpers;
    using NUnit.Framework;

    [TestFixture]
    public class StringDifferenceAnalyzerTests
    {
        [Test]
        public void ShouldNotReportWhenNoDifference()
        {
            Check.That(StringDifferenceAnalyzer.Analyze("toto", "toto")).IsNull();
        }

        [Test]
        public void ShouldReportDifferentLineWhenOneLine()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto", "tutu");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.General);
            Check.That(stringDifferences[0].Position).IsEqualTo(1);
        }

        [Test]
        public void ShouldReportDifferenceForCaseSensitive()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto", "toTo");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.CaseDifference);
            Check.That(stringDifferences[0].Position).IsEqualTo(2);
        }

        [Test]
        public void ShouldReportDifferenceForGeneralEvenIfFirstDiffIsCase()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto", "toTd");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.General);
            Check.That(stringDifferences[0].Position).IsEqualTo(3);
        }

        [Test]
        public void ShouldReportDifferenceForLongerText()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto et tutu", "toto");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.Longer);
            Check.That(stringDifferences[0].Position).IsEqualTo(4);
        }

        [Test]
        public void ShouldReportDifferenceForShorterText()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto", "toto et tata");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.Shorter);
            Check.That(stringDifferences[0].Position).IsEqualTo(4);
        }

        [Test]
        public void ShouldReportDifferenceForMultipleLines()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto\ntiti", "toto\ntata");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.General);
            Check.That(stringDifferences[0].Position).IsEqualTo(1);
            Check.That(stringDifferences[0].Line).IsEqualTo(1);
            stringDifferences = StringDifferenceAnalyzer.Analyze("maybe\ntiti", "toto\ntata");
            Check.That(stringDifferences).HasSize(2);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.General);
            Check.That(stringDifferences[0].Position).IsEqualTo(0);
            Check.That(stringDifferences[0].Line).IsEqualTo(0);
            Check.That(stringDifferences[1].Type).IsEqualTo(DifferenceMode.General);
            Check.That(stringDifferences[1].Position).IsEqualTo(1);
            Check.That(stringDifferences[1].Line).IsEqualTo(1);
        }

        [Test]
        public void ShouldReportDifferenceOfEoL()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto\ntiti", "toto\r\ntiti");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.EndOfLine);
            Check.That(stringDifferences[0].Position).IsEqualTo(4);
            Check.That(stringDifferences[0].Line).IsEqualTo(0);
        }

        [Test]
        public void ShouldReportDifferenceOfNumberOfLinesL()
        {
            var stringDifferences = StringDifferenceAnalyzer.Analyze("toto\ntiti", "toto");
            Check.That(stringDifferences).HasSize(1);
            Check.That(stringDifferences[0].Type).IsEqualTo(DifferenceMode.ExtraLines);
            Check.That(stringDifferences[0].Position).IsEqualTo(0);
            Check.That(stringDifferences[0].Line).IsEqualTo(1);
        }
    }
}
