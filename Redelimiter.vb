Imports System.IO

Public Class Redelimiter

    Public Shared Function Redelimit(ByVal delimiter As String, ByVal hasHeaders As Boolean, ByVal addPk As Boolean, ByVal InputFile As String, ByVal OutputFile As String) As Integer
        Dim objReader As StreamReader = Nothing
        Dim count As Integer = 0

        Try
            objReader = New StreamReader(File.OpenRead(InputFile), System.Text.Encoding.Default)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If objReader Is Nothing Then
            MsgBox("Invalid file: " & InputFile)
            count = -1
            Exit Function
        End If

        Redelimiter.SaveTextToFile(Redelimiter.ProcessFile(objReader, delimiter, hasHeaders, addPk, count), OutputFile)

        objReader.Close()

    End Function

    Public Shared Function ProcessFile(ByVal reader As StreamReader, ByVal delimiter As String, ByVal hasHeaders As Boolean, ByVal addPk As Boolean, ByRef count As Integer) As String

        Dim ph1 As String = delimiter

        Dim sb As New System.Text.StringBuilder

        'grab the first line
        Dim line = Trim(reader.ReadLine)

        'advance to the next line if the first line is column headings
        If hasHeaders Then
            line = Trim(reader.ReadLine)
        End If

        While Not String.IsNullOrEmpty(line) 'loop through each line

            count += 1

            'Replace commas with our custom-made delimiter
            line = line.Replace(",", ph1)

            'Find a quoted part of the line, which could legitimately contain commas.
            'In that case we will need to identify the quoted section and swap commas back in for our custom placeholder.
            Dim starti = line.IndexOf(ph1 & """", 0)
            If line.IndexOf("""",0) = 0 then starti=0

            While starti > -1 'loop through quoted fields

                Dim FieldTerminatorFound As Boolean = False

                'Find end quote token (originally  a ",)
                Dim endi As Integer = line.IndexOf("""" & ph1, starti)

                If endi < 0 Then
                    FieldTerminatorFound = True
                    If endi < 0 Then endi = line.Length - 1
                End If

                While Not FieldTerminatorFound

                    'Find any more quotes that are part of that sequence, if any
                    Dim backChar As String = """" 'thats one quote
                    Dim quoteCount = 0
                    While backChar = """"
                        quoteCount += 1
                        backChar = line.Chars(endi - quoteCount)
                    End While

                    If quoteCount Mod 2 = 1 Then 'odd number of quotes. real field terminator
                        FieldTerminatorFound = True
                    Else 'keep looking
                        endi = line.IndexOf("""" & ph1, endi + 1)
                    End If
                End While

                'Grab the quoted field from the line, now that we have the start and ending indices
                Dim source As String
                If starti = 0 Then
                    source = line.Substring(starti, endi - starti + 1)
                Else
                    source = line.Substring(starti + ph1.Length, endi - starti - ph1.Length + 1)
                End If


                'And swap the commas back in
                line = line.Replace(source, source.Replace(ph1, ","))

                'Find the next quoted field
                '                If endi >= line.Length - 1 Then endi = line.Length 'During the swap, the length of line shrinks so an endi value at the end of the line will fail
                starti = line.IndexOf(ph1 & """", starti + ph1.Length)

            End While

            'Add our primary key to the line
            If addPk Then
                line = String.Concat(count.ToString, ph1, line)
            End If

            line = line.Replace(delimiter & " ", delimiter)

            sb.AppendLine(line)

            line = Trim(reader.ReadLine)

        End While

        Return Left(sb.ToString, sb.ToString.Length - 2)

    End Function

    Public Shared Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String) As Boolean
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath, False, System.Text.Encoding.Default)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            Throw Ex
        End Try
        Return bAns
    End Function
End Class
