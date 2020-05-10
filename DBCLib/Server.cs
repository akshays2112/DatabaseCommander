using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Reflection;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using Devart.Data.MySql;

namespace DBCLib
{
    public class Server
    {
        #region MSSQLServer
        private class MSSQLServer
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        private class Database
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string tableCount;

            public string TableCount
            {
                get { return tableCount; }
                set { tableCount = value; }
            }

            private string procedureCount;

            public string ProcedureCount
            {
                get { return procedureCount; }
                set { procedureCount = value; }
            }

            private string viewCount;

            public string ViewCount
            {
                get { return viewCount; }
                set { viewCount = value; }
            }

            private string functionCount;

            public string FunctionCount
            {
                get { return functionCount; }
                set { functionCount = value; }
            }
        }

        private class TableOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class Table
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            private string rowCount;

            public string RowCount
            {
                get { return rowCount; }
                set { rowCount = value; }
            }
        }

        private class Column
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private bool isPrimaryKey;

            public bool IsPrimaryKey
            {
                get { return isPrimaryKey; }
                set { isPrimaryKey = value; }
            }

            private string primaryKeyConstraintName;

            public string PrimaryKeyConstraintName
            {
                get { return primaryKeyConstraintName; }
                set { primaryKeyConstraintName = value; }
            }

            private bool isForeignKey;

            public bool IsForeignKey
            {
                get { return isForeignKey; }
                set { isForeignKey = value; }
            }

            private string foreignKeyContraintName;

            public string ForeignKeyContraintName
            {
                get { return foreignKeyContraintName; }
                set { foreignKeyContraintName = value; }
            }

            private string foreignTableName;

            public string ForeignTableName
            {
                get { return foreignTableName; }
                set { foreignTableName = value; }
            }

            private string foreignColumnName;

            public string ForeignColumnName
            {
                get { return foreignColumnName; }
                set { foreignColumnName = value; }
            }

            private string tableName;

            public string TableName
            {
                get { return tableName; }
                set { tableName = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }
        }

        private class ViewOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class View
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            private string rowCount;

            public string RowCount
            {
                get { return rowCount; }
                set { rowCount = value; }
            }
        }

        private class StoredProcedureOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class StoredProcedure
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }
        }

        private class FunctionOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class Function
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }
        }
        #endregion

        #region Oracle
        private class OraServer
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string tableCount;

            public string TableCount
            {
                get { return tableCount; }
                set { tableCount = value; }
            }

            private string viewCount;

            public string ViewCount
            {
                get { return viewCount; }
                set { viewCount = value; }
            }

            private string procedureCount;

            public string ProcedureCount
            {
                get { return procedureCount; }
                set { procedureCount = value; }
            }

            private string functionCount;

            public string FunctionCount
            {
                get { return functionCount; }
                set { functionCount = value; }
            }
        }

        private class OraTableOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class OraTable
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string rowCount;

            public string RowCount
            {
                get { return rowCount; }
                set { rowCount = value; }
            }
        }

        private class OraColumn
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private bool isPrimaryKey;

            public bool IsPrimaryKey
            {
                get { return isPrimaryKey; }
                set { isPrimaryKey = value; }
            }

            private string primaryKeyConstraintName;

            public string PrimaryKeyConstraintName
            {
                get { return primaryKeyConstraintName; }
                set { primaryKeyConstraintName = value; }
            }

            private bool isForeignKey;

            public bool IsForeignKey
            {
                get { return isForeignKey; }
                set { isForeignKey = value; }
            }

            private string foreignKeyContraintName;

            public string ForeignKeyContraintName
            {
                get { return foreignKeyContraintName; }
                set { foreignKeyContraintName = value; }
            }

            private string foreignTableName;

            public string ForeignTableName
            {
                get { return foreignTableName; }
                set { foreignTableName = value; }
            }

            private string foreignColumnName;

            public string ForeignColumnName
            {
                get { return foreignColumnName; }
                set { foreignColumnName = value; }
            }

            private string tableName;

            public string TableName
            {
                get { return tableName; }
                set { tableName = value; }
            }

            private string databaseName;

            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }
        }

        private class OraViewOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class OraView
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string rowCount;

            public string RowCount
            {
                get { return rowCount; }
                set { rowCount = value; }
            }
        }

        public class OraProcedureOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class OraProcedure
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        private class OraFunctionOwner
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string count;

            public string Count
            {
                get { return count; }
                set { count = value; }
            }
        }

        private class OraFunction
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }
        #endregion

        #region MySQL Server
        private class MySQLServer
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        private class MySQLSchema
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string tableCount;

            public string TableCount
            {
                get { return tableCount; }
                set { tableCount = value; }
            }

            private string viewCount;

            public string ViewCount
            {
                get { return viewCount; }
                set { viewCount = value; }
            }

            private string procedureCount;

            public string ProcedureCount
            {
                get { return procedureCount; }
                set { procedureCount = value; }
            }

            private string functionCount;

            public string FunctionCount
            {
                get { return functionCount; }
                set { functionCount = value; }
            }
        }

        private class MySQLTable
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string schemaName;

            public string SchemaName
            {
                get { return schemaName; }
                set { schemaName = value; }
            }

            private string rowCount;

            public string RowCount
            {
                get { return rowCount; }
                set { rowCount = value; }
            }
        }

        private class MySQLColumn
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private bool isPrimaryKey;

            public bool IsPrimaryKey
            {
                get { return isPrimaryKey; }
                set { isPrimaryKey = value; }
            }

            private string primaryKeyConstraintName;

            public string PrimaryKeyConstraintName
            {
                get { return primaryKeyConstraintName; }
                set { primaryKeyConstraintName = value; }
            }

            private bool isForeignKey;

            public bool IsForeignKey
            {
                get { return isForeignKey; }
                set { isForeignKey = value; }
            }

            private string foreignKeyContraintName;

            public string ForeignKeyContraintName
            {
                get { return foreignKeyContraintName; }
                set { foreignKeyContraintName = value; }
            }

            private string foreignTableName;

            public string ForeignTableName
            {
                get { return foreignTableName; }
                set { foreignTableName = value; }
            }

            private string foreignColumnName;

            public string ForeignColumnName
            {
                get { return foreignColumnName; }
                set { foreignColumnName = value; }
            }

            private string tableName;

            public string TableName
            {
                get { return tableName; }
                set { tableName = value; }
            }

            private string schemaName;

            public string SchemaName
            {
                get { return schemaName; }
                set { schemaName = value; }
            }
        }

        private class MySQLView
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string schemaName;

            public string SchemaName
            {
                get { return schemaName; }
                set { schemaName = value; }
            }

            private string rowCount;

            public string RowCount
            {
                get { return rowCount; }
                set { rowCount = value; }
            }
        }

        private class MySQLProcedure
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string schemaName;

            public string SchemaName
            {
                get { return schemaName; }
                set { schemaName = value; }
            }
        }

        private class MySQLFunction
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string schemaName;

            public string SchemaName
            {
                get { return schemaName; }
                set { schemaName = value; }
            }
        }
        #endregion

        public string ExecuteFunctionByName(string functionName)
        {
            MethodInfo mi = typeof(Server).GetMethod(functionName, 
                BindingFlags.NonPublic | BindingFlags.Instance);
            return mi.Invoke(this, null).ToString();
        }

        public string ExecuteFunctionByName(string functionName, object[] parameters)
        {
            MethodInfo mi = typeof(Server).GetMethod(functionName,
                BindingFlags.NonPublic | BindingFlags.Instance);
            return mi.Invoke(this, parameters).ToString();
        }

        #region MSSQL Server methods
        private string GetServer(string mssqlConnString)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select @@SERVERNAME as ServerName", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            MSSQLServer server = new MSSQLServer();
            server.Name = dr["ServerName"].ToString();
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(server);
        }

        private string GetDatabases(string mssqlConnString)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select [name] from sys.databases order by [name]", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            List<Database> databases = new List<Database>();
            while (dr.Read())
            {
                Database db = new Database();
                db.Name = dr["name"].ToString();
                databases.Add(db);
            }
            dr.Close();
            foreach (Database db in databases)
            {
                cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                    "set @script = Replace('SELECT count(*) as TableCount " +
                    "FROM [{databaseName}].INFORMATION_SCHEMA.TABLES " +
                    "WHERE TABLE_TYPE=''BASE TABLE''', '{databaseName}', " +
                    "@databaseName);Execute(@script);", conn);
                cmd.Parameters.AddWithValue("@databaseName", db.Name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    db.TableCount = dr["TableCount"].ToString();
                }
                dr.Close();
                cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                    "set @script = Replace('SELECT count(*) as ProcCount " +
                    "FROM [{databaseName}].INFORMATION_SCHEMA.Routines', " +
                    "'{databaseName}', @databaseName); Execute(@script);", conn);
                cmd.Parameters.AddWithValue("@databaseName", db.Name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    db.ProcedureCount = dr["ProcCount"].ToString();
                }
                dr.Close();
                cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                    "set @script = Replace('SELECT count(*) as ViewCount " +
                    "FROM [{databaseName}].INFORMATION_SCHEMA.Views', " +
                    "'{databaseName}', @databaseName); Execute(@script);", conn);
                cmd.Parameters.AddWithValue("@databaseName", db.Name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    db.ViewCount = dr["ViewCount"].ToString();
                }
                dr.Close();
                cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                    "set @script = Replace('SELECT count(*) as FunctionCount " +
                    "FROM [{databaseName}].sys.sql_modules m INNER JOIN " +
                    "[{databaseName}].sys.objects o ON " +
                    "m.[object_id]=o.[object_id] WHERE type_desc like ''%function%''', " +
                    "'{databaseName}', @databaseName); Execute(@script);", conn);
                cmd.Parameters.AddWithValue("@databaseName", db.Name);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    db.FunctionCount = dr["FunctionCount"].ToString();
                }
                dr.Close();
            }
            conn.Close();
            return JsonConvert.SerializeObject(databases);
        }

        private string GetTableOwners(string mssqlConnString, string databaseName)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                "set @script = Replace('SELECT count(*) as TableCount, " +
                "TABLE_SCHEMA FROM [{databaseName}].INFORMATION_SCHEMA.TABLES " +
                "WHERE TABLE_TYPE=''BASE TABLE'' group by TABLE_SCHEMA order by " +
                "TABLE_SCHEMA', '{databaseName}', @databaseName);Execute(@script);", 
                conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            List<TableOwner> tableOwners = new List<TableOwner>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TableOwner tableOwner = new TableOwner();
                tableOwner.DatabaseName = databaseName;
                tableOwner.Name = dr["TABLE_SCHEMA"].ToString();
                tableOwner.Count = dr["TableCount"].ToString();
                tableOwners.Add(tableOwner);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(tableOwners);
        }

        private string GetTablesByOwner(string mssqlConnString,
            string databaseName, string owner)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                "set @script = Replace('SELECT table_name FROM " +
                "[{databaseName}].INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=" +
                "''BASE TABLE'' and TABLE_SCHEMA=''{owner}'' order by table_name', " +
                "'{databaseName}', @databaseName);set @script = Replace(@script, " +
                "'{owner}', @owner);Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@owner", owner);
            List<Table> tables = new List<Table>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Table table = new Table();
                table.DatabaseName = databaseName;
                table.Name = dr["table_name"].ToString();
                tables.Add(table);
            }
            dr.Close();
            foreach (Table table in tables)
            {
                cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                    "set @script = Replace('SELECT count(*) as [RowCount] FROM " +
                    "[{databaseName}].[{owner}].[{tableName}]', '{databaseName}', " +
                    "@databaseName);set @script = Replace(@script, '{owner}', @owner); " +
                    "set @script = Replace(@script, '{tableName}', @tableName); " +
                    "Execute(@script);", conn);
                cmd.Parameters.AddWithValue("@databaseName", databaseName);
                cmd.Parameters.AddWithValue("@owner", owner);
                cmd.Parameters.AddWithValue("@tableName", table.Name);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    table.RowCount = dr["RowCount"].ToString();
                }
                dr.Close();
            }
            conn.Close();
            return JsonConvert.SerializeObject(tables);
        }

        private string GetColumns(string mssqlConnString, string databaseName,
            string tableName)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "declare @tblName nvarchar(MAX); set @tblName = @tableName;" +
                "set @script = Replace('select [name] from [{databaseName}]." +
                "sys.all_columns where [object_id] = OBJECT_ID(''" +
                "[{databaseName}].dbo.' + @tblName + ''')', " +
                "'{databaseName}', @databaseName); Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@tableName", tableName);
            List<Column> columns = new List<Column>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Column c = new Column();
                c.TableName = tableName;
                c.DatabaseName = databaseName;
                c.Name = dr["name"].ToString();
                columns.Add(c);
            }
            dr.Close();
            cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "declare @tblName nvarchar(MAX); set @tblName = @tableName;" +
                "set @script = Replace('select OBJECT_NAME(constraint_object_id) as " +
                "ConstraintName, OBJECT_NAME(parent_object_id) as TableName, " +
                "ac.[name] as ColumnName, OBJECT_NAME(referenced_object_id) as " +
                "ForeignTableName, ac2.[name] as ForeignColumnName  from " +
                "[{databaseName}].sys.foreign_key_columns as fkc left outer " +
                "join [{databaseName}].sys.all_columns as ac on " +
                "fkc.parent_object_id = ac.[object_id] and " +
                "fkc.parent_column_id = ac.column_id left outer join " +
                "[{databaseName}].sys.all_columns as ac2 on fkc.referenced_object_id = " +
                "ac2.[object_id] and fkc.referenced_column_id = ac2.column_id " +
                "where parent_object_id = OBJECT_ID(''[{databaseName}].dbo.' " +
                "+ @tblName + ''')', '{databaseName}', @databaseName); Execute(@script);",
                conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@TableName", tableName);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Column c = GetColumnByName(columns, dr["ColumnName"].ToString());
                if (c != null)
                {
                    c.IsForeignKey = true;
                    c.ForeignKeyContraintName = dr["ConstraintName"].ToString();
                    c.ForeignTableName = dr["ForeignTableName"].ToString();
                    c.ForeignColumnName = dr["ForeignColumnName"].ToString();
                }
            }
            dr.Close();
            cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "declare @tblName nvarchar(MAX); set @tblName = @tableName;" +
                "set @script = Replace('SELECT column_name as PRIMARYKEYCOLUMN, " +
                "TC.CONSTRAINT_NAME FROM " +
                "[{databaseName}].INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC INNER JOIN " +
                "[{databaseName}].INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU ON " +
                "TC.CONSTRAINT_TYPE = ''PRIMARY KEY'' AND TC.CONSTRAINT_NAME " +
                "= KU.CONSTRAINT_NAME AND KU.table_name = ''' " +
                "+ @tblName + '''', '{databaseName}', @databaseName); Execute(@script);",
                conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@TableName", tableName);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Column c = GetColumnByName(columns, dr["PRIMARYKEYCOLUMN"].ToString());
                if (c != null)
                {
                    c.IsPrimaryKey = true;
                    c.PrimaryKeyConstraintName = dr["CONSTRAINT_NAME"].ToString();
                }
            }
            dr.Close();
            conn.Close();
            var columnsOrderBy = from col in columns
                                 orderby col.IsPrimaryKey descending,
                                 col.IsForeignKey descending,
                                 col.Name ascending
                                 select col;
            return JsonConvert.SerializeObject(columnsOrderBy);
        }

        private Column GetColumnByName(List<Column> columns, string columnName)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Name == columnName)
                {
                    return columns[i];
                }
            }
            return null;
        }

        private string GetViewOwners(string mssqlConnString, string databaseName)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "set @script = Replace('SELECT count(*) as ViewCount, " +
                "TABLE_SCHEMA FROM [{databaseName}].INFORMATION_SCHEMA.Views " +
                "group by TABLE_SCHEMA order by TABLE_SCHEMA', '{databaseName}', " +
                "@databaseName); Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            List<ViewOwner> viewOwners = new List<ViewOwner>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ViewOwner viewOwner = new ViewOwner();
                viewOwner.DatabaseName = databaseName;
                viewOwner.Name = dr["TABLE_SCHEMA"].ToString();
                viewOwner.Count = dr["ViewCount"].ToString();
                viewOwners.Add(viewOwner);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(viewOwners);
        }

        private string GetViewsByOwner(string mssqlConnString, string databaseName,
            string owner)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "set @script = Replace('SELECT TABLE_NAME FROM [{databaseName}]." +
                "INFORMATION_SCHEMA.Views where TABLE_SCHEMA=''{owner}'' order by " +
                "TABLE_NAME', '{databaseName}', @databaseName); set @script = " +
                "Replace(@script, '{owner}', @owner); Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@owner", owner);
            List<View> views = new List<View>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                View view = new View();
                view.DatabaseName = databaseName;
                view.Name = dr["TABLE_NAME"].ToString();
                views.Add(view);
            }
            dr.Close();
            foreach(View view in views)
            {
                cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "set @script = Replace('SELECT count(*) as [RowCount] FROM " +
                "[{databaseName}].[{owner}].[{viewName}]', '{databaseName}', " +
                "@databaseName); set @script = Replace(@script, '{owner}', @owner); " +
                "set @script = Replace(@script, '{viewName}', @viewName); " +
                "Execute(@script);", conn);
                cmd.Parameters.AddWithValue("@databaseName", databaseName);
                cmd.Parameters.AddWithValue("@owner", owner);
                cmd.Parameters.AddWithValue("@viewName", view.Name);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    view.RowCount = dr["RowCount"].ToString();
                }
                dr.Close();
            }
            conn.Close();
            return JsonConvert.SerializeObject(views);
        }

        private string GetStoredProcedureOwners(string mssqlConnString, string databaseName)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "set @script = Replace('SELECT count(*) as ProcCount, " +
                "SPECIFIC_SCHEMA FROM [{databaseName}].INFORMATION_SCHEMA." +
                "Routines group by SPECIFIC_SCHEMA order by SPECIFIC_SCHEMA', " +
                "'{databaseName}', @databaseName); Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            List<StoredProcedureOwner> spOwners = new List<StoredProcedureOwner>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StoredProcedureOwner spOwner = new StoredProcedureOwner();
                spOwner.DatabaseName = databaseName;
                spOwner.Name = dr["SPECIFIC_SCHEMA"].ToString();
                spOwner.Count = dr["ProcCount"].ToString();
                spOwners.Add(spOwner);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(spOwners);
        }

        private string GetStoredProceduresByOwner(string mssqlConnString,
            string databaseName, string owner)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX); " +
                "set @script = Replace('SELECT SPECIFIC_NAME FROM " +
                "[{databaseName}].INFORMATION_SCHEMA.Routines where " +
                "SPECIFIC_SCHEMA=''{owner}'' order by SPECIFIC_NAME', " +
                "'{databaseName}', @databaseName); set @script = Replace(" +
                "@script, '{owner}', @owner); Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@owner", owner);
            List<StoredProcedure> sps = new List<StoredProcedure>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StoredProcedure sp = new StoredProcedure();
                sp.DatabaseName = databaseName;
                sp.Name = dr["SPECIFIC_NAME"].ToString();
                sps.Add(sp);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(sps);
        }

        private string GetFunctionOwners(string mssqlConnString, string databaseName)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                "set @script = Replace('SELECT count(*) as FunctionCount, " +
                "SCHEMA_NAME(o.[schema_id]) as [SCHEMA_NAME] FROM " +
                "[{databaseName}].sys.sql_modules m INNER JOIN " +
                "[{databaseName}].sys.objects o ON m.[object_id]=o.[object_id] " +
                "WHERE type_desc like ''%function%'' group by o.[schema_id] order by " +
                "[SCHEMA_NAME]', '{databaseName}', @databaseName);" +
                "Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            List<FunctionOwner> functionOwners = new List<FunctionOwner>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FunctionOwner functionOwner = new FunctionOwner();
                functionOwner.DatabaseName = databaseName;
                functionOwner.Name = dr["SCHEMA_NAME"].ToString();
                functionOwner.Count = dr["FunctionCount"].ToString();
                functionOwners.Add(functionOwner);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(functionOwners);
        }

        private string GetFunctionsByOwner(string mssqlConnString, string databaseName,
            string owner)
        {
            SqlConnection conn = new SqlConnection(mssqlConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("declare @script nvarchar(MAX);" +
                "set @script = Replace('SELECT [name] FROM [{databaseName}]." +
                "sys.sql_modules m INNER JOIN [{databaseName}].sys.objects o " +
                "ON m.[object_id]=o.[object_id] WHERE type_desc like ''%function%'' " +
                "and o.[schema_id] = SCHEMA_ID(''{owner}'') order by [name]', " +
                "'{databaseName}', @databaseName); set @script = Replace(" +
                "@script, '{owner}', @owner); Execute(@script);", conn);
            cmd.Parameters.AddWithValue("@databaseName", databaseName);
            cmd.Parameters.AddWithValue("@owner", owner);
            List<Function> functions = new List<Function>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Function function = new Function();
                function.DatabaseName = databaseName;
                function.Name = dr["name"].ToString();
                functions.Add(function);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(functions);
        }
        #endregion

        #region Oracle Methods
        private string OraGetServer(string oraConnString)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "select sys_context('USERENV','SERVER_HOST') as ServerName from dual", oconn);
            OracleDataReader odr = ocmd.ExecuteReader();
            odr.Read();
            OraServer server = new OraServer();
            server.Name = odr["ServerName"].ToString();
            odr.Close();
            ocmd = new OracleCommand(
            "SELECT count(*) as TableCount FROM all_tables", oconn);
            odr = ocmd.ExecuteReader();
            if (odr.Read())
            {
                server.TableCount = odr["TableCount"].ToString();
            }
            odr.Close();
            ocmd = new OracleCommand("SELECT count(*) as ProcCount FROM all_procedures",
                oconn);
            odr = ocmd.ExecuteReader();
            if (odr.Read())
            {
                server.ProcedureCount = odr["ProcCount"].ToString();
            }
            odr.Close();
            ocmd = new OracleCommand("SELECT count(*) as ViewCount FROM all_views",
                oconn);
            odr = ocmd.ExecuteReader();
            if (odr.Read())
            {
                server.ViewCount = odr["ViewCount"].ToString();
            }
            odr.Close();
            ocmd = new OracleCommand("SELECT count(*) as FunctionCount FROM " +
                "ALL_OBJECTS WHERE OBJECT_TYPE = 'FUNCTION'", oconn);
            odr = ocmd.ExecuteReader();
            if (odr.Read())
            {
                server.FunctionCount = odr["FunctionCount"].ToString();
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(server);
        }

        private string OraGetTableOwners(string oraConnString)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT count(*) as TableCount, owner FROM all_tables group by " +
                "owner order by owner", oconn);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraTableOwner> oraTableOwners = new List<OraTableOwner>();
            while (odr.Read())
            {
                OraTableOwner oraTableOwner = new OraTableOwner();
                oraTableOwner.Name = odr["owner"].ToString();
                oraTableOwner.Count = odr["TableCount"].ToString();
                oraTableOwners.Add(oraTableOwner);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraTableOwners);
        }

        private string OraGetTablesByOwner(string oraConnString, string owner)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT table_name FROM all_tables where owner = :Owner order by " +
                "table_name", oconn);
            ocmd.Parameters.Add("Owner", owner);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraTable> oraTables = new List<OraTable>();
            while (odr.Read())
            {
                OraTable oraTable = new OraTable();
                oraTable.Name = odr["table_name"].ToString();
                oraTables.Add(oraTable);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraTables);
        }

        private string OraGetColumns(string oraConnString, string tableName)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "select column_name from all_tab_cols where table_name = " +
                ":TableName", oconn);
            ocmd.Parameters.Add("TableName", tableName);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraColumn> columns = new List<OraColumn>();
            while (odr.Read())
            {
                OraColumn c = new OraColumn();
                c.TableName = tableName;
                c.Name = odr["column_name"].ToString();
                columns.Add(c);
            }
            odr.Close();
            ocmd = new OracleCommand("SELECT CONS.CONSTRAINT_NAME, CONS.TABLE_NAME, " +
                "COLS.COLUMN_NAME, CONS.R_CONSTRAINT_NAME, CONS_R.TABLE_NAME " +
                "R_TABLE_NAME, COLS_R.COLUMN_NAME R_COLUMN_NAME FROM " +
                "USER_CONSTRAINTS CONS LEFT JOIN USER_CONS_COLUMNS COLS ON " +
                "COLS.CONSTRAINT_NAME = CONS.CONSTRAINT_NAME LEFT JOIN " +
                "USER_CONSTRAINTS CONS_R ON CONS_R.CONSTRAINT_NAME = " +
                "CONS.R_CONSTRAINT_NAME LEFT JOIN USER_CONS_COLUMNS COLS_R ON " +
                "COLS_R.CONSTRAINT_NAME = CONS.R_CONSTRAINT_NAME WHERE " +
                "CONS.CONSTRAINT_TYPE = 'R' and CONS.TABLE_NAME = :TableName", oconn);
            ocmd.Parameters.Add("TableName", tableName);
            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                OraColumn c = OraGetColumnByName(columns, odr["ColumnName"].ToString());
                if (c != null)
                {
                    c.IsForeignKey = true;
                    c.ForeignKeyContraintName = odr["CONSTRAINT_NAME"].ToString();
                    c.ForeignTableName = odr["R_TABLE_NAME"].ToString();
                    c.ForeignColumnName = odr["R_COLUMN_NAME"].ToString();
                }
            }
            odr.Close();
            ocmd = new OracleCommand("SELECT CONS.CONSTRAINT_NAME, CONS.TABLE_NAME, " +
                "COLS.COLUMN_NAME, CONS.R_CONSTRAINT_NAME, CONS_R.TABLE_NAME " +
                "R_TABLE_NAME, COLS_R.COLUMN_NAME R_COLUMN_NAME FROM " +
                "USER_CONSTRAINTS CONS LEFT JOIN USER_CONS_COLUMNS COLS ON " +
                "COLS.CONSTRAINT_NAME = CONS.CONSTRAINT_NAME LEFT JOIN " +
                "USER_CONSTRAINTS CONS_R ON CONS_R.CONSTRAINT_NAME = " +
                "CONS.R_CONSTRAINT_NAME LEFT JOIN USER_CONS_COLUMNS COLS_R ON " +
                "COLS_R.CONSTRAINT_NAME = CONS.R_CONSTRAINT_NAME WHERE " +
                "CONS.CONSTRAINT_TYPE = 'P' and CONS.TABLE_NAME = :TableName", oconn);
            ocmd.Parameters.Add("TableName", tableName);
            odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                OraColumn c = OraGetColumnByName(columns, odr["COLUMN_NAME"].ToString());
                if (c != null)
                {
                    c.IsPrimaryKey = true;
                    c.PrimaryKeyConstraintName = odr["CONSTRAINT_NAME"].ToString();
                }
            }
            odr.Close();
            oconn.Close();
            var columnsOrderBy = from col in columns
                                 orderby col.IsPrimaryKey descending,
                                 col.IsForeignKey descending,
                                 col.Name ascending
                                 select col;
            return JsonConvert.SerializeObject(columnsOrderBy);
        }

        private OraColumn OraGetColumnByName(List<OraColumn> columns, string columnName)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Name == columnName)
                {
                    return columns[i];
                }
            }
            return null;
        }

        private string OraGetProcedureOwners(string oraConnString)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand("select count(*) as " +
                "ProcCount, owner from all_procedures group by owner " +
                "order by owner", oconn);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraProcedureOwner> oraOwners = new List<OraProcedureOwner>();
            while (odr.Read())
            {
                OraProcedureOwner owner = new OraProcedureOwner();
                owner.Name = odr["owner"].ToString();
                owner.Count = odr["ProcCount"].ToString();
                oraOwners.Add(owner);
            }
            oconn.Close();
            return JsonConvert.SerializeObject(oraOwners);
        }

        private string OraGetProceduresByOwner(string oraConnString, string owner)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT procedure_name FROM all_procedures where owner = " +
                ":Owner order by procedure_name", oconn);
            ocmd.Parameters.Add("Owner", owner);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraProcedure> oraSps = new List<OraProcedure>();
            while (odr.Read())
            {
                OraProcedure oraSp = new OraProcedure();
                oraSp.Name = odr["procedure_name"].ToString();
                oraSps.Add(oraSp);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraSps);
        }

        private string OraGetViewOwners(string oraConnString)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT count(*) as ViewCount, owner FROM all_views group by owner " +
                "order by owner", oconn);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraViewOwner> oraViewOwners = new List<OraViewOwner>();
            while (odr.Read())
            {
                OraViewOwner oraViewOwner = new OraViewOwner();
                oraViewOwner.Name = odr["owner"].ToString();
                oraViewOwner.Count = odr["ViewCount"].ToString();
                oraViewOwners.Add(oraViewOwner);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraViewOwners);
        }

        private string OraGetViewsByOwner(string oraConnString, string owner)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT view_name FROM all_views where owner = :Owner " +
                "order by view_name", oconn);
            ocmd.Parameters.Add("Owner", owner);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraView> oraViews = new List<OraView>();
            while (odr.Read())
            {
                OraView oraView = new OraView();
                oraView.Name = odr["view_name"].ToString();
                oraViews.Add(oraView);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraViews);
        }

        private string OraGetFunctionOwners(string oraConnString)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT count(*) as FunctionCount, owner FROM ALL_OBJECTS WHERE " +
                "OBJECT_TYPE = 'FUNCTION' group by owner order by owner", oconn);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraFunctionOwner> oraFunctionOwners = new List<OraFunctionOwner>();
            while (odr.Read())
            {
                OraFunctionOwner oraFunctionOwner = new OraFunctionOwner();
                oraFunctionOwner.Name = odr["owner"].ToString();
                oraFunctionOwner.Count = odr["FunctionCount"].ToString();
                oraFunctionOwners.Add(oraFunctionOwner);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraFunctionOwners);
        }

        private string OraGetFunctionsByOwner(string oraConnString, string owner)
        {
            OracleConnection oconn = new OracleConnection(oraConnString);
            oconn.Open();
            OracleCommand ocmd = new OracleCommand(
                "SELECT OBJECT_NAME FROM ALL_OBJECTS WHERE OBJECT_TYPE = 'FUNCTION' " +
                "and owner = :Owner order by OBJECT_NAME", oconn);
            ocmd.Parameters.Add("Owner", owner);
            OracleDataReader odr = ocmd.ExecuteReader();
            List<OraFunction> oraFunctions = new List<OraFunction>();
            while (odr.Read())
            {
                OraFunction oraFunction = new OraFunction();
                oraFunction.Name = odr["OBJECT_NAME"].ToString();
                oraFunctions.Add(oraFunction);
            }
            odr.Close();
            oconn.Close();
            return JsonConvert.SerializeObject(oraFunctions);
        }
        #endregion

        #region MySQL methods
        private string MySQLGetServer(string mysqlConnString)
        {
            MySqlConnection msconn = new MySqlConnection(mysqlConnString);
            msconn.Open();
            MySqlCommand mscmd = new MySqlCommand("select @@hostname as HostName", msconn);
            MySqlDataReader msdr = mscmd.ExecuteReader();
            msdr.Read();
            MySQLServer server = new MySQLServer();
            server.Name = msdr["HostName"].ToString();
            msdr.Close();
            msconn.Close();
            return JsonConvert.SerializeObject(server);
        }

        private string MySQLGetSchemas(string mysqlConnString)
        {
            MySqlConnection conn = new MySqlConnection(mysqlConnString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<MySQLSchema> schemas = new List<MySQLSchema>();
            while (dr.Read())
            {
                MySQLSchema schema = new MySQLSchema();
                schema.Name = dr["SCHEMA_NAME"].ToString();
                schemas.Add(schema);
            }
            dr.Close();
            foreach(MySQLSchema schema in schemas)
            {
                cmd = new MySqlCommand("SELECT count(*) as TableCount FROM " +
                    "information_schema.TABLES where TABLE_SCHEMA=@Schema_Name", conn);
                cmd.Parameters.AddWithValue("@Schema_Name", schema.Name);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schema.TableCount = dr["TableCount"].ToString();
                }
                dr.Close();
                cmd = new MySqlCommand("select count(*) as ViewCount from " +
                    "information_schema.VIEWS where TABLE_SCHEMA = @Schema_Name",
                    conn);
                cmd.Parameters.AddWithValue("@Schema_Name", schema.Name);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schema.ViewCount = dr["ViewCount"].ToString();
                }
                dr.Close();
                cmd = new MySqlCommand("select count(*) as ProcCount from " +
                    "information_schema.ROUTINES where ROUTINE_TYPE = 'PROCEDURE' " +
                    "and ROUTINE_SCHEMA = @Schema_Name", conn);
                cmd.Parameters.AddWithValue("@Schema_Name", schema.Name);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schema.ProcedureCount = dr["ProcCount"].ToString();
                }
                dr.Close();
                cmd = new MySqlCommand("select count(*) as FunctionCount from " +
                    "information_schema.ROUTINES where ROUTINE_TYPE = 'FUNCTION' " +
                    "and ROUTINE_SCHEMA = @Schema_Name", conn);
                cmd.Parameters.AddWithValue("@Schema_Name", schema.Name);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    schema.FunctionCount = dr["FunctionCount"].ToString();
                }
                dr.Close();
            }
            conn.Close();
            return JsonConvert.SerializeObject(schemas);
        }

        private string MySQLGetTables(string mysqlConnString, string schemaName)
        {
            MySqlConnection conn = new MySqlConnection(mysqlConnString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "SELECT TABLE_NAME FROM information_schema.TABLES where " +
                "TABLE_SCHEMA=@TableSchema order by TABLE_Name", conn);
            cmd.Parameters.AddWithValue("@TableSchema", schemaName);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<MySQLTable> tables = new List<MySQLTable>();
            while (dr.Read())
            {
                MySQLTable table = new MySQLTable();
                table.Name = dr["TABLE_NAME"].ToString();
                table.SchemaName = schemaName;
                tables.Add(table);
            }
            dr.Close();
            foreach(MySQLTable table in tables)
            {
                cmd = new MySqlCommand("set @query = 'SELECT count(*) " +
                    "as Row_Count FROM {TableSchema}.{TableName}'; set @query = " +
                    "replace(@query, '{TableSchema}', @TableSchema); set @query = " +
                    "replace(@query, '{TableName}', @TableName); prepare stmt from " +
                    "@query;Execute stmt;", conn);
                cmd.Parameters.AddWithValue("@TableSchema", schemaName);
                cmd.Parameters.AddWithValue("@TableName", table.Name);
                table.RowCount = cmd.ExecuteScalar().ToString();
                dr.Close();
            }
            conn.Close();
            return JsonConvert.SerializeObject(tables);
        }

        private string MySQLGetColumns(string mysqlConnString, string schemaName, string tableName)
        {
            MySqlConnection conn = new MySqlConnection(mysqlConnString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "SELECT cols.column_name, cols.column_key , kcols.CONSTRAINT_NAME, " +
                "kcols.REFERENCED_TABLE_NAME, kcols.REFERENCED_COLUMN_NAME " +
                "FROM information_schema.columns as cols left join " +
                "INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcols on cols.table_name " +
                "= kcols.table_name and cols.Table_Schema = kcols.Table_Schema and " +
                "cols.Column_Name = kcols.Column_Name where cols.Table_Schema = " +
                "@SchemaName and cols.Table_Name = @TableName",
                conn);
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            cmd.Parameters.AddWithValue("@TableName", tableName);
            MySqlDataReader mysqlDr = cmd.ExecuteReader();
            List<MySQLColumn> columns = new List<MySQLColumn>();
            while (mysqlDr.Read())
            {
                MySQLColumn c = new MySQLColumn();
                c.SchemaName = schemaName;
                c.TableName = tableName;
                c.Name = mysqlDr["column_name"].ToString();
                if (mysqlDr["column_key"].ToString() == "PRI")
                {
                    c.IsPrimaryKey = true;
                    c.PrimaryKeyConstraintName = mysqlDr["CONSTRAINT_NAME"].ToString();
                }
                else if (mysqlDr["REFERENCED_COLUMN_NAME"].ToString().Length > 0)
                {
                    c.IsForeignKey = true;
                    c.ForeignKeyContraintName = mysqlDr["CONSTRAINT_NAME"].ToString();
                    c.ForeignTableName = mysqlDr["REFERENCED_TABLE_NAME"].ToString();
                    c.ForeignColumnName = mysqlDr["REFERENCED_COLUMN_NAME"].ToString();
                }
                columns.Add(c);
            }
            mysqlDr.Close();
            conn.Close();
            var columnsOrderBy = from col in columns
                                 orderby col.IsPrimaryKey descending,
                                 col.IsForeignKey descending,
                                 col.Name ascending
                                 select col;
            return JsonConvert.SerializeObject(columnsOrderBy);
        }

        private string MySQLGetProcedures(string mysqlConnString, string schemaName)
        {
            MySqlConnection conn = new MySqlConnection(mysqlConnString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "select ROUTINE_NAME from information_schema.ROUTINES where " +
                "ROUTINE_TYPE = 'PROCEDURE' and ROUTINE_SCHEMA = @SchemaName " +
                "order by ROUTINE_NAME", conn);
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<MySQLProcedure> procedures = new List<MySQLProcedure>();
            while (dr.Read())
            {
                MySQLProcedure procedure = new MySQLProcedure();
                procedure.Name = dr["ROUTINE_NAME"].ToString();
                procedure.SchemaName = schemaName;
                procedures.Add(procedure);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(procedures);
        }

        private string MySQLGetViews(string mysqlConnString, string schemaName)
        {
            MySqlConnection conn = new MySqlConnection(mysqlConnString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "select TABLE_NAME from information_schema.VIEWS where " +
                "TABLE_SCHEMA = @SchemaName order by TABLE_NAME", conn);
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<MySQLView> views = new List<MySQLView>();
            while (dr.Read())
            {
                MySQLView view = new MySQLView();
                view.Name = dr["TABLE_NAME"].ToString();
                view.SchemaName = schemaName;
                views.Add(view);
            }
            dr.Close();
            foreach (MySQLView view in views)
            {
                cmd = new MySqlCommand("set @query = 'SELECT count(*) " +
                    "as Row_Count FROM {SchemaName}.{ViewName}'; set @query = " +
                    "replace(@query, '{SchemaName}', @SchemaName); set @query = " +
                    "replace(@query, '{ViewName}', @ViewName); prepare stmt from " +
                    "@query;Execute stmt;", conn);
                cmd.Parameters.AddWithValue("@SchemaName", schemaName);
                cmd.Parameters.AddWithValue("@ViewName", view.Name);
                view.RowCount = cmd.ExecuteScalar().ToString();
                dr.Close();
            }
            conn.Close();
            return JsonConvert.SerializeObject(views);
        }

        private string MySQLGetFunctions(string mysqlConnString, string schemaName)
        {
            MySqlConnection conn = new MySqlConnection(mysqlConnString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "select ROUTINE_NAME from information_schema.ROUTINES where " +
                "ROUTINE_TYPE = 'FUNCTION' and ROUTINE_SCHEMA = @SchemaName " +
                "order by ROUTINE_NAME", conn);
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            MySqlDataReader dr = cmd.ExecuteReader();
            List<MySQLFunction> functions = new List<MySQLFunction>();
            while (dr.Read())
            {
                MySQLFunction function = new MySQLFunction();
                function.Name = dr["ROUTINE_NAME"].ToString();
                function.SchemaName = schemaName;
                functions.Add(function);
            }
            dr.Close();
            conn.Close();
            return JsonConvert.SerializeObject(functions);
        }
        #endregion
    }
}

