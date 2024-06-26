Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions



Public Class UltimateChatBot
    Dim bdbd As Boolean
    Private items As ObservableCollection(Of String)

    Public Sub New()

        InitializeComponent()
        items = New ObservableCollection(Of String)()
        lsvContenido.ItemsSource = items

    End Sub
    Private Sub MediaElement_MediaEnded(sender As Object, e As RoutedEventArgs)
        backg.Position = TimeSpan.Zero
        backg.Play()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        backg.Play()
        bdDocker.Visibility = Visibility.Collapsed
    End Sub

    Private Sub Label_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub btnEnviar_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnEnviar.MouseLeftButtonUp
        llenar()
    End Sub

    Public Sub llenar()

        items.Add("Tú: " & txtInput.Text.ToString())

        items.Add("Chat: " & BuscarYResponder(txtInput.Text.ToString))

        txtInput.Clear()
    End Sub

    Private Sub btnbd2_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnbd2.MouseEnter
        Dim miBrush As New SolidColorBrush(Colors.DeepSkyBlue)
        BTNbd.Fill = miBrush
    End Sub

    Private Sub btnbd2_MouseLeave(sender As Object, e As MouseEventArgs) Handles btnbd2.MouseLeave
        Dim miBrush As New SolidColorBrush(Colors.White)
        BTNbd.Fill = miBrush
    End Sub

    Private Sub BTNbd_MouseEnter(sender As Object, e As MouseEventArgs) Handles BTNbd.MouseEnter
        Dim miBrush As New SolidColorBrush(Colors.DeepSkyBlue)
        BTNbd.Fill = miBrush
    End Sub

    Private Sub BTNbd_MouseLeave(sender As Object, e As MouseEventArgs) Handles BTNbd.MouseLeave
        Dim miBrush As New SolidColorBrush(Colors.White)
        BTNbd.Fill = miBrush
    End Sub

    Private Sub btnSair_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnSair.MouseLeftButtonUp
        bdDocker.Visibility = Visibility.Hidden
    End Sub

    Private Sub btnbd2_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnbd2.MouseLeftButtonUp
        bdDocker.Visibility = Visibility.Visible
    End Sub

    Private Sub BTNbd_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles BTNbd.MouseLeftButtonUp
        bdDocker.Visibility = Visibility.Visible
    End Sub

    Private Sub Label_MouseLeftButtonUp_1(sender As Object, e As MouseButtonEventArgs)
        txtInput.Focus()
        txtInput.Text = ""
        items.Clear()
    End Sub

    Private Sub Label_MouseLeftButtonUp_2(sender As Object, e As MouseButtonEventArgs)
        txtInput.Focus()
        txtInput.Text = ""
        items.Clear()
    End Sub

    Private Sub btnNuevaConversacion_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnNuevaConversacion.MouseLeftButtonUp
        txtInput.Focus()
        txtInput.Text = ""
        items.Clear()
    End Sub

    Private Sub Label_MouseEnter(sender As Object, e As MouseEventArgs)
        dockControlL.Visibility = Visibility.Visible
        dockControlR.Visibility = Visibility.Visible
    End Sub

    Private Sub Label_MouseLeave(sender As Object, e As MouseEventArgs)
        dockControlL.Visibility = Visibility.Hidden
        dockControlR.Visibility = Visibility.Hidden
    End Sub

    Private Sub dockControlR_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles dockControlR.MouseLeftButtonUp
        Me.Close()
    End Sub

    Private Sub dockControlL_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles dockControlL.MouseLeftButtonUp
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Label_MouseLeftButtonUp_3(sender As Object, e As MouseButtonEventArgs)

        Dim ultimaClave As Integer = 0

        Conexion.sentenciaSQL = "SELECT TOP 1 [id_clave], [texto_clave] FROM [dbo].[claves] ORDER BY [id_clave] DESC"
        Conexion.conectar()
        Conexion.comandoSQL = New SqlCommand(Conexion.sentenciaSQL, Conexion.conexionGeneral)
        Conexion.lectorSQL = Conexion.comandoSQL.ExecuteReader
        While Conexion.lectorSQL.Read
            ultimaClave = (Conexion.lectorSQL(0))
        End While
        Conexion.conexionGeneral.Close()

        ultimaClave = ultimaClave + 1

        Conexion.sentenciaSQL = "USE [bd-chat] INSERT INTO [dbo].[claves] ([id_clave],[texto_clave]) VALUES (" & ultimaClave & " ,'" & txtRclave.Text.ToString & "')"
        Conexion.conectar()
        Conexion.comandoSQL = New SqlCommand(sentenciaSQL, conexionGeneral)
        Conexion.respuestaSQL = Conexion.comandoSQL.ExecuteNonQuery
        Conexion.conexionGeneral.Close()

        Conexion.sentenciaSQL = "USE [bd-chat] INSERT INTO [dbo].[respuestas] ([id_clave],[respuesta]) VALUES (" & ultimaClave & " ,'" & txtRrespuesta.Text.ToString & "')"
        Conexion.conectar()
        Conexion.comandoSQL = New SqlCommand(sentenciaSQL, conexionGeneral)
        Conexion.respuestaSQL = Conexion.comandoSQL.ExecuteNonQuery
        Conexion.conexionGeneral.Close()

        txtRclave.Text = ""
        txtRrespuesta.Text = ""
    End Sub

    Private Sub bdDocker_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles bdDocker.IsVisibleChanged

        Conexion.sentenciaSQL = "select claves.id_clave, texto_clave, respuesta from claves inner join respuestas on claves.id_clave = respuestas.id_clave"
        Conexion.conectar()
        Conexion.tablaSQL = New DataTable
        Conexion.adaptadorSQL = New SqlDataAdapter(sentenciaSQL, conexionGeneral)
        Conexion.adaptadorSQL.Fill(tablaSQL)
        dgvDatos.ItemsSource = Conexion.tablaSQL.DefaultView
        Conexion.conexionGeneral.Close()
    End Sub

    Function BuscarYResponder(userInput As String) As String
        Dim respuesta As String = "No tengo una respuesta para eso."
        Try

            conectar()


            Dim sentenciaSQL As String = "SELECT TOP 1 r.respuesta FROM claves c INNER JOIN respuestas r ON c.id_clave = r.id_clave WHERE @userInput LIKE '%' + c.texto_clave + '%' ORDER BY NEWID()"
            Dim comandoSQL As New SqlCommand(sentenciaSQL, conexionGeneral)
            comandoSQL.Parameters.AddWithValue("@userInput", userInput)


            Dim lectorSQL As SqlDataReader = comandoSQL.ExecuteReader()
            If lectorSQL.HasRows Then

                Dim respuestas As New List(Of String)()
                While lectorSQL.Read()
                    respuestas.Add(lectorSQL("respuesta").ToString())
                End While


                Dim rnd As New Random()
                respuesta = respuestas(rnd.Next(respuestas.Count))
            End If
            lectorSQL.Close()
        Catch ex As Exception
            respuesta = "Error: " & ex.Message
        Finally

            conexionGeneral.Close()
        End Try

        Return respuesta
    End Function

    Private Sub lblNuevaClave_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblNuevaClave.MouseLeftButtonUp
        nueva_clave.Visibility = Visibility.Visible
        botonesClave.Visibility = Visibility.Hidden
        lblRegresar.Visibility = Visibility.Visible
    End Sub

    Private Sub IcoNuevaClave_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles IcoNuevaClave.MouseLeftButtonUp
        nueva_clave.Visibility = Visibility.Visible
        botonesClave.Visibility = Visibility.Hidden
        lblRegresar.Visibility = Visibility.Visible
    End Sub

    Private Sub lblCalveExistente_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblCalveExistente.MouseLeftButtonUp
        clave_existente.Visibility = Visibility.Visible
        botonesClave.Visibility = Visibility.Hidden
        lblRegresar.Visibility = Visibility.Visible
    End Sub

    Private Sub icoCalveExistente_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles icoCalveExistente.MouseLeftButtonUp
        clave_existente.Visibility = Visibility.Visible
        botonesClave.Visibility = Visibility.Hidden
        lblRegresar.Visibility = Visibility.Visible
    End Sub

    Private Sub lblRegresar_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblRegresar.MouseLeftButtonUp
        botonesClave.Visibility = Visibility.Visible
        lblRegresar.Visibility = Visibility.Hidden
        clave_existente.Visibility = Visibility.Hidden
        nueva_clave.Visibility = Visibility.Hidden
        editar_clave.Visibility = Visibility.Hidden

    End Sub

    Private Sub btnGuardarResClvEx_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnGuardarResClvEx.MouseLeftButtonUp
        Dim claveSeleccionada As String
        claveSeleccionada = cmbClavesChat.SelectedItem.ToString


        Dim patron As String = "^\d+"

        Dim coincidencia As Match = Regex.Match(claveSeleccionada, patron)

        Dim claveSeleccionadaInt As Integer

        If coincidencia.Success Then

            Dim numeroTexto As String = coincidencia.Value
            claveSeleccionadaInt = Integer.Parse(numeroTexto)

            Conexion.sentenciaSQL = "USE [bd-chat] INSERT INTO [dbo].[respuestas] ([id_clave],[respuesta]) VALUES (" & claveSeleccionadaInt & " ,'" & txtRrespuestaExistente.Text.ToString & "')"
            Conexion.conectar()
            Conexion.comandoSQL = New SqlCommand(sentenciaSQL, conexionGeneral)
            Conexion.respuestaSQL = Conexion.comandoSQL.ExecuteNonQuery
            Conexion.conexionGeneral.Close()
        Else

        End If



        txtRrespuestaExistente.Text = ""
    End Sub

    Private Sub clave_existente_IsVisibleChanged(sender As Object, e As DependencyPropertyChangedEventArgs) Handles clave_existente.IsVisibleChanged

        cmbClavesChat.Items.Clear()

        Conexion.sentenciaSQL = "select claves.id_clave, texto_clave from claves"
        Conexion.conectar()
        Conexion.comandoSQL = New SqlCommand(Conexion.sentenciaSQL, Conexion.conexionGeneral)
        Conexion.lectorSQL = Conexion.comandoSQL.ExecuteReader
        While Conexion.lectorSQL.Read
            cmbClavesChat.Items.Add(Conexion.lectorSQL(0) & " -. " & Conexion.lectorSQL(1))
        End While
        Conexion.conexionGeneral.Close()

    End Sub

    Private Sub Rectangle_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
        Me.WindowState = WindowState.Minimized
    End Sub

    Private Sub Label_MouseLeftButtonUp_4(sender As Object, e As MouseButtonEventArgs)
        Me.Close()
    End Sub

    Private Sub btnOrdenar_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnOrdenar.MouseLeftButtonUp
        Conexion.sentenciaSQL = "SELECT claves.id_clave, texto_clave, respuesta FROM claves INNER JOIN respuestas ON claves.id_clave = respuestas.id_clave ORDER BY claves.id_clave ASC"
        Conexion.conectar()
        Conexion.tablaSQL = New DataTable
        Conexion.adaptadorSQL = New SqlDataAdapter(sentenciaSQL, conexionGeneral)
        Conexion.adaptadorSQL.Fill(tablaSQL)
        dgvDatos.ItemsSource = Conexion.tablaSQL.DefaultView
        Conexion.conexionGeneral.Close()
    End Sub

    Private Sub txtInput_PreviewKeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.PreviewKeyDown
        If txtInput.Text <> "" Then
            If e.Key = Key.Enter Then
                llenar()
            End If
        End If
    End Sub

    Private Sub btnEditar1_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnEditar1.MouseLeftButtonUp
        nueva_clave.Visibility = Visibility.Hidden
        botonesClave.Visibility = Visibility.Hidden
        editar_clave.Visibility = Visibility.Visible
        lblRegresar.Visibility = Visibility.Visible
    End Sub

    Private Sub btnEditarCalveRespuesta_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnEditarCalveRespuesta.MouseLeftButtonUp
        Dim clave As String
        Dim respuesta As String
        Dim respuesta_editar As String
        Dim id_clave As Integer

        clave = txtCalveEditar.Text
        respuesta_editar = txtRrespuestaEditar.Text


        Conexion.sentenciaSQL = "select claves.id_clave, respuesta from claves inner join respuestas on claves.id_clave = respuestas.id_clave where claves.texto_clave = '" & clave & "'"
        Conexion.conectar()
        Conexion.comandoSQL = New SqlCommand(Conexion.sentenciaSQL, Conexion.conexionGeneral)
        Conexion.lectorSQL = Conexion.comandoSQL.ExecuteReader
        While Conexion.lectorSQL.Read
            id_clave = Conexion.lectorSQL(0)
            respuesta = Conexion.lectorSQL(1)
        End While
        Conexion.conexionGeneral.Close()

        Conexion.sentenciaSQL = "UPDATE [dbo].[respuestas] SET [respuesta] = '" & respuesta_editar & "'  WHERE id_clave =" & id_clave & " and respuesta = '" & respuesta & "'"
        Conexion.conectar()
        Conexion.comandoSQL = New SqlCommand(sentenciaSQL, conexionGeneral)
        Conexion.respuestaSQL = Conexion.comandoSQL.ExecuteNonQuery
        Conexion.conexionGeneral.Close()





    End Sub

    Private Sub btnOrdenar1_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnOrdenar1.MouseLeftButtonUp
        If bdDocker.Visibility = Visibility.Visible Then

            Conexion.sentenciaSQL = "select claves.id_clave, texto_clave, respuesta from claves inner join respuestas on claves.id_clave = respuestas.id_clave ORDER BY claves.id_clave ASC"
            Conexion.conectar()
            Conexion.tablaSQL = New DataTable
            Conexion.adaptadorSQL = New SqlDataAdapter(sentenciaSQL, conexionGeneral)
            Conexion.adaptadorSQL.Fill(tablaSQL)
            dgvDatos.ItemsSource = Conexion.tablaSQL.DefaultView
            Conexion.conexionGeneral.Close()

        End If
    End Sub
End Class
