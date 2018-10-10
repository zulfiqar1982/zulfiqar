namespace ProjectLibrary
{
    using System;
    using System.Configuration;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    using System.Text;


    public class DataAccess : IDisposable
    {
        #region Private member variables

        private int _timeOut = 60;

        private SourceType _eSourceType;
        private SqlCommand _SQL_Command;
        private SqlConnection _SQL_Connection;
        private SqlDataAdapter _SQL_DataAdapter;
        private SqlTransaction _SQL_Transaction = null;
        private String _CustomConnectionString;
        private bool _hasRolledBack = false;

        #endregion

        #region Constructor

        public DataAccess()
        {
            _eSourceType = SourceType.Default;
            _SQL_Connection = new SqlConnection(this.ConnectionString);

        }

        public DataAccess(SourceType dataSource)
        {
            _eSourceType = dataSource;
            _SQL_Connection = new SqlConnection(this.ConnectionString);
        }

        public DataAccess(String ConnectionString)
        {
            _eSourceType = SourceType.Custom;
            _CustomConnectionString = ConnectionString;
            _SQL_Connection = new SqlConnection(ConnectionString);
        }

        public DataAccess(SourceType dataSource, int timeOut)
        {
            _eSourceType = dataSource;
            _SQL_Connection = new SqlConnection(this.ConnectionString);
            _timeOut = timeOut;
        }
        #endregion

        /// <summary>
        /// Sets the duration of the connection (seconds)
        /// Default is 30 seconds
        /// </summary>
        public int TimeOut
        {
            set { _timeOut = value; }
            get { return _timeOut; }
        }

        public void Rollback()
        {
            if (!_hasRolledBack)
            {
                if (_SQL_Transaction != null)
                {
                    _SQL_Transaction.Rollback();
                    _SQL_Transaction.Dispose();
                    _SQL_Transaction = null;
                }
                _hasRolledBack = true;
            }
        }

        public void Commit()
        {
            if (!_hasRolledBack)
            {
                if (_SQL_Transaction != null)
                {
                    _SQL_Transaction.Commit();
                    _SQL_Transaction.Dispose();
                    _SQL_Transaction = null;
                }
            }
            else
            {
                throw new Exception("Transaction has been rolled back");
            }
        }

        #region Properties





        /// <summary>
        /// Gets the connection string of master database
        /// </summary>
        private string ConnectionString
        {
            get
            {
                switch (_eSourceType)
                {
                    case SourceType.Default:
                        return _MasterConnectionString1;
                    default:
                        return _MasterConnectionString1;
                }
            }
        }

        #endregion

        #region Enumerators

        /// <summary>
       /// </summary>
        public enum SourceType
        {
            Default = 0,
            Master1,
            Custom
        }
        #endregion

        #region Private

        #region Properties

        private string _MasterConnectionString1
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["Master1"] == null)
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config."));

                string strConnectionString = ConfigurationManager.ConnectionStrings["Master1"].ConnectionString;

                if (String.IsNullOrEmpty(strConnectionString))
                    throw (new NullReferenceException("ConnectionString configuration is missing from you web.config."));
                else
                    return (strConnectionString);
            }
        }

        #endregion

        #endregion

        #region Public Methods

        #region SqlDataReader

        /// <summary>
        /// Retrieve SqlReader by Sql query and Parameter(s)
        /// </summary>
        public SqlDataReader ExecuteReader(string Sql, ArrayList SqlParams)
        {
            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                        _SQL_Command.CommandText = Sql;


                    _SQL_Command.CommandType = CommandType.Text;


                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    try
                    {
                        return _SQL_Command.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieve SqlReader by Sql query only
        /// </summary>
        public SqlDataReader ExecuteReader(string Sql)
        {
            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                        _SQL_Command.CommandText = Sql;


                    _SQL_Command.CommandType = CommandType.Text;


                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    try
                    {
                        return _SQL_Command.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieve SqlReader by StoredProcedure and Parameter(s)
        /// </summary>
        public SqlDataReader ExecuteReaderBySP(string SPName, ArrayList SqlParams)
        {
            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = SPName;
                    }

                    _SQL_Command.CommandType = CommandType.StoredProcedure;


                    if (_SQL_Command.Parameters != null)
                    {
                        if (_SQL_Command.Parameters.Count > 0)
                        {
                            _SQL_Command.Parameters.Clear();
                        }
                    }

                    foreach (SqlParameter param in SqlParams)
                    {
                        _SQL_Command.Parameters.Add(param);
                    }

                    try
                    {
                        return _SQL_Command.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieve SqlReader by StoredProcedure only
        /// </summary>
        public SqlDataReader ExecuteReaderBySP(string SPName)
        {
            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                        _SQL_Command.CommandText = SPName;

                    _SQL_Command.CommandType = CommandType.StoredProcedure;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    try
                    {
                        return _SQL_Command.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return null;
        }

        #endregion

        #region Execute

        /// <summary>
        /// Execute Sql query and Parameter(s). 
        /// </summary>
        /// <returns>Returns count of records affected. If return -1, indicates an error.</returns>
        /// 
        public int Execute(string Sql, ArrayList SqlParams)
        {
            int _recordsAffected = -1; // If your function receives -1 means there was an error !

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = Sql;
                    }

                    _SQL_Command.CommandType = CommandType.Text;

                    if (_SQL_Transaction == null)
                    {
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();
                    }

                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                    {
                        if (_SQL_Command.Parameters.Count > 0)
                        {
                            _SQL_Command.Parameters.Clear();
                        }
                    }

                    foreach (SqlParameter param in SqlParams)
                    {
                        _SQL_Command.Parameters.Add(param);
                    }

                    try
                    {
                        _recordsAffected = _SQL_Command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return _recordsAffected;
        }


        /// <summary>
        /// Execute StoredProcedure and Parameter(s). 
        /// </summary>
        /// <returns>Returns count of records affected. If return -1, indicates an error.</returns>
        /// 

        public int ExecuteBySP(string SPName, ArrayList SqlParams)
        {
            int _recordsAffected = -1;

            // If your function receives -1 means there was an error !
            if (Connect(_SQL_Connection))
            {
                // opens a connection if not already opened
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = SPName;
                    }

                    _SQL_Command.CommandType = CommandType.StoredProcedure;

                    if (_SQL_Transaction == null)
                    {
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();
                    }

                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                    {
                        if (_SQL_Command.Parameters.Count > 0)
                        {
                            _SQL_Command.Parameters.Clear();
                        }
                    }

                    foreach (SqlParameter param in SqlParams)
                    {
                        _SQL_Command.Parameters.Add(param);
                    }

                    try
                    {
                        _recordsAffected = _SQL_Command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return _recordsAffected;
        }



        #endregion

        #region ExecuteScalar

        /// <summary>
        /// Execute Sql query and Parameter(s). 
        /// </summary>
        /// <returns>Returns the value of the 1st column only</returns>
        public object ExecuteScalar(string Sql, ArrayList SqlParams)
        {
            object _returnValue = null;

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = Sql;
                    }


                    _SQL_Command.CommandType = CommandType.Text;

                    if (_SQL_Transaction == null)
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();

                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    try
                    {
                        _returnValue = _SQL_Command.ExecuteScalar();

                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return _returnValue;

        }

        /// <summary>
        /// Execute Sql query only
        /// </summary>
        /// <returns>Returns the value of the 1st column only</returns>
        public object ExecuteScalar(string Sql)
        {
            object _returnValue = null;

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = Sql;
                    }

                    _SQL_Command.CommandType = CommandType.Text;

                    if (_SQL_Transaction == null)
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();

                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    try
                    {
                        _returnValue = _SQL_Command.ExecuteScalar();

                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return _returnValue;
        }

        /// <summary>
        /// Execute StoredProcedure and Parameter(s) 
        /// </summary>
        /// <returns>Returns the value of the 1st column only</returns>
        public object ExecuteScalarBySP(string SPName, ArrayList SqlParams)
        {
            object _returnValue = null;

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = SPName;
                    }


                    _SQL_Command.CommandType = CommandType.StoredProcedure;



                    if (_SQL_Transaction == null)
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();


                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    try
                    {
                        _returnValue = _SQL_Command.ExecuteScalar();

                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return _returnValue;
        }

        /// <summary>
        /// Execute StoredProcedure only
        /// </summary>
        /// <returns>Returns the value of the 1st column only</returns>
        public object ExecuteScalarBySP(string SPName)
        {
            object _returnValue = null;

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = SPName;
                    }

                    _SQL_Command.CommandType = CommandType.StoredProcedure;

                    if (_SQL_Transaction == null)
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();


                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    try
                    {
                        _returnValue = _SQL_Command.ExecuteScalar();

                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return _returnValue;
        }

        #endregion

        #region IdentityExecute

        /// <summary>
        /// Execute Sql query and Parameter(s) 
        /// </summary>
        /// <returns>Returns identity value </returns>
        public long IdentityExecute(string Sql, ArrayList SqlParams)
        {
            long _identity = 0;

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = Sql;
                    }

                    _SQL_Command.CommandType = CommandType.Text;


                    if (_SQL_Transaction == null)
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();

                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    try
                    {
                        _identity = Convert.ToInt64(_SQL_Command.ExecuteScalar());
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return _identity;
        }

        /// <summary>
        /// Execute StoredProcedure and Parameter(s) 
        /// </summary>
        /// <returns>Returns identity value </returns>
        public long IdentityExecuteBySP(string SPName, ArrayList SqlParams)
        {
            long _identity = 0;

            if (Connect(_SQL_Connection)) // opens a connection if not already opened
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    if (_SQL_Command == null)
                    {
                        _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                        _SQL_Command.CommandTimeout = _timeOut;
                    }
                    else
                    {
                        _SQL_Command.CommandText = SPName;
                    }

                    _SQL_Command.CommandType = CommandType.StoredProcedure;


                    if (_SQL_Transaction == null)
                        _SQL_Transaction = _SQL_Connection.BeginTransaction();

                    _SQL_Command.Transaction = _SQL_Transaction;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    try
                    {
                        _identity = Convert.ToInt64(_SQL_Command.ExecuteScalar());
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return _identity;
        }

        #endregion

        #region Datatable

        /// <summary>
        /// Retreive DataTable by Sql query and Parameter(s) 
        /// </summary>
        public DataTable SelectDataTable(string Sql, ArrayList SqlParams)
        {
            DataTable dt = new DataTable();

            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);
                    //SQL_DataAdapter.ReturnProviderSpecificTypes = true; // use SQL data types

                    try
                    {
                        _SQL_DataAdapter.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// Retreive DataTable by Sql query only
        /// </summary>
        public DataTable SelectDataTable(string Sql)
        {
            DataTable dt = new DataTable();

            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                    {
                        if (_SQL_Command.Parameters.Count > 0)
                        {
                            _SQL_Command.Parameters.Clear();
                        }
                    }

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);

                    try
                    {
                        _SQL_DataAdapter.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// Retreive DataTable by StoredProcedure and Parameter(s) 
        /// </summary>
        public DataTable SelectDataTableBySP(string SPName, ArrayList SqlParams)
        {
            DataTable dt = new DataTable();

            if (_SQL_Connection == null)
            {
                _SQL_Connection = new SqlConnection(this.ConnectionString);
            }

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                    _SQL_Command.CommandType = CommandType.StoredProcedure;
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                    {
                        if (_SQL_Command.Parameters.Count > 0)
                        {
                            _SQL_Command.Parameters.Clear();
                        }
                    }

                    foreach (SqlParameter param in SqlParams)
                    {
                        _SQL_Command.Parameters.Add(param);
                    }

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);

                    try
                    {
                        _SQL_DataAdapter.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return dt;
        }

        /// <summary>
        /// Retreive DataTable by StoredProcedure only
        /// </summary>
        public DataTable SelectDataTableBySP(string SPName)
        {
            DataTable dt = new DataTable();
            if (_SQL_Connection == null)
            {
                _SQL_Connection = new SqlConnection(this.ConnectionString);
            }

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                    _SQL_Command.CommandType = CommandType.StoredProcedure;
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                    {
                        if (_SQL_Command.Parameters.Count > 0)
                        {
                            _SQL_Command.Parameters.Clear();
                        }
                    }

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);

                    try
                    {
                        _SQL_DataAdapter.Fill(dt);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return dt;
        }
        #endregion

        #region DataSet

        /// <summary>
        /// Retreive DataSet by Sql query and Parameter(s) 
        /// </summary>
        public DataSet SelectDataSet(string Sql, ArrayList SqlParams)
        {
            DataSet ds = new DataSet();

            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);
                    //SQL_DataAdapter.ReturnProviderSpecificTypes = true; // use SQL data types

                    try
                    {
                        _SQL_DataAdapter.Fill(ds);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// Retreive DataSet by Sql query only
        /// </summary>
        public DataSet SelectDataSet(string Sql)
        {
            DataSet ds = new DataSet();

            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    _SQL_Command = new SqlCommand(Sql, _SQL_Connection);
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);
                    //SQL_DataAdapter.ReturnProviderSpecificTypes = true; // use SQL data types

                    try
                    {
                        _SQL_DataAdapter.Fill(ds);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// Retreive DataTable by StoredProcedure and Parameter(s) 
        /// </summary>
        public DataSet SelectDataSetBySP(string SPName, ArrayList SqlParams)
        {
            DataSet ds = new DataSet();

            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                    _SQL_Command.CommandType = CommandType.StoredProcedure;
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    foreach (SqlParameter param in SqlParams)
                        _SQL_Command.Parameters.Add(param);

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);
                    //SQL_DataAdapter.ReturnProviderSpecificTypes = true; // use SQL data types

                    try
                    {
                        _SQL_DataAdapter.Fill(ds);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// Retreive DataTable by StoredProcedure only
        /// </summary>
        public DataSet SelectDataSetBySP(string SPName)
        {
            DataSet ds = new DataSet();

            if (_SQL_Connection == null)
                _SQL_Connection = new SqlConnection(this.ConnectionString);

            if (Connect(_SQL_Connection))
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {

                    _SQL_Command = new SqlCommand(SPName, _SQL_Connection);
                    _SQL_Command.CommandType = CommandType.StoredProcedure;
                    _SQL_Command.CommandTimeout = _timeOut;

                    if (_SQL_Command.Parameters != null)
                        if (_SQL_Command.Parameters.Count > 0) _SQL_Command.Parameters.Clear();

                    _SQL_DataAdapter = new SqlDataAdapter(_SQL_Command);
                    //SQL_DataAdapter.ReturnProviderSpecificTypes = true; // use SQL data types

                    try
                    {
                        _SQL_DataAdapter.Fill(ds);
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
            return ds;
        }

        #endregion

        #endregion

        private static bool Connect(SqlConnection sqlconn)
        {
            bool _connected = false;

            try
            {
                if (sqlconn.State != ConnectionState.Open)
                {
                    sqlconn.Open();
                    _connected = true;
                }
                else
                {
                    _connected = true;
                }
            }
            catch (Exception ex)
            {
                sqlconn.Close();
                throw ex;
            }

            return _connected;
        }

        /// <summary>
        /// This method is automatically executed in the using statement.
        /// </summary>
        public void Dispose()
        {
            if (_SQL_Transaction != null)
            {
                _SQL_Transaction.Dispose();
            }

            if (_SQL_DataAdapter != null)
            {
                _SQL_DataAdapter.Dispose();
            }

            if (_SQL_Command != null)
            {
                _SQL_Command.Parameters.Clear();
                _SQL_Command.Dispose();
            }

            if (_SQL_Connection != null)
            {
                if (_SQL_Connection.State == ConnectionState.Open)
                {
                    _SQL_Connection.Close();
                }
                _SQL_Connection.Dispose();
            }

            GC.SuppressFinalize(this);
        }


    }
}
