using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCLib
{
    internal class OraColumn
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
}
