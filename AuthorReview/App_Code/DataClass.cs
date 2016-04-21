using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
///Thois class will connect to the database
/// It will have methods to retrieve the Services
/// It will also retrieve all the grants for the service
/// Marcus 2016-4-12
/// </summary>
public class DataClass
{
    SqlConnection connect;
    public DataClass()
    {
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthorConnectionString"].ToString());
    }

    public DataTable GetAuthor()
    {
        DataTable tbl = new DataTable();

        string sql = "Select AuthorKey, AuthorName from Author";

        SqlCommand cmd = new SqlCommand(sql, connect);

        tbl = ReadData(cmd);
        return tbl;
    }

    public DataTable GetBooks(int AuthorKey)
    {
        DataTable tbl = null;
        string sql = "SELECT BookTitle, BookEntryDate, BookISBN FROM Book INNER JOIN authorbook ON book.bookkey= authorbook.bookkey WHERE AuthorKey = @Key";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.AddWithValue("@Key", AuthorKey);
       
        tbl = ReadData(cmd);
        return tbl;

    }

    private DataTable ReadData(SqlCommand cmd)
    {
        SqlDataReader reader = null;
        DataTable tbl = new DataTable();

        connect.Open();
        reader = cmd.ExecuteReader();
        tbl.Load(reader);
        reader.Close();
        connect.Close();

        return tbl;
    }

}