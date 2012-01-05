Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ReDelimIt
Imports System.IO

<TestClass()> Public Class UnitTest1

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

#Region "Additional test attributes"
    '
    ' You can use the following additional attributes as you write your tests:
    '
    ' Use ClassInitialize to run code before running the first test in the class
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Use ClassCleanup to run code after all tests in a class have run
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Use TestInitialize to run code before running each test
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Use TestCleanup to run code after each test has run
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestMethod()> Public Sub PlainText()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "this is my result"
        Dim expected = input
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlainTextCsv()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "this is my result,this is my result"
        Dim expected = "this is my result<*temp*>this is my result"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlainTextCsvSpace()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "this is my result, this is my result"
        Dim expected = "this is my result<*temp*>this is my result"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlainTextCsvSimpleQuote()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "this is my result,""this is my result"""
        Dim expected = "this is my result<*temp*>""this is my result"""
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlainTextCsvQuoteWithComma()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "this is my result,""this, that, another is my result"""
        Dim expected = "this is my result<*temp*>""this, that, another is my result"""
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub PlainTextCsvQuoteWithCommaMultiline()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "this is my result,""this, that, another is my result""" & vbCrLf & "this is my result,""this, that, another is my result"""
        Dim expected = "this is my result<*temp*>""this, that, another is my result""" & vbCrLf & "this is my result<*temp*>""this, that, another is my result"""
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub QuotesInAQuotedField()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "the inseam is 7"" which is quite normal,2,3,4"
        Dim expected = "the inseam is 7"" which is quite normal<*temp*>2<*temp*>3<*temp*>4"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub QuotesFollwedByCommaInAQuotedField()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = """the inseam is 7"""", which is quite normal"",2,3,4"
        Dim expected = """the inseam is 7"""", which is quite normal""<*temp*>2<*temp*>3<*temp*>4"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub ManyQuotesFollwedByCommaInAQuotedField()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = """the inseam is 7"""""""", which is quite normal"",2,3,4"
        Dim expected = """the inseam is 7"""""""", which is quite normal""<*temp*>2<*temp*>3<*temp*>4"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub ManyQuotesLaterInLineFollwedByCommaInAQuotedField()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = "test,""the inseam is 7"""""""", which is quite normal"",2,3,4"
        Dim expected = "test<*temp*>""the inseam is 7"""""""", which is quite normal""<*temp*>2<*temp*>3<*temp*>4"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    <TestMethod()> Public Sub CommaList()
        Dim count As Integer
        Dim delimiter As String = "<*temp*>"
        Dim input = """Drill, Ye Tarriers, Drill (1900)"",9/1/1900"
        Dim expected = """Drill, Ye Tarriers, Drill (1900)""<*temp*>9/1/1900"
        Dim actual = Redelimiter.ProcessFile(StringToStreamReader(input), delimiter, False, False, count)
        Assert.AreEqual(Of String)(expected, actual)
    End Sub

    Private Shared Function StringToStreamReader(ByVal str As String) As StreamReader
        Dim s = New MemoryStream(Text.Encoding.Default.GetBytes(str))
        Return New StreamReader(s)
    End Function

End Class
