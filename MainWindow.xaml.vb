Imports System.Windows.Media.Animation

Class MainWindow
    Private ucb = New UltimateChatBot

    Private Sub Label_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs)
        ucb = New UltimateChatBot
        ucb.show
        Me.Close()
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        backg.Play()
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

        lblSkip.Visibility = Visibility.Hidden
    End Sub

    Private Sub Label_MouseLeftButtonUp_1(sender As Object, e As MouseButtonEventArgs)
        Me.Close()
    End Sub

    Private Sub MediaElement_MediaEnded(sender As Object, e As RoutedEventArgs)
        backg.Position = TimeSpan.Zero
        backg.Play()
    End Sub

    Private Sub Label_MouseEnter(sender As Object, e As MouseEventArgs)
        'color de hover

        btnIniciar.Background = New SolidColorBrush(ColorConverter.ConvertFromString("#FFEF7BCB"))
    End Sub

    Private Sub btnIniciar_MouseEnter(sender As Object, e As MouseEventArgs) Handles btnIniciar.MouseEnter

    End Sub

    Private Sub Label_MouseLeave(sender As Object, e As MouseEventArgs)
        btnIniciar.Background = New SolidColorBrush(ColorConverter.ConvertFromString("#FFE828AC"))
    End Sub

    Private Sub lblCerrar_MouseEnter(sender As Object, e As MouseEventArgs) Handles lblCerrar.MouseEnter
        btnCerrar.Background = New SolidColorBrush(ColorConverter.ConvertFromString("#FF252525"))
    End Sub

    Private Sub lblCerrar_MouseLeave(sender As Object, e As MouseEventArgs) Handles lblCerrar.MouseLeave
        btnCerrar.Background = New SolidColorBrush(ColorConverter.ConvertFromString("#FF000000"))
    End Sub
End Class
