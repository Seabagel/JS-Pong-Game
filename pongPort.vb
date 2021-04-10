Public Class Class1
    Inherits BaseScreen
    Private AniTime As Double = 0
    Dim Antitime As Integer = 0
    Public Sub New()
        Name = "Class1"
        State = ScreenState.Active
    End Sub

    Dim paddle As Rectangle = New Rectangle(30, 100, 15, 100)
    Dim paddleSpeed As Integer = 8
    Dim ball As Rectangle = New Rectangle(640, 480, 25, 25);
    Dim vx As Integer = 5
    Dim vy As Integer = 4

    Public Overrides Sub HandleInput()
        'Paddle Stuff
        'Movement
        If Input.KeyDown(Keys.W) Then
            paddle.Y -= paddleSpeed
        End If
        If Input.KeyDown(Keys.S) And paddle.Y < 720 - (paddle.Height) Then
            paddle.Y += paddleSpeed
        End If
        'Collision
        If paddle.Y < 0 Then
            paddle.Y = 0
        End If
        If paddle.Y > 720 Then
            paddle.Y = 720
        End If

        'Ball Stuff
        ball.X += vx
        ball.Y += vy

        If vy < 0 And ball.Y < 0 Then
            vy = -vy;
        End If
        If vy > 0 And ball.Y > 720 - ball.Width Then
            vy = -vy;
        End If
        If vx < 0 And ball.YX < 0 Then
            vy = -vy;
        End If
 if(ball.vx < 0 && ball.x < paddle.w + paddle.x && ball.y < paddle.y + paddle.h && ball.y > paddle.y)
        If vx < 0 And ball.X < paddle.Width + Paddle.X And ball.Y < paddle.Y + paddle.Height And ball.Y > paddle.Y Then
            vx = -vx;
        End If
    End Sub

    Public Overrides Sub Update()
        'Example of how to control your updates
        AniTime += Globals.GameTime.ElapsedGameTime.TotalMilliseconds
        If AniTime > 255 Then
            AniTime = 0
            'Please use this so that when people turn off vsync the whole thing doesn't go to hell
        End If
        Antitime = AniTime * 2
    End Sub

    Public Overrides Sub Draw()
        Globals.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone)
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(paddle.X, paddle.Y, paddle.Width, paddle.Height), Color.White)
        Globals.SpriteBatch.Draw(Textures.Null, New Rectangle(ball.X, ball.Y, ball.Width, ball.Height), Color.White)
        Globals.SpriteBatch.End()
    End Sub
End Class