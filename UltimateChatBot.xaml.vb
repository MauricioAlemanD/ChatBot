Imports System.Collections.ObjectModel



Public Class UltimateChatBot


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

        items.Add(txtInput.Text.ToString())
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
    End Sub

    Private Sub Label_MouseLeftButtonUp_2(sender As Object, e As MouseButtonEventArgs)
        txtInput.Focus()
    End Sub

    Private Sub btnNuevaConversacion_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles btnNuevaConversacion.MouseLeftButtonUp
        txtInput.Focus()
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
End Class
