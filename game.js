window.onload = function() {
    canvas = document.getElementById('game');
    context = canvas.getContext('2d');
    setInterval(update, 1000/61);
    canvas.addEventListener('mousemove', function(e){
        paddle.y = e.clientY - paddle.h/2;
    })
};

var score = 0;

var paddle = {
    x : 30,
    y : 100,
    w : 15,
    h : 100
};

var ball = {
    x : 500,
    y : 250,
    d : 25,
    vx : 6,
    vy : 4
};

function restart() {
    ball.x = canvas.width/2;
    ball.y = canvas.height/2;
    ball.vx = Math.floor(Math.random() * 6) + 4;
    ball.vy = Math.floor(Math.random() * 6) + 3;
    score = 0;
}

function update() {
    ball.x += ball.vx;
    ball.y += ball.vy;

    //Collision < 0 is left, > 0 is right
    if(ball.vy < 0 && ball.y < 0) {
        ball.vy = -ball.vy;
    };
    if(ball.vy > 0 && ball.y > canvas.height - ball.d) {
        ball.vy = -ball.vy;
    };
    // if(ball.x < 0 && ball.vx < 0){
    //     ball.vx = -ball.vx;
    // };
    if(ball.vx > 0 && ball.x > canvas.width - ball.d){
        ball.vx = -ball.vx;
    };
    if(ball.vx < 0 && ball.x < paddle.w + paddle.x && ball.y < paddle.y + paddle.h && ball.y > paddle.y){
            ball.vx = -ball.vx;
            score += 1;
            ball.vx += Math.floor(Math.random() * 3);
            ball.vy += Math.floor(Math.random() * 3) - 3;
    };
    if(ball.vx < 0 && ball.x < 0){
            restart();
    };

    //Draws the background
    context.fillStyle = 'black';
    context.fillRect(0, 0, canvas.width, canvas.height);

    //Paddle & Ball
    context.fillStyle = 'white';
    context.fillRect(paddle.x, paddle.y, paddle.w, paddle.h);
    context.fillRect(ball.x, ball.y, ball.d, ball.d);
    context.fillText(score, 24, 18);
    
};