Class Page1
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        video.Pause()
    End Sub

    Private Sub b2_Click(sender As Object, e As RoutedEventArgs) Handles b2.Click
        video.LoadedBehavior = MediaState.Play
        video.Play()
    End Sub
End Class
