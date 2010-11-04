﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblan
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="bibliotek")]
	public partial class bibliotekDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public bibliotekDataContext() : 
				base(global::Biblan.Properties.Settings.Default.bibliotekConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public bibliotekDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bibliotekDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bibliotekDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public bibliotekDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_add_copy")]
		public int usp_add_copy([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(35)")] string isbn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> copyid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), isbn, copyid);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_add_customer")]
		public int usp_add_customer([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> customerid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string address, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string phone)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), customerid, name, address, phone);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_add_book")]
		public int usp_add_book([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(35)")] string isbn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(75)")] string title, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> number_of_pages, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> print_year, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string publisher, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string author)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), isbn, title, number_of_pages, print_year, publisher, author);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.search_books_titles", IsComposable=true)]
		public IQueryable<search_books_titlesResult> search_books_titles([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(75)")] string title)
		{
			return this.CreateMethodCallQuery<search_books_titlesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), title);
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.search_book_print_year", IsComposable=true)]
		public IQueryable<search_book_print_yearResult> search_book_print_year()
		{
			return this.CreateMethodCallQuery<search_book_print_yearResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.search_number_of_book_pages", IsComposable=true)]
		public IQueryable<search_number_of_book_pagesResult> search_number_of_book_pages()
		{
			return this.CreateMethodCallQuery<search_number_of_book_pagesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
	}
	
	public partial class search_books_titlesResult
	{
		
		private string _ISBN;
		
		private string _Title;
		
		private System.Nullable<int> _NumberOfPages;
		
		private System.Nullable<int> _PrintYear;
		
		private string _Publisher;
		
		private string _Author;
		
		public search_books_titlesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ISBN", DbType="VarChar(35) NOT NULL", CanBeNull=false)]
		public string ISBN
		{
			get
			{
				return this._ISBN;
			}
			set
			{
				if ((this._ISBN != value))
				{
					this._ISBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(75)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumberOfPages", DbType="Int")]
		public System.Nullable<int> NumberOfPages
		{
			get
			{
				return this._NumberOfPages;
			}
			set
			{
				if ((this._NumberOfPages != value))
				{
					this._NumberOfPages = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrintYear", DbType="Int")]
		public System.Nullable<int> PrintYear
		{
			get
			{
				return this._PrintYear;
			}
			set
			{
				if ((this._PrintYear != value))
				{
					this._PrintYear = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Publisher", DbType="VarChar(50)")]
		public string Publisher
		{
			get
			{
				return this._Publisher;
			}
			set
			{
				if ((this._Publisher != value))
				{
					this._Publisher = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="VarChar(50)")]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this._Author = value;
				}
			}
		}
	}
	
	public partial class search_book_print_yearResult
	{
		
		private string _ISBN;
		
		private string _Title;
		
		private System.Nullable<int> _NumberOfPages;
		
		private System.Nullable<int> _PrintYear;
		
		private string _Publisher;
		
		private string _Author;
		
		public search_book_print_yearResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ISBN", DbType="VarChar(35) NOT NULL", CanBeNull=false)]
		public string ISBN
		{
			get
			{
				return this._ISBN;
			}
			set
			{
				if ((this._ISBN != value))
				{
					this._ISBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(75)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumberOfPages", DbType="Int")]
		public System.Nullable<int> NumberOfPages
		{
			get
			{
				return this._NumberOfPages;
			}
			set
			{
				if ((this._NumberOfPages != value))
				{
					this._NumberOfPages = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrintYear", DbType="Int")]
		public System.Nullable<int> PrintYear
		{
			get
			{
				return this._PrintYear;
			}
			set
			{
				if ((this._PrintYear != value))
				{
					this._PrintYear = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Publisher", DbType="VarChar(50)")]
		public string Publisher
		{
			get
			{
				return this._Publisher;
			}
			set
			{
				if ((this._Publisher != value))
				{
					this._Publisher = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="VarChar(50)")]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this._Author = value;
				}
			}
		}
	}
	
	public partial class search_number_of_book_pagesResult
	{
		
		private string _ISBN;
		
		private string _Title;
		
		private System.Nullable<int> _NumberOfPages;
		
		private System.Nullable<int> _PrintYear;
		
		private string _Publisher;
		
		private string _Author;
		
		public search_number_of_book_pagesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ISBN", DbType="VarChar(35) NOT NULL", CanBeNull=false)]
		public string ISBN
		{
			get
			{
				return this._ISBN;
			}
			set
			{
				if ((this._ISBN != value))
				{
					this._ISBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(75)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumberOfPages", DbType="Int")]
		public System.Nullable<int> NumberOfPages
		{
			get
			{
				return this._NumberOfPages;
			}
			set
			{
				if ((this._NumberOfPages != value))
				{
					this._NumberOfPages = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrintYear", DbType="Int")]
		public System.Nullable<int> PrintYear
		{
			get
			{
				return this._PrintYear;
			}
			set
			{
				if ((this._PrintYear != value))
				{
					this._PrintYear = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Publisher", DbType="VarChar(50)")]
		public string Publisher
		{
			get
			{
				return this._Publisher;
			}
			set
			{
				if ((this._Publisher != value))
				{
					this._Publisher = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="VarChar(50)")]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this._Author = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
