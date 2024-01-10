using System.Text;

namespace Refinity.Database
{
    /// <summary>
    /// Represents a query builder for constructing SQL queries.
    /// </summary>
    public class QueryBuilder
    {
        private StringBuilder _query = new StringBuilder();
       
        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="columns">The columns to select.</param>
        public QueryBuilder Select(params string[] columns)
        {
            string _columns = string.Join(", ", columns);
            _query.Append($"SELECT {_columns} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        public QueryBuilder From(params string[] table)
        {
            string _table = string.Join(", ", table);
            _query.Append($"FROM {_table} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to filter.</param>
        /// <param name="isEqualTo">The value to filter by.</param>
        public QueryBuilder Where(string column, string isEqualTo)
        {
            _query.Append($"WHERE {column} = {isEqualTo} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to filter.</param>
        /// <param name="isNotEqualTo">The value to filter by.</param>
        public QueryBuilder WhereNot(string column, string isNotEqualTo)
        {
            _query.Append($"WHERE {column} != {isNotEqualTo} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to filter.</param>
        /// <param name="isEqualTo">The value to filter by.</param>
        public QueryBuilder And(string column, string isEqualTo)
        {
            _query.Append($"AND {column} = {isEqualTo} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to filter.</param>
        /// <param name="isNotEqualTo">The value to filter by.</param>
        public QueryBuilder AndNot(string column, string isNotEqualTo)
        {
            _query.Append($"AND {column} != {isNotEqualTo} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to filter.</param>
        /// <param name="isEqualTo">The value to filter by.</param>
        public QueryBuilder Or(string column, string isEqualTo)
        {
            _query.Append($"OR {column} = {isEqualTo} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to filter.</param>
        /// <param name="isNotEqualTo">The value to filter by.</param>
        public QueryBuilder OrNot(string column, string isNotEqualTo)
        {
            _query.Append($"OR {column} != {isNotEqualTo} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="value">The value to filter by.</param>
        public QueryBuilder Like(string value)
        {
            _query.Append($"LIKE '{value}' ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="values">The values to filter by.</param>
        public QueryBuilder In(string[] values)
        {
            string _values = string.Join(", ", values);
            _query.Append($"IN ({_values}) ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="min">The minimum value to filter by.</param>
        /// <param name="max">The maximum value to filter by.</param>
        public QueryBuilder Between(string min, string max)
        {
            _query.Append($"BETWEEN {min} AND {max} ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to order by.</param>
        public QueryBuilder OrderByAsc(params string[] column)
        {
            string _column = string.Join(", ", column);
            _query.Append($"ORDER BY {_column} ASC ");
            return this;
        }

        /// <summary>
        /// Represents a query builder for constructing SQL queries.
        /// </summary>
        /// <param name="column">The column to order by.</param>
        public QueryBuilder OrderByDesc(params string[] column)
        {
            string _column = string.Join(", ", column);
            _query.Append($"ORDER BY {_column} DESC ");
            return this;
        }

        /// <summary>
        /// Builds the query and returns it as a string.
        /// </summary>
        /// <param name="forceBuild">Whether to force build the query even if it is not well-formed. Default is false.</param>
        /// <returns>The built query as a string.</returns>
        public string Build(bool forceBuild = false)
        {
            string queryString = _query.ToString();

            if (!forceBuild)
            {
                if (!queryString.Contains("SELECT") || !queryString.Contains("FROM"))
                    throw new InvalidOperationException("Query is not well-formed. Missing SELECT or FROM clause.");

                int whereIndex = queryString.IndexOf("WHERE");
                int andIndex = queryString.IndexOf("AND");
                int orIndex = queryString.IndexOf("OR");
                int selectIndex = queryString.IndexOf("SELECT");
                int fromIndex = queryString.IndexOf("FROM");

                if (whereIndex == -1 || whereIndex < selectIndex || whereIndex < fromIndex)
                    throw new InvalidOperationException("Query is not well-formed. WHERE clause must come after SELECT and FROM clauses.");

                if ((queryString.Contains("LIKE") || queryString.Contains("IN") || queryString.Contains("BETWEEN")) && whereIndex > System.Math.Max(queryString.IndexOf("LIKE"), System.Math.Max(queryString.IndexOf("IN"), queryString.IndexOf("BETWEEN"))))
                    throw new InvalidOperationException("Query is not well-formed. WHERE clause must come before LIKE, IN, or BETWEEN clauses.");

                if (andIndex != -1 && andIndex < whereIndex)
                    throw new InvalidOperationException("Query is not well-formed. AND clause must come after WHERE clause.");

                if (orIndex != -1 && orIndex < whereIndex)
                    throw new InvalidOperationException("Query is not well-formed. OR clause must come after WHERE clause.");
            }

            return queryString.Trim();
        }
    }
}