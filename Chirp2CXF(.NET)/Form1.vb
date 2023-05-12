Imports System.IO
Imports System.Windows.Forms.LinkLabel
Imports Microsoft.VisualBasic.FileIO

Public Class Form1
    Public chirpfile As String = " "
    Public cxffile As String = " "
    Public targetfile As String



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles btnOpenCSV.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            lblHelloWorld.Text = OpenFileDialog1.FileName
            chirpfile = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOpenCXF.Click
        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            lblCXFfileselected.Text = OpenFileDialog2.FileName
            cxffile = OpenFileDialog2.FileName
        End If
    End Sub


    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        targetfile = Path.GetDirectoryName(cxffile) & "\processed_" & Path.GetFileName(cxffile)

        If chirpfile.Contains(".csv") And cxffile.Contains(".cxf") Then

            Dim ctcss_tones() As Double = {
            67.0, 69.3, 71.9, 74.4, 77.0, 79.7, 82.5, 85.4, 88.5, 91.5,
            94.8, 97.4, 100.0, 103.5, 107.2, 110.9, 114.8, 118.8, 123.0, 127.3,
            131.8, 136.5, 141.3, 146.2, 151.4, 156.7, 159.8, 162.2, 165.5, 167.9,
            171.3, 173.8, 177.3, 179.9, 183.5, 186.2, 189.9, 192.8, 196.6, 199.5,
            203.5, 206.5, 210.7, 218.1, 225.7, 229.1, 233.6, 241.8, 250.3
            }
            Using input_file As New StreamReader(cxffile)
                Using output_file As New StreamWriter(targetfile)
                    Dim line As String

                    ' Read each line from the input file
                    While Not input_file.EndOfStream
                        line = input_file.ReadLine()

                        ' Write the line to the output file
                        output_file.WriteLine(line)

                        ' Check if the line contains the target word
                        If line.Contains("<Channels_MR>") Then
                            ' If so, stop reading and writing
                            Exit While
                        End If
                    End While
                End Using
            End Using

            Using csv_file As New TextFieldParser(chirpfile)
                csv_file.TextFieldType = FieldType.Delimited
                csv_file.SetDelimiters(",")

                ' Read the header row to get the field names
                Dim fieldNames As String() = csv_file.ReadFields()

                While Not csv_file.EndOfData
                    ' Read each row of data
                    Dim rowData As String() = csv_file.ReadFields()

                    ' Put each value into a separate variable
                    Dim Location As String = rowData(Array.IndexOf(fieldNames, "Location"))
                    Dim Name As String = rowData(Array.IndexOf(fieldNames, "Name"))
                    Dim Frequency As String = rowData(Array.IndexOf(fieldNames, "Frequency"))
                    Dim Duplex As String = rowData(Array.IndexOf(fieldNames, "Duplex"))
                    Dim Offset As String = rowData(Array.IndexOf(fieldNames, "Offset"))
                    Dim Tone As String = rowData(Array.IndexOf(fieldNames, "Tone"))
                    Dim rToneFreq As String = rowData(Array.IndexOf(fieldNames, "rToneFreq"))
                    Dim cToneFreq As String = rowData(Array.IndexOf(fieldNames, "cToneFreq"))
                    Dim DtcsCode As String = rowData(Array.IndexOf(fieldNames, "DtcsCode"))
                    Dim DtcsPolarity As String = rowData(Array.IndexOf(fieldNames, "DtcsPolarity"))
                    Dim RxDtcsCode As String = rowData(Array.IndexOf(fieldNames, "RxDtcsCode"))
                    Dim CrossMode As String = rowData(Array.IndexOf(fieldNames, "CrossMode"))
                    Dim TStep As String = rowData(Array.IndexOf(fieldNames, "TStep"))
                    Dim Skip As String = rowData(Array.IndexOf(fieldNames, "Skip"))
                    Dim Power As String = rowData(Array.IndexOf(fieldNames, "Power"))
                    Dim Mode As String = rowData(Array.IndexOf(fieldNames, "Mode"))

                    ' Process the row data
                    ' Check location is ok (<200)
                    If Convert.ToDouble(Location) > 200 Then
                        Exit While
                    End If
                    Dim chanIndex As String = Location

                    ' Name goes into <Name>
                    Name = Name.Substring(0, Math.Min(Name.Length, 10))

                    ' Tidy up for <Rxfreq>
                    Dim RxFreq As Double = Convert.ToDouble(Frequency)
                    RxFreq = Math.Round(RxFreq, 6)

                    ' Calculate Transmit <Txfreq> from Receive and Offset Xml variable <Txfreq>
                    Dim TxFreq As Double = Convert.ToDouble(Frequency) + Convert.ToDouble(Offset) ' CHIRP sets Offset to 0 if not used
                    If Duplex = "-" Then
                        TxFreq = Convert.ToDouble(Frequency) - Convert.ToDouble(Offset)
                    End If
                    TxFreq = Math.Round(TxFreq, 6)

                    ' Calculate ctcss tone index position for rx and tx tones
                    Dim AnaTxCTCIndex As Integer = 1
                    Dim AnaRxCTCIndex As Integer = 1


                    If ctcss_tones.Contains(Double.Parse(rToneFreq)) Then
                        AnaTxCTCIndex = Array.IndexOf(ctcss_tones, Double.Parse(rToneFreq))
                    End If

                    If ctcss_tones.Contains(Double.Parse(cToneFreq)) Then
                        AnaRxCTCIndex = Array.IndexOf(ctcss_tones, Double.Parse(cToneFreq))
                    End If

                    ' Calculate values for <AnaTxCTCFlag> <AnaRxCTCFlag>
                    Dim AnaTxCTCFlag As Integer = 0
                    Dim AnaRxCTCFlag As Integer = 0

                    If Tone = "" Then
                        AnaTxCTCFlag = 0
                        AnaRxCTCFlag = 0
                    ElseIf Tone = "Tone" Then
                        AnaTxCTCFlag = 1
                        AnaRxCTCFlag = 0
                    ElseIf Tone = "TSQL" Then
                        AnaTxCTCFlag = 1
                        AnaRxCTCFlag = 1
                    ElseIf Tone = "Cross" AndAlso CrossMode = "->Tone" Then
                        AnaTxCTCFlag = 0
                        AnaRxCTCFlag = 1
                    ElseIf Tone = "Cross" AndAlso CrossMode = "Tone->Tone" Then
                        AnaTxCTCFlag = 1
                        AnaRxCTCFlag = 1
                    End If

                    ' Calculate <TxPowerLevel>
                    Dim TxPowerLevel As Integer = 2 ' Default to high
                    If Power = "4.0W" Then ' Chirp config for a BF=8HP uses these values
                        TxPowerLevel = 1
                    ElseIf Power = "1.0W" Then
                        TxPowerLevel = 0
                    End If

                    ' Calculate the <BandWidth>
                    Dim Bandwidth As Integer = 0 ' Default to 25kHz
                    If Mode = "NFM" Then
                        Bandwidth = 1
                    End If

                    ' Process the row data
                    ' ...

                    Using output_file As New StreamWriter(targetfile, True)
                        output_file.WriteLine("    <Channel Name=""" & Name & """ chanIndex=""" & chanIndex & """>")
                        output_file.WriteLine("      <BandWidth>" & Bandwidth & "</BandWidth>")
                        output_file.WriteLine("      <TxFreq>" & TxFreq & "</TxFreq>")
                        output_file.WriteLine("      <RxFreq>" & RxFreq & "</RxFreq>")
                        output_file.WriteLine("      <TxPowerLevel>" & TxPowerLevel & "</TxPowerLevel>")
                        output_file.WriteLine("      <AnaTxCTCFlag>" & AnaTxCTCFlag & "</AnaTxCTCFlag>")
                        output_file.WriteLine("      <AnaRxCTCFlag>" & AnaRxCTCFlag & "</AnaRxCTCFlag>")
                        output_file.WriteLine("      <AnaTxCTCIndex>" & AnaTxCTCIndex & "</AnaTxCTCIndex>")
                        output_file.WriteLine("      <AnaRxCTCIndex>" & AnaRxCTCIndex & "</AnaRxCTCIndex>")
                        output_file.WriteLine("      <FreqStep>2</FreqStep>")
                        output_file.WriteLine("      <FreqReverseFlag>0</FreqReverseFlag>")
                        output_file.WriteLine("      <EncryptFlag>0</EncryptFlag>")
                        output_file.WriteLine("      <BusyNoTx>0</BusyNoTx>")
                        output_file.WriteLine("      <PTTIdFlag>0</PTTIdFlag>")
                        output_file.WriteLine("      <DTMFDecode>0</DTMFDecode>")
                        output_file.WriteLine("      <AMChanFlag>0</AMChanFlag>")
                        output_file.WriteLine("    </Channel>")
                    End Using

                    ListBox1.Items.Add("Converted: " & chanIndex & " " & Name)

                End While
            End Using

            ' Read all lines from the input file
            Dim lines As String() = File.ReadAllLines(cxffile)

            ' Initialize a flag variable to False
            Dim found_keyword As Boolean = False

            ' Create a list to store the lines to be appended
            Dim linesToAppend As List(Of String) = New List(Of String)()

            ' Loop through the lines
            For Each line As String In lines
                ' Check if the line contains the keyword
                If line.Contains("</Channels_MR>") Then
                    ' Set the flag variable to True to start copying lines
                    found_keyword = True
                End If

                ' If the flag variable is True, add the line to the list
                If found_keyword Then
                    linesToAppend.Add(line)
                End If
            Next

            ' Append the lines to the output file
            File.AppendAllLines(targetfile, linesToAppend)

            lblResult.Text = "Output written to: " & targetfile

        Else
            lblResult.Text = "Specify both files to proceede"
        End If

    End Sub


End Class
