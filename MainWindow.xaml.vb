Class MainWindow

    Private ucb = New UltimateChatBot

    Private Sub Label_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)


        ucb = New UltimateChatBot
        ucb.show

    End Sub

    Private Sub MediaElement_MediaEnded(sender As Object, e As RoutedEventArgs)
        video.Opacity = 0
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        video.Play()
    End Sub

    Private Sub Border_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)

    End Sub
End Class
