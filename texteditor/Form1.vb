Imports System.IO
Imports System.Windows.Forms ' pastikan namespace Forms diimport

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private savetext As SaveFileDialog 'for saving text
    Private opentext As OpenFileDialog 'for opening text 

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            'set properties of the savefiledialog
            savetext = New SaveFileDialog
            savetext.FileName = "Untitled" 'set this as default title of every new text file
            'set the allowed file type to be saved
            'only text file is allowed 
            savetext.Filter = "Text file only (*.txt)|*.txt"

            With savetext
                .AddExtension = True
                .CheckPathExists = True
                .CheckFileExists = False ' ubah menjadi False karena saat save, file belum ada
                .OverwritePrompt = True
                .ValidateNames = True
                .DefaultExt = "txt"
                .ShowHelp = True

                'save the text file
                If savetext.ShowDialog() = DialogResult.OK Then
                    Try
                        My.Computer.FileSystem.WriteAllText(.FileName, txteditor.Text, False)
                        'get and set file name on the app title window
                        Me.Text = "My Text Editor " & .FileName
                    Catch fileexception As Exception
                        Throw fileexception
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            'set properties of the openfiledialog
            opentext = New OpenFileDialog
            opentext.FileName = ""
            'set the file type to be opened
            'the file type is only text file
            opentext.Filter = "Text file only (*.txt)|*.txt"

            With opentext
                .DefaultExt = "txt"
                .Title = "Open a text file"
                .CheckFileExists = True
                .Multiselect = False

                If opentext.ShowDialog() = DialogResult.OK Then
                    Try
                        'open text file in text box of the application
                        txteditor.Text = My.Computer.FileSystem.ReadAllText(.FileName)
                        'get and set the title of the opened file on app window
                        Me.Text = "My Text Editor " & .FileName
                    Catch fileexception As Exception
                        Throw fileexception
                    End Try
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
