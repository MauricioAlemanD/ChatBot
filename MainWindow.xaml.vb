Class MainWindow

    Private ucb = New UltimateChatBot
    Private p1 = New Page1

    Private Sub Label_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)


        ucb = New UltimateChatBot
        ucb.show

    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        f1.Navigate(p1)
    End Sub

    Private Sub Border_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)

    End Sub
End Class
