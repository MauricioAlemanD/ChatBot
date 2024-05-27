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
End Class
