Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim picturePath As String
        Try
            Dim openFileDialog As New OpenFileDialog

            If (openFileDialog.ShowDialog() = DialogResult.OK) Then
                picturePath = openFileDialog.FileName
                CreateLineOnPicture(picturePath)

            End If
        Catch ex As Exception
            MessageBox.Show("An Error Occured with : " + ex.Message.ToString())
        End Try

    End Sub


    Private Sub CreateCircleOnPicture(myBitmap As Bitmap)
        Dim p As New System.Drawing.Pen(Color.Yellow, 4)
        Dim g As System.Drawing.Graphics
        PictureBox1.Refresh()
        g = PictureBox1.CreateGraphics
        g.DrawEllipse(p, 70, 10, 100, 150)

        PictureBox2.Image = myBitmap
    End Sub


    Private Sub CreateLineOnPicture(picturePath As String)
        PictureBox1.ImageLocation = picturePath

        Dim myBitmap As New Bitmap(picturePath)

        MsgBox(myBitmap.GetPixel(0, 0).ToString)


        For y As Integer = 0 To myBitmap.Height - 1
            For x As Integer = 0 To myBitmap.Width - 1

                Dim clr As Color = myBitmap.GetPixel(x, y)

                If (x > 150) And (x < 200) Then
                    clr = Color.FromName("Red")

                    myBitmap.SetPixel(x, y, clr)
                End If
            Next x
        Next


        CreateCircleOnPicture(myBitmap)
    End Sub

End Class
