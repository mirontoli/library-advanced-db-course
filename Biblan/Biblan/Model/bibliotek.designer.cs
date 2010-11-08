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

namespace Biblan.Model
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
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_add_copy")]
		public int usp_add_copy([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(35)")] string isbn)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), isbn);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.search_books_with_a_title_that_begins_with_A", IsComposable=true)]
		public IQueryable<search_books_with_a_title_that_begins_with_AResult> search_books_with_a_title_that_begins_with_A()
		{
			return this.CreateMethodCallQuery<search_books_with_a_title_that_begins_with_AResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_borrow_book")]
		public int usp_borrow_book([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(35)")] string isbn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(75)")] string customerID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> copyID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), isbn, customerID, copyID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_return_book")]
		public int usp_return_book([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(35)")] string isbn, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(75)")] string customerID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> copyID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> bdate)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), isbn, customerID, copyID, bdate);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.get_last_book_borrowed", IsComposable=true)]
		public IQueryable<get_last_book_borrowedResult> get_last_book_borrowed()
		{
			return this.CreateMethodCallQuery<get_last_book_borrowedResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.search_customers_with_more_than_one_book", IsComposable=true)]
		public IQueryable<search_customers_with_more_than_one_bookResult> search_customers_with_more_than_one_book()
		{
			return this.CreateMethodCallQuery<search_customers_with_more_than_one_bookResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.get_copies_for_a_book", IsComposable=true)]
		public IQueryable<get_copies_for_a_bookResult> get_copies_for_a_book([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(35)")] string isbn)
		{
			return this.CreateMethodCallQuery<get_copies_for_a_bookResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), isbn);
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
	
	public partial class search_books_with_a_title_that_begins_with_AResult
	{
		
		private string _ISBN;
		
		private string _Title;
		
		private System.Nullable<int> _NumberOfPages;
		
		private System.Nullable<int> _PrintYear;
		
		private string _Publisher;
		
		private string _Author;
		
		public search_books_with_a_title_that_begins_with_AResult()
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
	
	public partial class get_last_book_borrowedResult
	{
		
		private string _ISBN;
		
		private string _Title;
		
		private System.Nullable<int> _NumberOfPages;
		
		private System.Nullable<int> _PrintYear;
		
		private string _Publisher;
		
		private string _Author;
		
		public get_last_book_borrowedResult()
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
	
	public partial class search_customers_with_more_than_one_bookResult
	{
		
		private int _CustomerID;
		
		private string _Name;
		
		private string _Address;
		
		private string _Phone;
		
		private System.Nullable<int> _NumberOf;
		
		public search_customers_with_more_than_one_bookResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="Int NOT NULL")]
		public int CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this._CustomerID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(75)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this._Address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this._Phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NumberOf", DbType="Int")]
		public System.Nullable<int> NumberOf
		{
			get
			{
				return this._NumberOf;
			}
			set
			{
				if ((this._NumberOf != value))
				{
					this._NumberOf = value;
				}
			}
		}
	}
	
	public partial class get_copies_for_a_bookResult
	{
		
		private string _ISBN;
		
		private int _CopyID;
		
		private System.Nullable<int> _CustomerID;
		
		public get_copies_for_a_bookResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CopyID", DbType="Int NOT NULL")]
		public int CopyID
		{
			get
			{
				return this._CopyID;
			}
			set
			{
				if ((this._CopyID != value))
				{
					this._CopyID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="Int")]
		public System.Nullable<int> CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this._CustomerID = value;
				}
			}
		}
	}
}
#pragma warning restore 1591