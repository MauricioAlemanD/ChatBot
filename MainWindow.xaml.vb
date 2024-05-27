Imports System.Windows.Media.Animation

Class MainWindow

    Private ucb = New UltimateChatBot

    Private Sub Label_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)


        ucb = New UltimateChatBot
        ucb.show

    End Sub


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Border_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)

    End Sub

    Private Sub video_MediaEnded(sender As Object, e As RoutedEventArgs) Handles video.MediaEnded
        Transition()
    End Sub

    Private Sub lblSkip_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles lblSkip.MouseLeftButtonUp
        Transition()
    End Sub

    Private Sub Transition()
        Dim brush As New LinearGradientBrush(Colors.Transparent, Colors.Black, New Point(0, 0), New Point(1, 1))
        video.OpacityMask = brush
        Dim animation As New DoubleAnimation(0, TimeSpan.FromSeconds(1))
        video.BeginAnimation(UIElement.OpacityProperty, animation)

        lblTitulo.Opacity = 100
        btnIniciar.Opacity = 100
        btnCerrar.Opacity = 100
        Icono.Opacity = 100

        lblTitulo.Visibility = Visibility.Visible
        btnIniciar.Visibility = Visibility.Visible
        btnCerrar.Visibility = Visibility.Visible
        Icono.Visibility = Visibility.Visible

        video.Visibility = Visibility.Hidden
    End Sub
End Class
