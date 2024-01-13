using NUnit.Framework;
using Refinity.Database;
using Refinity.Enums;
using System;

[TestFixture]
public class QueryBuilderTests
{
    private QueryBuilder _queryBuilder;

    [SetUp]
    public void Setup()
    {
        _queryBuilder = new QueryBuilder();
    }

    [Test]
    public void Select_GivenColumns_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.Select("column1", "column2");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("SELECT column1, column2"));
    }

    [Test]
    public void From_GivenTable_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.From("table1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("FROM table1"));
    }

    [Test]
    public void Where_GivenParameters_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.Where("column1", Operators.Equal, "param1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("WHERE column1 = param1"));
    }

    [Test]
    public void And_GivenParameters_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.And("column1", Operators.Equal, "param1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("AND column1 = param1"));
    }

    [Test]
    public void Or_GivenParameters_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.Or("column1", Operators.Equal, "param1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("OR column1 = param1"));
    }

    [Test]
    public void Like_GivenValue_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.Like("value1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("LIKE 'value1'"));
    }

    [Test]
    public void In_GivenValues_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.In(new string[] { "value1", "value2" });

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("IN (value1, value2)"));
    }

    [Test]
    public void Between_GivenMinAndMax_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.Between("1", "10");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("BETWEEN 1 AND 10"));
    }

    [Test]
    public void OrderByAsc_GivenColumn_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.OrderByAsc("column1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("ORDER BY column1 ASC"));
    }

    [Test]
    public void OrderByDesc_GivenColumn_BuildsCorrectQuery()
    {
        // Act
        _queryBuilder.OrderByDesc("column1");

        // Assert
        Assert.That(_queryBuilder.Build(true), Is.EqualTo("ORDER BY column1 DESC"));
    }

    [Test]
    public void Build_GivenIncompleteQuery_ThrowsException()
    {
        // Act
        _queryBuilder.Select("column1");

        // Assert
        Assert.Throws<InvalidOperationException>(() => _queryBuilder.Build());
    }
}