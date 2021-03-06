﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerDemo
{
    class TimerTestTable
    {
        //name of this specific DataBase Table
        private const String tableName = "TimerTestTable";
        //String used to create this specific Table
        private const String tableCreationString = "(question varchar(4000) not null PRIMARY KEY, answer varchar(4000) not null, questionType varchar(4000) not null);";

        /// <summary>
        /// Default Constructor for the QuestionTable class
        /// </summary>
        public TimerTestTable()
        {

        }

        /// <summary>
        /// Accessor for tableName
        /// </summary>
        public String TableName
        {
            get => tableName;
        }

        /// <summary>
        /// Accessor for tableCreationString
        /// </summary>
        public String TableCreationString
        {
            get => tableCreationString;
        }

        /// <summary>
        /// Checks to see if this Table table exists currently in the DataBase
        /// </summary>
        /// <param name="tableExists">True if the Table does exist in the DataBase, False if it does not</param>
        public Boolean TableExists(String tableName)
        {
            return DataBaseOperations.TableExists(tableName);
        }

        /// <summary>
        /// Creates this Table
        /// </summary>
        public void CreateTable(String tableName, String tableCreationString)
        {
            DataBaseOperations.CreateTable(tableName, tableCreationString);
        }

        /// <summary>
        /// Inserts a row (containing question and answer) into the Table
        /// </summary>
        /// <param name="dataEntry">Instance of IDataEntry Interface containing qustion, answer</param>
        public void InsertRowIntoTable(String tableName, List<String> list)
        {
            String question = list[0];
            String answer = list[1];
            String questionType = list[2];

            String insertString = "INSERT INTO " + tableName + "(question, answer, questionType) VALUES ('" + question + "', '" + answer + "', '" + questionType + "');";
            DataBaseOperations.InsertIntoTable(insertString);
        }

        /// <summary>
        /// Retrieves the number of rows a table has
        /// </summary>
        /// <returns name="numberOfRowsInTheTable">The number of the rows in the Table</param>
        public int RetrieveNumberOfRowsInTable()
        {
            return DataBaseOperations.RetrieveNumberOfRowsInTable(TableName);
        }

        /// <summary>
        /// Retrieves a row from the Table
        /// </summary>
        /// <param name="rowNumber">The number of the row to retrieve from the Table</param>
        /// <returns name="retrievedRow">The row that was retrieved</param>
        public String RetrieveTableRow(String tableName, int rowNumber)
        {
            String retrievedRow = DataBaseOperations.RetrieveRowFromTable("" +
                "SELECT * FROM" +
               "(" +
                "Select " +
                "Row_Number() Over (Order By question) As RowNum" +
                ", * " +
               "From " + tableName +
               ") t2 " +
               "where RowNum = " + rowNumber + ";");

            return retrievedRow;
        }

        /// <summary>
        /// Retrieves the number of columns a table contains
        /// </summary>
        /// <returns name ="numberOfColsInTable">The number of columns in a table</returns>
        public int RetriveNumberOfColsInTable()
        {

            return DataBaseOperations.RetrieveNumberOfColsInTable(TableName);
        }

        /// <summary>
        /// Deletes a row from the Table
        /// </summary>
        /// <param name="question">The question nomenclature of the row to DELETE from the Table</param>
        public void DeleteRowFromTable(String question)
        {
            String rowToDelete = ("DELETE FROM " + tableName + " WHERE question='" + question + "';");

            DataBaseOperations.DeleteRowFromTable(rowToDelete);
        }
    }
}
